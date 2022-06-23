using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyInputAction : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform pointer;

    public Vector3 PointerPos { get => pointerPos; }
    public bool IsPressed { get => isPressed; }
    public bool IsTap { get => isTap; }

    private float speedOffset = .1f;
    private bool isTap = false;
    private bool isPressed = false;
    private Vector2 movement;
    private Vector2 inputLook;
    private Vector2 pointerPos;
    private float rotx, roty;

    private void Update()
    {
        var pos = new Vector3(movement.x, 0, movement.y);
        pos *= speedOffset;
        transform.Translate(pos, Space.Self);

        //if (!isPressed)
        //    return;

        float x = -rotx * Time.deltaTime * 7;
        float y = -roty * Time.deltaTime * 7;

        Rotation(x, y);
    }




    public void OnTap(InputAction.CallbackContext _context)
    {
        var input = _context.ReadValueAsButton();
        isTap = input;
    }
    public void OnPressed(InputAction.CallbackContext _context)
    {
        var input = _context.ReadValueAsButton();
        isPressed = input;

        if (pointer != null)
            RaycastTarget();
    }
    public void OnPointerMove(InputAction.CallbackContext _context)
    {
        var input = _context.ReadValue<Vector2>();
        pointerPos = input;
    }

    public void OnRotationX(InputAction.CallbackContext Context)
    {
        rotx = Context.ReadValue<float>();
    }

    public void OnRotationY(InputAction.CallbackContext Context)
    {
        roty = Context.ReadValue<float>();
    }


    public void OnPressedWASD(InputAction.CallbackContext _context)
    {
        var input = _context.ReadValue<Vector2>();
        movement = input;
    }

    public void OnLook(InputAction.CallbackContext value)
    {
        inputLook = value.ReadValue<Vector2>();
        rotx = inputLook.x;
        roty = inputLook.y;
    }


    private void RaycastTarget()
    {
        Ray ray = cam.ScreenPointToRay(pointerPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            pointer.transform.position = hit.point;
        }
    }

    private void Rotation(float posx, float posy)
    {
        cam.transform.Rotate(new Vector3(posy, -posx, 0));
        var rx = Mathf.Repeat(cam.transform.eulerAngles.x + 180, 360) - 180;
        var ry = cam.transform.eulerAngles.y;
        rx = Mathf.Clamp(rx, -80, 80);
        cam.transform.rotation = Quaternion.Euler(rx, ry, 0);
    }
}