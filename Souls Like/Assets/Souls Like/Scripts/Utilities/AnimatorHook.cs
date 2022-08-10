using UnityEngine;

namespace Arkayns.SL {
    
    public class AnimatorHook : MonoBehaviour {

        private CharacterStateManager m_states;
    
        public virtual void Init(CharacterStateManager stateManager) {
            m_states = stateManager;
        } // Init

        public void OnAnimatorMove() {
            OnAnimatorMoveOverride();
        } // OnAnimatorMove

        protected virtual void OnAnimatorMoveOverride() {
            if (m_states.useRootMotion == false) return;
            
            if (m_states.isGrounded && m_states.delta > 0) {
                Vector3 v = (m_states.animator.deltaPosition) / m_states.delta;
                v.y = m_states.rigidbody.velocity.y;
                m_states.rigidbody.velocity = v;
            }
        } // OnAnimatorMoveOverride

    } // Class AnimatorHook
    
} // Namespace Arkayns SL