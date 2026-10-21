using System;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class Swings : MonoBehaviour
{
    [SerializeField] private float _motorForce;
    [SerializeField] private float _frequency;

    private HingeJoint _joint;
    private JointMotor _motor = new();
    private float _defaultTargetVelocity = 10f;
    private float _elapsedTime; 

    private void Awake()
    {
        _joint = GetComponent<HingeJoint>();
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
                _elapsedTime = -_frequency;

            int sing = Math.Sign(_elapsedTime);
            Debug.Log("Elaps: " + _elapsedTime);
            Debug.Log(sing);
            
            SetMotorForce(_motorForce * sing);
            Debug.Log("force:" + _joint.motor.force);
        }
    }

    private void SetMotorForce(float force)
    {
        _motor.force = force;
        _motor.targetVelocity = _defaultTargetVelocity;
        _joint.motor = _motor;
    }
}
