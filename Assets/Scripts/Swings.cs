using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class Swings : MonoBehaviour
{
    [SerializeField] private float _motorForce;
    [SerializeField] private float _targetVelocity = 10f;
    [SerializeField] private float _frequency;

    private HingeJoint _joint;
    private JointMotor _motor;
    private float _elapsedTime;
    private int _direction = 1;

    private void Awake()
    {
        _joint = GetComponent<HingeJoint>();
        _motor.targetVelocity = _targetVelocity;
        SetMotorForce(_motorForce);
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
            }
            
            SetMotorForce(_motorForce * _direction);
            Debug.Log("force set to: " + _direction);
            Debug.Log("joint.motor.force after assign: " + _joint.motor.force);
        }
    }

    private void SetMotorForce(float force)
    {
        JointMotor newMotor = _joint.motor;
        newMotor.force = force;
        newMotor.targetVelocity = _targetVelocity;
        _joint.motor = newMotor;
    }
}
