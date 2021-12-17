using UnityEngine;

namespace Arkayns.SL {

    public class InputManager : StateAction {

        private PlayerStateManager states;

        // Trigger & Bumper
        private bool RB, RT, LB, LT;
        private bool isAttaking;
        // Inventory
        private bool inventoryInput;
        // Prompt
        private bool BInput, YInput, XInput, AInput;
        // Dpad
        private bool leftArrow, rightArrow, downArrow, upArrow;

        public InputManager (PlayerStateManager states) {
            this.states = states;
        } // Constructor InputManager

        public override bool Execute () {
            bool retVal = false;

            states.horizontal = Input.GetAxis ("Horizontal");
            states.vertical = Input.GetAxis ("Vertical");

            RB = Input.GetButton ("RB");
            RT = Input.GetButton ("RT");
            LB = Input.GetButton ("LB");
            LT = Input.GetButton ("LT");

            inventoryInput = Input.GetButton ("Inventory");

            BInput = Input.GetButton ("B");
            YInput = Input.GetButtonDown ("Y");
            XInput = Input.GetButton ("X");
            AInput = Input.GetButton ("A");

            leftArrow = Input.GetButton ("Left");
            rightArrow = Input.GetButton ("Right");
            downArrow = Input.GetButton ("Down");
            upArrow = Input.GetButton ("Up");

            states.mouseX = Input.GetAxis ("Mouse X");
            states.mouseY = Input.GetAxis ("Mouse Y");

            states.moveAmount = Mathf.Clamp01 (Mathf.Abs (states.horizontal) + Mathf.Abs (states.vertical));

            retVal = HandleAttacking ();

            return false;
        } // Execute

        private bool HandleAttacking () {
            if (RB || RT || LB || LT) {
                //isAttaking = true;
            }

            if (YInput) {
                isAttaking = false;
            }

            if (isAttaking) {
                // Find the actual animation from the items
                // play target animation
                // stateManager.ChangeState (stateManager.attackStateID);
            }

            return isAttaking;
        } // HandleAttacking

 
    } // Class InputManager

} // Namespace Arkayns SL