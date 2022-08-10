namespace Arkayns.SL {
    
    public class MonitorInteractingAnimation : StateAction {
        private CharacterStateManager m_states;
        private string m_targetBool;
        private string m_targetState;

        public MonitorInteractingAnimation(CharacterStateManager characterStateManager, string targetBool, string targetState) {
            m_states = characterStateManager;
            m_targetBool = targetBool;
            m_targetState = targetState;
        } // Constructor MonitorInteractingAnimation
        
        public override bool Execute() {
            bool isInteracting = m_states.animator.GetBool(m_targetBool);

            if(isInteracting) {
                return false;
            } else {
                m_states.ChangeState(m_targetState);
                return true;
            }
        } // Override Execute
        
    } // Class MonitorInteractingAnimation
    
} // Namespace Arkayns SL