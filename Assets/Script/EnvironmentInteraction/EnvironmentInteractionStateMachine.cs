using System;
using Script.EnvironmentInteraction;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Assertions;

[RequireComponent(typeof(TwoBoneIKConstraint))]
public class EnvironmentInteractionStateMachine : StateManager<EnvironmentInteractionStateMachine.EEnvironmentInteractionState>
{
    public enum EEnvironmentInteractionState
    {
        Search,
        Approach,
        Rise,
        Touch,
        Reset
    }

    private EnvironmentInteractionContext _context;
    
    [SerializeField] private TwoBoneIKConstraint _leftIkConstraint;
    [SerializeField] private TwoBoneIKConstraint _rightIkConstraint;
    [SerializeField] private TwoBoneIKConstraint _leftMultiRotationConstraint;
    [SerializeField] private TwoBoneIKConstraint _rightMultiRotationConstraint;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private CapsuleCollider _rootCollider;

    private void Awake()
    {
        ValidateConstraints();

        _context = new EnvironmentInteractionContext(_leftIkConstraint, _rightIkConstraint,
            _leftMultiRotationConstraint, _rightMultiRotationConstraint, _rigidBody,
            _rootCollider);
        InitializeState();
    }

    private void ValidateConstraints()
    {
        Assert.IsNotNull(_leftIkConstraint,"_leftIkConstraint is not Null");
        Assert.IsNotNull(_rightIkConstraint,"_rightIkConstraint is not Null");
        Assert.IsNotNull(_leftMultiRotationConstraint,"_leftMultiRotationConstraint is not Null");
        Assert.IsNotNull(_rightMultiRotationConstraint,"_rightMultiRotationConstraint is not Null");
        Assert.IsNotNull(_rigidBody,"_rigid body is not Null");
        Assert.IsNotNull(_rootCollider,"_rootCollider is not Null");
    }

    private void InitializeState()
    {
        States.Add(EEnvironmentInteractionState.Reset,new ResetState(_context,EEnvironmentInteractionState.Reset));
        States.Add(EEnvironmentInteractionState.Approach,new ResetState(_context,EEnvironmentInteractionState.Approach));
        States.Add(EEnvironmentInteractionState.Rise,new ResetState(_context,EEnvironmentInteractionState.Rise));
        States.Add(EEnvironmentInteractionState.Search,new ResetState(_context,EEnvironmentInteractionState.Search));
        States.Add(EEnvironmentInteractionState.Touch,new ResetState(_context,EEnvironmentInteractionState.Touch));
        CurrentState = States[EEnvironmentInteractionState.Reset];
    }
}
