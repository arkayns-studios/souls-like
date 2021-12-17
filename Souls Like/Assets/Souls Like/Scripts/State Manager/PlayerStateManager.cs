using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkayns.SL {

    public class PlayerStateManager : CharacterStateManager {

        [Header ("Inputs")]
        [Range (-1, 1)] public float mouseY;
        [Range (-1, 1)] public float mouseX;
        public float moveAmount;
        public Vector3 rotateDirection;

        [Header ("States")]
        public bool isGrounded;

        [Header ("References")]
        public new Transform camera;

        [Header("Movement Stats")]
        public float frontRayOffset = 0.5f;
        public float movementSpeed = 2;
        public float adaptSpeed = 10;
        public float rotationSpeed = 10;

        [HideInInspector]
        public LayerMask ignoreForGroundCheck;

        [HideInInspector]
        public string locomotionID = "locomotion";
        [HideInInspector]
        public string attackStateID = "attackState";

        public override void Init () {
            base.Init ();

            State locomotion = new State (
                new List<StateAction> () // Fixed Update
                { 
                    new InputManager(this),
                    new MovePlayerCharacter(this)
                },
                new List<StateAction> () // Update
                {
                    new InputManager(this),
                },
                new List<StateAction> () // Late Update
                {
                });

            State attackState = new State (
                 new List<StateAction> () // Fixed Update
                 {
                                new InputManager(this),
                 },
                 new List<StateAction> () // Update
                 {
                 },
                 new List<StateAction> () // Late Update
                 {
                 });

            RegisterState (locomotionID, locomotion);
            RegisterState (attackStateID, attackState);

            ChangeState (locomotionID);

            ignoreForGroundCheck = ~(1 << 9 | 1 << 10);
        } // Override Init

        private void FixedUpdate () {
            delta = Time.fixedDeltaTime;
            base.FixedTick ();
        } // FixedUpdate

        private void Update () {
            delta = Time.deltaTime;
            base.Tick ();
        } // Update

        private void LateUpdate () {
            base.LateTick ();
        } // LateUpdate

    } // Class PlayerStateManager

} // Namespace Arkayns SL