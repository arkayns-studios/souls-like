using System.Collections.Generic;
using UnityEngine;

namespace Arkayns.SL {

    public class State {

        private bool m_forceExit;
        private List<StateAction> m_fixedUpdateActions;
        private List<StateAction> m_updateActions;
        private List<StateAction> m_lateUpdateActions;

        public delegate void OnEnter();
        public OnEnter onEnter;
        
        public State(List<StateAction> fixedUpdateActions, List<StateAction> updateActions, List<StateAction> lateUpdateActions) {
            this.m_fixedUpdateActions = fixedUpdateActions;
            this.m_updateActions = updateActions;
            this.m_lateUpdateActions = lateUpdateActions;
        } // Constructor State

        public void FixedTick () {
            ExecuteListOfActions (m_fixedUpdateActions);
        } // FixedTick

        public void Tick () {
            ExecuteListOfActions (m_updateActions);
            m_forceExit = false;
        } // Tick

        public void LateTick () {
            ExecuteListOfActions (m_lateUpdateActions);
        } // LateTick

        private void ExecuteListOfActions (List<StateAction> l) {
            for (int i = 0; i < l.Count; i++) {
                if (m_forceExit) return;
                m_forceExit = l [i].Execute ();
            }
        } // ExecuteListOfActions

    } // Class State

} // Namespace Arkayns SL