using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Script.EnvironmentInteraction
{
    public class EnvironmentInteractionContext
    {
        [SerializeField] private TwoBoneIKConstraint _leftIkConstraint;
        [SerializeField] private TwoBoneIKConstraint _rightIkConstraint;
        [SerializeField] private TwoBoneIKConstraint _leftMultiRotationConstraint;
        [SerializeField] private TwoBoneIKConstraint _rightMultiRotationConstraint;
        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private CapsuleCollider _rootCollider;

        public EnvironmentInteractionContext(TwoBoneIKConstraint leftIkConstraint, TwoBoneIKConstraint rightIkConstraint, TwoBoneIKConstraint leftMultiRotationConstraint, TwoBoneIKConstraint rightMultiRotationConstraint, Rigidbody rigidBody, CapsuleCollider rootCollider)
        {
            _leftIkConstraint = leftIkConstraint;
            _rightIkConstraint = rightIkConstraint;
            _leftMultiRotationConstraint = leftMultiRotationConstraint;
            _rightMultiRotationConstraint = rightMultiRotationConstraint;
            _rigidBody = rigidBody;
            _rootCollider = rootCollider;
        }

        public CapsuleCollider RootCollider => _rootCollider;

        public Rigidbody Rb => _rigidBody;

        public TwoBoneIKConstraint RightMultiRotationConstraint => _rightMultiRotationConstraint;

        public TwoBoneIKConstraint LeftMultiRotationConstraint => _leftMultiRotationConstraint;

        public TwoBoneIKConstraint RightIkConstraint => _rightIkConstraint;

        public TwoBoneIKConstraint LeftIkConstraint => _leftIkConstraint;
    }
}