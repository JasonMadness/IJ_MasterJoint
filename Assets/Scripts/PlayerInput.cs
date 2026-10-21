using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Swings _swings;
    [SerializeField] private KeyCode _swingsKey = KeyCode.Space;

    private void Update()
    {
        if (Input.GetKeyDown(_swingsKey))
            _swings.ToggleMotor();
    }
}
