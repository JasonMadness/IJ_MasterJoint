using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class Swings : MonoBehaviour
{
    [SerializeField] private float _targetVelocity = 10f;
    [SerializeField] private float _frequency = 2f;
    [SerializeField] private float _initialPhaseOffset = 0.5f;

    private HingeJoint _joint;
    private int _direction = 1;
    private Coroutine _swingRoutine;

    private void Awake()
    {
        _joint = GetComponent<HingeJoint>();
        UpdateMotor();
    }

    public void ToggleMotor()
    {
        _joint.useMotor = !_joint.useMotor;

        if (_joint.useMotor)
        {
            _swingRoutine = StartCoroutine(SwingRoutine());
        }
        else if (_swingRoutine != null)
        {
            StopCoroutine(_swingRoutine);
            _swingRoutine = null;
        }
    }

    private IEnumerator SwingRoutine()
    {
        yield return new WaitForSeconds(_frequency * _initialPhaseOffset);

        while (_joint.useMotor)
        {
            _direction *= -1;
            UpdateMotor();
            yield return new WaitForSeconds(_frequency);
        }

        _swingRoutine = null;
    }

    private void UpdateMotor()
    {
        JointMotor motor = _joint.motor;
        motor.targetVelocity = _targetVelocity * _direction;
        _joint.motor = motor;
    }
}