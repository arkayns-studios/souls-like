using UnityEngine;

namespace Arkayns.SL {

    public class InputManager : StateAction {
        private PlayerStateManager m_states;

        // Trigger & Bumper
        private bool m_RB, m_RT, m_LB, m_LT;
        private bool m_isAttaking;
        // Inventory
        private bool m_inventoryInput;
        // Prompt
        private bool m_BInput, m_YInput, m_XInput, m_AInput;
        // Dpad
        private bool m_leftArrow, m_rightArrow, m_downArrow, m_upArrow;

        public InputManager (PlayerStateManager states) {
            m_states = states;
        } // Constructor InputManager

        public override bool Execute () {
            bool retVal = false;
            m_isAttaking = false;

            m_states.horizontal = Input.GetAxis ("Horizontal");
            m_states.vertical = Input.GetAxis ("Vertical");

            m_RB = Input.GetButton ("RB");
            m_RT = Input.GetButton ("RT");
            m_LB = Input.GetButton ("LB");
            m_LT = Input.GetButton ("LT");

            m_inventoryInput = Input.GetButton ("Inventory");

            m_BInput = Input.GetButton ("B");
            m_YInput = Input.GetButtonDown ("Y");
            m_XInput = Input.GetButton ("X");
            m_AInput = Input.GetButton ("A");

            m_leftArrow = Input.GetButton ("Left");
            m_rightArrow = Input.GetButton ("Right");
            m_downArrow = Input.GetButton ("Down");
            m_upArrow = Input.GetButton ("Up");

            m_states.mouseX = Input.GetAxis ("Mouse X");
            m_states.mouseY = Input.GetAxis ("Mouse Y");

            m_states.moveAmount = Mathf.Clamp01 (Mathf.Abs (m_states.horizontal) + Mathf.Abs (m_states.vertical));

            retVal = HandleAttacking ();

            return false;
        } // Execute

        private bool HandleAttacking () {
            if (m_RB || m_RT || m_LB || m_LT) {
                m_isAttaking = true;
            }

            if (m_YInput) {
                m_isAttaking = false;
            }

            if (m_isAttaking) {
                // Find the actual animation from the items
                // play target animation
                m_states.PlayTargetAnimation("Attack 1", true);
                m_states.ChangeState(m_states.attackStateID);
            }

            return m_isAttaking;
        } // HandleAttacking

 
    } // Class InputManager

} // Namespace Arkayns SL