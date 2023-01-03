using UnityEngine;

namespace Arkayns.Reckon.SL {

    public abstract class CharacterStateManager : StateManager {

        // -- Variables --
        [Header("References")] public Animator animator;
        public new Rigidbody rigidbody;
        public AnimatorHook animHook;

        [Header("States")] public bool isGrounded;
        public bool useRootMotion;

        [Header("Controller Values")] [Range(-1, 1)]
        public float vertical;

        [Range(-1, 1)] public float horizontal;
        public bool lockOn;
        public float delta;
        public Vector3 rootMovement;
        private static readonly int IsInteracting = Animator.StringToHash("isInteracting");

        // -- Methods --
        public override void Init() {
            animator = GetComponentInChildren<Animator>();
            animHook = GetComponentInChildren<AnimatorHook>();
            rigidbody = GetComponentInChildren<Rigidbody>();
            animator.applyRootMotion = false;
            animHook.Init(this);
        } // Init ()

        public void PlayTargetAnimation(string targetAnim, bool isInteracting) {
            animator.SetBool(IsInteracting, isInteracting);
            animator.CrossFade(targetAnim, 0.2f);
        } // PlayTargetAnimation ()

    } // Abstract Class CharacterStateManager

} // Namespace Arkayns Reckon LS