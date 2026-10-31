using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private Rigidbody _armRigidbody;
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private Loader _loader;
    [SerializeField] private float _fireSpring = 35f;

    private bool _loaded = true;
    
    public void Fire()
    {
        if (_loaded == false)
            return;
        
        _springJoint.spring = _fireSpring;
        _armRigidbody.WakeUp();
        _loaded = false;
    }

    public void Reload()
    {
        if (_loaded)
            return;
        
        _loader.Reload();
        _loaded = true;
    }
}
