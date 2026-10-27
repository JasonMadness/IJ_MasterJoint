using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private Rigidbody _armRigidbody;
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private float _fireForce = 35f;
    
    public void Fire()
    {
        _springJoint.spring = _fireForce;
        _armRigidbody.WakeUp();
    }

    public void Reload()
    {
        
    }
}
