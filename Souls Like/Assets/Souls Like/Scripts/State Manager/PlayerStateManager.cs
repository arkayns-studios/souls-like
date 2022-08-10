using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkayns.SL {

    public class PlayerStateManager : CharacterStateManager {

        [Header("Inputs")] 
        [Range(-1, 1)] public float mouseY;
        [Range(-1, 1)] public float mouseX;
        public float moveAmount;
        public Vector3 rotateDirection;

        [Header("References")] 
        public new Transform camera;

        [Header("Movement Stats")] 
        public float frontRayOffset = 0.5f;
        public float movementSpeed = 2;
        public float adaptSpeed = 10;
        public float rotationSpeed = 10;

        [HideInInspector] public LayerMask ignoreForGroundCheck;

        [HideInInspector] public string locomotionID = "locomotion";
        [HideInInspector] public string attackStateID = "attackID";

        public override void Init() {
            base.Init();

            State locomotion = new State(
                // Fixed Update
                new List<StateAction>() {
                    new MovePlayerCharacter(this)
                },
                // Update
                new List<StateAction>() {
                    new InputManager(this),
                },
                // Late Update
                new List<StateAction>() {
                });

            locomotion.onEnter = DisableRoot;
            
            State attackState = new State(
                // Fixed Update
                new List<StateAction>() {
                    new InputManager(this),
                },
                // Update
                new List<StateAction>() {
                    new MonitorInteractingAnimation(this, "isInteracting", locomotionID),
                },
                // Late Update
                new List<StateAction>() {
                });

            attackState.onEnter = EnableRootMotion;

            RegisterState(locomotionID, locomotion);
            RegisterState(attackStateID, attackState);

            ChangeState(locomotionID);

            ignoreForGroundCheck = ~(1 << 9 | 1 << 10);
        } // Override Init

        private void FixedUpdate() {
            delta = Time.fixedDeltaTime;
            base.FixedTick();
        } // FixedUpdate

        private void Update() {
            delta = Time.deltaTime;
            base.Tick();
        } // Update

        private void LateUpdate() {
            base.LateTick();
        } // LateUpdate

        #region State Events

        private void DisableRoot() {
            useRootMotion = false;
        } // DisableRoot

        private void EnableRootMotion() {
            useRootMotion = true;
        } // EnableRootMotion

        #endregion
        
    } // Class PlayerStateManager

} // Namespace Arkayns SL