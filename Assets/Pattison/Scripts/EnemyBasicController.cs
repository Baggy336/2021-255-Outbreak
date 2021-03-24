using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Pattison {
    public class EnemyBasicController : MonoBehaviour {
        
        static class States {
            public class State {

                protected EnemyBasicController enemy;

                virtual public State Update() {
                    return null;
                }
                virtual public void OnStart(EnemyBasicController enemy) {
                    this.enemy = enemy;
                }
                virtual public void OnEnd() {

                }
            }

            /////////////////// Child classes:
            
            public class Idle : State { }
            public class Pursuing : State { }
            public class Patrolling : State { }
            public class Stunned : State { }
            public class Death : State { }
            public class Attack1 : State { }
            public class Attack2 : State { }
            public class attack3 : State { }

        }

        enum BossPhase {
            PhaseOne,
            PhaseTwo,
            PhaseThree
        }

        private BossPhase currentPhase;

        private States.State state;

        private NavMeshAgent nav;

        public Transform attackTarget;


        void Start() {
            nav = GetComponent<NavMeshAgent>();


        }

        void Update() {


            if (state == null) SwitchState(new States.Idle());

            if (state != null) SwitchState(state.Update());

        }
        void MoveTowardsTarget() {

            if (attackTarget != null) nav.SetDestination(attackTarget.position);

        }
        void SwitchState(States.State newState) {

            if (newState == null) return; // don't switch to nothing...
            if (state != null) state.OnEnd(); // tell previous state it is done
            state = newState; // swap states
            state.OnStart(this);
        }


    }
}