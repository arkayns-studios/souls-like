using System.Collections.Generic;
using UnityEngine;

namespace Arkayns.Reckon.SL {

    public abstract class StateManager : MonoBehaviour {

        // -- Variables --
        private State m_currentState;
        private Dictionary<string, State> m_allStates = new ();

        [HideInInspector]
        public Transform mTransform;

        // -- Built-In Methods --
        private void Start () {
            mTransform = this.transform;
            Init ();
        } // Start ()

        // -- Methods --
        public abstract void Init ();

        public void FixedTick () {
            if (m_currentState == null)return;
            m_currentState.FixedTick ();
        } // FixedTick ()

        public void Tick () {
            if (m_currentState == null)return;
            m_currentState.Tick ();
        } // Tick ()

        public void LateTick () {
            if (m_currentState == null) return;
            m_currentState.LateTick ();
        } // LateTick ()

        public void ChangeState (string targetID) {
            if (m_currentState != null) {
                // run on exit actions of m_currentState
            }

            var targetState = GetState (targetID);
            // run on enter actions
            m_currentState = targetState;
            m_currentState.onEnter?.Invoke();
        } // ChangeState ()

        private State GetState (string targetID) {
            m_allStates.TryGetValue (targetID, out State retVal);
            return retVal;
        } // GetState ()

        protected void RegisterState (string stateID, State state) {
            m_allStates.Add (stateID, state);
        } // RegisterState ()

    } // Abstract Class StateManager

} // Namespace Arkayns Reckon SL