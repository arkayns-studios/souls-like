using UnityEngine;

namespace Arkayns.Reckon.SL {

    public class MovePlayerCharacter : StateAction {
        
        // -- Variables --
        private PlayerStateManager m_state;
        
        // -- Constructor --
        public MovePlayerCharacter (PlayerStateManager playerStateManager) {
            m_state = playerStateManager;
        } // Constructor MovePlayerCharacter

        // -- Variables --
        public override bool Execute () {
            float frontY = 0;
            var origin = m_state.mTransform.position + (m_state.mTransform.forward * m_state.frontRayOffset);
            origin.y += 0.5f;
            Debug.DrawRay (origin, -Vector3.up, Color.red, 0.1f, false);
            if(Physics.Raycast(origin, -Vector3.up, out var hit, 1, m_state.ignoreForGroundCheck)) {
                var y = hit.point.y;
                frontY = y - m_state.mTransform.position.y;
            }

            var currentVelocity = m_state.rigidbody.velocity;
            var targetVelocity = m_state.mTransform.forward * (m_state.moveAmount * m_state.movementSpeed);
            //if (m_state.isLockingOn) {
            //    targetVelocity = m_state.rotateDirection * m_state.moveAmount * movementSpeed;
            //}

            if (m_state.isGrounded) {
                var moveAmount = m_state.moveAmount;

                if (moveAmount > 0.1f) {
                    m_state.rigidbody.isKinematic = false;
                    m_state.rigidbody.drag = 0;
                    if (Mathf.Abs(frontY) > 0.02f) {
                        targetVelocity.y = ((frontY > 0) ? frontY + 0.2f : frontY - 0.2f) * m_state.movementSpeed;
                    }
                } else {
                    var abs = Mathf.Abs (frontY);

                    if (abs > 0.02f) {
                        m_state.rigidbody.isKinematic = true;
                        targetVelocity.y = 0;
                        m_state.rigidbody.drag = 4;
                    }
                }
                
                HandleRotation ();
            } else {
                // m_state.collider.height = colStartHeight;
                m_state.rigidbody.isKinematic = false;
                m_state.rigidbody.drag = 0;
                targetVelocity.y = currentVelocity.y;
            }

            HandleAnimations ();

            Debug.DrawRay ((m_state.mTransform.position + Vector3.up * 0.2f), targetVelocity, Color.green, 0.01f, false);
            m_state.rigidbody.velocity = Vector3.Lerp (currentVelocity, targetVelocity, m_state.delta * m_state.adaptSpeed);

            return false;
        } // Execute ()

        private void HandleRotation () {
            var h = m_state.horizontal;
            var v = m_state.vertical;

            var targetDir = m_state.camera.transform.forward * v;
            targetDir += m_state.camera.transform.right * h;
            targetDir.Normalize ();

            targetDir.y = 0;
            if (targetDir == Vector3.zero)
                targetDir = m_state.mTransform.forward;

            var tr = Quaternion.LookRotation (targetDir);
            var targetRotation = Quaternion.Slerp (m_state.mTransform.rotation, tr, m_state.delta * m_state.moveAmount * m_state.rotationSpeed);
            m_state.mTransform.rotation = targetRotation;

        } // HandleRotation ()

        private void HandleAnimations () {
            if (m_state.isGrounded) {
                var m = m_state.moveAmount;
                var f = m switch {
                    > 0 and < 0.5f => 0.5f,
                    > 0.5f => 1,
                    _ => 0
                };

                m_state.animator.SetFloat ("forward", f, 0.2f, m_state.delta);
            } else {

            }
        } // HandleAnimations ()

    } // Class MovePlayerCharacter

} // Namespace Arkayns Reckon SL