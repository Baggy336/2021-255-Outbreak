using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Howley
{
    public class EnemyBasicController : MonoBehaviour
    {
        static class States
        {
            public class State
            {
                protected EnemyBasicController enemy;

                virtual public State Update()
                {
                    return null;
                }
                virtual public void OnStart(EnemyBasicController enemy)
                {
                    this.enemy = enemy;
                }
                virtual public void OnEnd()
                {

                }
            }

            //////////////////////// Children of State
            public class Idle : State {
                public override State Update()
                {
                    // Behavior:
                    // Transitions:
                    return null;
                }
            }
            public class Persuing : State 
            {
                public override State Update()
                {
                    // Behavior:
                    // Transitions:
                    return null;
                }
            }
            public class Patrolling : State
            {
                public override State Update()
                {
                    // Behavior:
                    // Transitions:
                    return null;
                }
            }
            public class Stunned : State 
            {
                public override State Update()
                {
                    // Behavior:
                    // Transitions:
                    return null;
                }
            }
            public class Death : State
            {
                public override State Update()
                {
                    // Behavior:
                    // Transitions:
                    return null;
                }
            }
            public class Attack1 : State
            {
                public override State Update()
                {
                    // Behavior:
                    // Transitions:
                    return null;
                }
            }
            public class Attack2 : State 
            {
                public override State Update()
                {
                    // Behavior:
                    // Transitions:
                    return null;
                }
            }
            public class Attack3 : State 
            {
                public override State Update()
                {
                    // Behavior:
                    // Transitions:
                    return null;
                }
            }
        }

        private States.State state;

        private NavMeshAgent nav;

        public Transform attackTarget;

        void Start()
        {
            nav = GetComponent<NavMeshAgent>();

        }
        void Update()
        {
            if (attackTarget != null) nav.SetDestination(attackTarget.position);

            if (state == null) SwitchState(new States.Idle());

            if (state != null) SwitchState(state.Update());
        }
        void SwitchState(States.State newState)
        {
            if (newState == null) return; // Don't switch to nothing...

            // Call the current state's onEnd function.
            if (state != null) state.OnEnd();

            // Switch the state.
            state = newState;
            
            // Call the new state's onStart function.
            state.OnStart(this);
        }
    }
}

