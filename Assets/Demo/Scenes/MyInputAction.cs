using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyInputAction : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform pointer;

    private float speedOffset = .1f;
    private bool isClicked = false;
    private Vector2 movement;
    private Vector2 pointerPos;
    private float rotx, roty;

    float HorizontalSensitivity = 20.0f;
    float VerticalSensitivity = 20.0f;

    private void Update()
    {
        var pos = new Vector3(movement.x, 0, movement.y);
        pos *= speedOffset;
        transform.Translate(pos, Space.Self);

        if (!isClicked)
            return;

        float RotationX = HorizontalSensitivity * rotx * Time.deltaTime;
        float RotationY = VerticalSensitivity * roty * Time.deltaTime;
        Vector3 CameraRotation = cam.transform.rotation.eulerAngles;

        CameraRotation.x -= RotationY;
        CameraRotation.y += RotationX;

        cam.transform.rotation = Quaternion.Euler(CameraRotation);
    }



    public void OnClick(InputAction.CallbackContext _context)
    {
        var input = _context.ReadValueAsButton();
        //Debug.Log("OnClick: " + input);
        isClicked = input;
        RaycastTarget();
    }
    public void OnPointerMove(InputAction.CallbackContext _context)
    {
        var input = _context.ReadValue<Vector2>();
        pointerPos = input;
        //Debug.Log("OnMouseMove: " + input);
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
        //Debug.Log("OnPressedWASD: " + input);
    }


    private void RaycastTarget()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(pointerPos);
        if (Physics.Raycast(ray, out hit))
        {
            pointer.transform.position = hit.point;
        }

    }
}