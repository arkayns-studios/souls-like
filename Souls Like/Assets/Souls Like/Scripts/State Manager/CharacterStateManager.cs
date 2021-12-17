using UnityEngine;

namespace Arkayns.SL {
    public abstract class CharacterStateManager : StateManager {

        [Header("References")]
        public Animator animator;
        public new Rigidbody rigidbody;

        [Header ("Controller Values")]
        [Range (-1, 1)] public float vertical;
        [Range (-1, 1)] public float horizontal;
        public bool lockOn;
        public float delta;

        public override void Init () {
            animator = GetComponentInChildren<Animator> ();
            rigidbody = GetComponentInChildren<Rigidbody> ();
            animator.applyRootMotion = false;
        } // Override Init

        public void PlayTargetAnimation (string targetAnim) {
            animator.CrossFade (targetAnim, 0.2f);
        } // PlayTargetAnimation

    } // Abstract Class CharacterStateManager

} // Namespace Arkayns LS