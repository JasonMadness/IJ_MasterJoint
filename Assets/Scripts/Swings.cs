using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class Swings : MonoBehaviour
{
    [SerializeField] private float _motorForce = 10f;
    [SerializeField] private float _targetVelocity = 10f;
    [SerializeField] private float _frequency = 2f;
    [SerializeField] private float _initialPhaseOffset = 0.5f;

    private HingeJoint _joint;
    private float _elapsedTime;
    private int _direction = 1;

    private void Awake()
    {
        _joint = GetComponent<HingeJoint>();
        _elapsedTime = _frequency * _initialPhaseOffset;
        UpdateMotor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _joint.useMotor = !_joint.useMotor;
        }

        if (_joint.useMotor)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _frequency)
            {
                _elapsedTime -= _frequency;
                _direction *= -1;
                UpdateMotor();
            }
        }
    }

    public void ToggleMotor()
    {
        _joint.useMotor = !_joint.useMotor;
    }

    private void UpdateMotor()
    {
        JointMotor motor = _joint.motor;
        motor.targetVelocity = _targetVelocity * _direction;
        _joint.motor = motor;
    }
}