using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastManager : MonoBehaviour
{
    public MyInputAction myInputAction;
    public Camera cam;
    public GameObject ball_PF_outline;
    public GameObject info;

    private void Start()
    {
    }


    private void Update()
    {
        RaycastTarget();
    }

    private void RaycastTarget()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(myInputAction.PointerPos);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name.Equals("Ball_PF"))
            {
                ball_PF_outline.SetActive(true);

                if(myInputAction.IsClicked)
                    info.SetActive(true);
            }
            else
            {
                ball_PF_outline.SetActive(false);
            }
            //print(hit.collider.name);
        }

    }
}
