using System.Collections.Generic;
using UnityEngine;

namespace Arkayns.SL {

    public abstract class StateManager : MonoBehaviour {

        private State currentState;
        private Dictionary<string, State> allStates = new Dictionary<string, State> ();

        [HideInInspector]
        public Transform mTransform;

        private void Start () {
            mTransform = this.transform;

            Init ();
        } // Start

        public abstract void Init ();

        public void FixedTick () {
            if (currentState == null)return;
            currentState.FixedTick ();
        } // FixedTick

        public void Tick () {
            if (currentState == null)return;
            currentState.Tick ();
        } // Tick

        public void LateTick () {
            if (currentState == null) return;
            currentState.LateTick ();
        } // LateTick

        public void ChangeState (string targetID) {
            if (currentState != null) {
                // run on exit actions of currentState
            }

            State targetState = GetState (targetID);
            // run on enter actions
            currentState = targetState;
        } // ChangeState

        private State GetState (string targetID) {
            allStates.TryGetValue (targetID, out State retVal);
            return retVal;
        } // GetState

        protected void RegisterState (string stateID, State state) {
            allStates.Add (stateID, state);
        } // RegisterState

    } // Abstract Class StateManager

} // Namespace Arkayns SL