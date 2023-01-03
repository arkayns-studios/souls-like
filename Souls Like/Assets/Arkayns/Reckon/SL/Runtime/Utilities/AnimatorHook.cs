using UnityEngine;

namespace Arkayns.Reckon.SL {
    
    public class AnimatorHook : MonoBehaviour {

        // -- Variables --
        private CharacterStateManager m_states;
    
        // -- Built-In Methods --
        public void OnAnimatorMove() {
            OnAnimatorMoveOverride();
        } // OnAnimatorMove ()
        
        // -- Methods --
        public virtual void Init(CharacterStateManager stateManager) {
            m_states = stateManager;
        } // Init ()
        
        protected virtual void OnAnimatorMoveOverride() {
            if (m_states.useRootMotion == false) return;
            
            if (m_states.isGrounded && m_states.delta > 0) {
                Vector3 v = (m_states.animator.deltaPosition) / m_states.delta;
                v.y = m_states.rigidbody.velocity.y;
                m_states.rigidbody.velocity = v;
            }
        } // OnAnimatorMoveOverride ()

    } // Class AnimatorHook
    
} // Namespace Arkayns SL