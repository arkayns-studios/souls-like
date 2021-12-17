using System.Collections.Generic;
using UnityEngine;

namespace Arkayns.SL {

    public class State {

        private bool forceExit;
        private List<StateAction> fixedUpdateActions;
        private List<StateAction> updateActions;
        private List<StateAction> lateUpdateActions;

        public State(List<StateAction> fixedUpdateActions, List<StateAction> updateActions, List<StateAction> lateUpdateActions) {
            this.fixedUpdateActions = fixedUpdateActions;
            this.updateActions = updateActions;
            this.lateUpdateActions = lateUpdateActions;
        } // Constructor State

        public void FixedTick () {
            ExecutListOfActions (fixedUpdateActions);
        } // FixedTick

        public void Tick () {
            ExecutListOfActions (updateActions);
            forceExit = false;
        } // Tick

        public void LateTick () {
            ExecutListOfActions (lateUpdateActions);
        } // LateTick

        private void ExecutListOfActions (List<StateAction> l) {
            for (int i = 0; i < l.Count; i++) {
                if (forceExit) return;
                forceExit = l [i].Execute ();
            }
        } // ExecutListOfActions

    } // Class State

} // Namespace Arkayns SL