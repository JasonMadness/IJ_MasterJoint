using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _swingsKey = KeyCode.Space;
    [SerializeField] private KeyCode _catapultFireKey = KeyCode.F;
    [SerializeField] private KeyCode _catapultReloadKey = KeyCode.R;

    public event Action SwingsKeyPressed;
    public event Action FireKeyPressed;
    public event Action ReloadKeyPressed; 

    private void Update()
    {
        if (Input.GetKeyDown(_swingsKey))
            SwingsKeyPressed?.Invoke();
        
        if (Input.GetKeyDown(_catapultFireKey))
            FireKeyPressed?.Invoke();
        
        if (Input.GetKeyDown(_catapultReloadKey))
            ReloadKeyPressed?.Invoke();
    }
}
