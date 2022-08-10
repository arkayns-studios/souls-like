using UnityEngine;

namespace Arkayns.SL {
    
    public class OnStateEnterBool : StateMachineBehaviour {
        public string boolName;
        public bool status;
        public bool resetOnExit;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            animator.SetBool(boolName, status);
        } // Override OnStateEnter

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            if(resetOnExit) {
                animator.SetBool(boolName, !status);
            }
        } // Override OnStateExit

    } // Class OnStateEnterBool
    
} // Namespace Arkayns SL