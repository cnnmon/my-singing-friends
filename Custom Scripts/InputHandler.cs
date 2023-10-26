using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public PeopleManager manager;
    private Camera _mainCamera;

    // Start is called before the first frame update
    void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext c)
    {
        if (c.started) {
            OnClick();
        } else if (c.canceled) {
            OffClick();
        }
    }

    private void OnClick() {
        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (rayHit.collider == null) {
            return;
        }

        var personDisplay = rayHit.collider.GetComponent<PersonDisplay>();
        if (personDisplay != null) {
            manager.setActive(personDisplay);
        }
    }

    private void OffClick() {
        manager.unsetActive();
    }
}
