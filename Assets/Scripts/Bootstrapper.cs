using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Swings _swings;
    [SerializeField] private Catapult _catapult;

    private void OnEnable()
    {
        _input.SwingsKeyPressed += _swings.ToggleMotor;
        _input.FireKeyPressed += _catapult.Fire;
        _input.ReloadKeyPressed += _catapult.Reload;
    }

    private void OnDisable()
    {
        _input.SwingsKeyPressed -= _swings.ToggleMotor;
        _input.FireKeyPressed -= _catapult.Fire;
        _input.ReloadKeyPressed -= _catapult.Reload;
    }
}