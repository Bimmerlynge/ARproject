using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private UserActionsGen _actions;

    public delegate void ClickAction(Vector3 position);
    public static event ClickAction OnClick;

    private void OnEnable()
    {
        _actions = new UserActionsGen();
        _actions.Enable();

        _actions.Touch.Enable();
        _actions.Touch.Position.performed += Click;
    }

    private void OnDisable()
    {
        _actions.Touch.Position.performed -= Click;
        _actions.Disable();
    }

    private void Click(InputAction.CallbackContext callbackContext)
    {
        var touch = callbackContext.ReadValue<Vector2>();
        OnClick?.Invoke(touch);
    }
}
