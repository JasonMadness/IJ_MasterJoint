using System.Collections;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] private Projectile _prefab;
    [SerializeField] private Rigidbody _armRigidbody;
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private float _projectileInstanceDelay = 1f;

    public void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }
    
    private IEnumerator ReloadCoroutine()
    {
        _springJoint.spring = 0f;
        _armRigidbody.WakeUp();
        yield return new WaitForSeconds(_projectileInstanceDelay);
        Instantiate(_prefab);
    }
}
