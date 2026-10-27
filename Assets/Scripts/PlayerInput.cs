using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Swings _swings;
    [SerializeField] private KeyCode _swingsKey = KeyCode.Space;
    [SerializeField] private Catapult _catapult;
    [SerializeField] private KeyCode _catapultFireKey = KeyCode.F;
    [SerializeField] private KeyCode _catapultReloadKey = KeyCode.R;

    private void Update()
    {
        if (Input.GetKeyDown(_swingsKey))
            _swings.ToggleMotor();
        
        if (Input.GetKeyDown(_catapultFireKey))
            _catapult.Fire();
        
        if (Input.GetKeyDown(_catapultReloadKey))
            _catapult.Reload();
    }
}
