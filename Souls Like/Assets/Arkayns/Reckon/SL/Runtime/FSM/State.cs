using System.Collections.Generic;

namespace Arkayns.Reckon.SL {

    public class State {

        // -- Variables --
        private bool m_forceExit;
        private List<StateAction> m_fixedUpdateActions;
        private List<StateAction> m_updateActions;
        private List<StateAction> m_lateUpdateActions;

        public delegate void OnEnter();
        public OnEnter onEnter;
        
        // -- Constructor --
        public State(List<StateAction> fixedUpdateActions, List<StateAction> updateActions, List<StateAction> lateUpdateActions) {
            this.m_fixedUpdateActions = fixedUpdateActions;
            this.m_updateActions = updateActions;
            this.m_lateUpdateActions = lateUpdateActions;
        } // Constructor State

        // -- Methods --
        public void FixedTick () {
            ExecuteListOfActions (m_fixedUpdateActions);
        } // FixedTick ()

        public void Tick () {
            ExecuteListOfActions (m_updateActions);
            m_forceExit = false;
        } // Tick ()

        public void LateTick () {
            ExecuteListOfActions (m_lateUpdateActions);
        } // LateTick ()

        private void ExecuteListOfActions (List<StateAction> l) {
            foreach (var t in l) {
                if (m_forceExit) return;
                m_forceExit = t.Execute ();
            }
        } // ExecuteListOfActions ()

    } // Class State

} // Namespace Arkayns Reckon SL