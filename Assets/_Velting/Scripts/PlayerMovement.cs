using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Velting
{
    public class PlayerMovement : MonoBehaviour
    {

        public float playerSpeed = 10;


        private CharacterController pawn;
        
        void Start()
        {
            pawn = GetComponent<CharacterController>();
        }

        void Update()
        {

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");


            Vector3 move = Vector3.right * h + Vector3.forward * v;

            if(move.sqrMagnitude >1) move.Normalize(); //fix bug with diagonal input vectors

            pawn.Move(move * Time.deltaTime * playerSpeed);
        }

        
    }
}
