using System.Collections;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Rigidbody _armRigidbody;
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private float _fireForce = 35f;
    [SerializeField] private float _projectileInstanceDelay = 1f;
    
    public void Fire()
    {
        _springJoint.spring = _fireForce;
        _armRigidbody.WakeUp();
    }

    public void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        _springJoint.spring = 0f;
        _armRigidbody.WakeUp();
        yield return new WaitForSeconds(_projectileInstanceDelay);
        Instantiate(_projectilePrefab);
    }
}
