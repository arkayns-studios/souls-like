using UnityEngine;

namespace Arkayns.Reckon.SL {
    
    public class OnStateEnterBool : StateMachineBehaviour {
        
        // -- Variables --
        public string boolName;
        public bool status;
        public bool resetOnExit;

        // -- Built-In Methods --
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            animator.SetBool(boolName, status);
        } // OnStateEnter ()

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            if(resetOnExit) {
                animator.SetBool(boolName, !status);
            }
        } // OnStateExit ()

    } // Class OnStateEnterBool
    
} // Namespace Arkayns Reckon SL