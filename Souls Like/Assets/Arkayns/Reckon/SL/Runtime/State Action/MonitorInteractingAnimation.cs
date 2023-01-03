namespace Arkayns.Reckon.SL {
    
    public class MonitorInteractingAnimation : StateAction {
        
        // -- Variables --
        private CharacterStateManager m_states;
        private string m_targetBool;
        private string m_targetState;

        // -- Constructor --
        public MonitorInteractingAnimation(CharacterStateManager characterStateManager, string targetBool, string targetState) {
            m_states = characterStateManager;
            m_targetBool = targetBool;
            m_targetState = targetState;
        } // Constructor MonitorInteractingAnimation
        
        // -- Methods --
        public override bool Execute() {
            var isInteracting = m_states.animator.GetBool(m_targetBool);

            if(isInteracting) {
                return false;
            } else {
                m_states.ChangeState(m_targetState);
                return true;
            }
        } // Override Execute ()
        
    } // Class MonitorInteractingAnimation
    
} // Namespace Arkayns Reckon SL