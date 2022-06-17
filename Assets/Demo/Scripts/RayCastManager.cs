using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class RayCastManager : MonoBehaviour
{
    [Serializable]
    public class OutlineObj
    {
        public GameObject origin;
        public GameObject outline;
        public UnityEvent events = new UnityEvent();
    }

    [SerializeField] private MyInputAction myInputAction;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject info;
    [SerializeField] private Text hitbox;

    public OutlineObj[] outlineObjs;
    private string hitObjName = string.Empty;
    private bool isHit = false;
    //private string[] hitObjName;

    //private void Start()
    //{
    //    hitObjName = new string[outlineObjs.Length];

    //    for (int i = 0; i < hitObjName.Length; i++)
    //        hitObjName[i] = outlineObjs[i].origin.name;
    //}

    private void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(myInputAction.PointerPos);
        if (Physics.Raycast(ray, out hit))
        {
            hitbox.text = hit.collider.name;
            hitObjName = hit.collider.name;
            var index = HitObject(hit.collider.name);
            if (index.Equals(-1))
            {
                isHit = false;
                foreach (var i in outlineObjs)
                    if(i.outline.activeSelf)
                        i.outline.SetActive(false);
            }
            else
            {
                isHit = true;
                if (!outlineObjs[index].outline.activeSelf)
                    outlineObjs[index].outline.SetActive(true);
            }
        }
        else
        {
            print("non");
        }
    }


    private int HitObject(string _hitName)
    {
        for (int i = 0; i < outlineObjs.Length; i++)
        {
            if (_hitName.Equals(outlineObjs[i].origin.name))
                return i;
        }
        return -1;
    }


    public void OpenUI()
    {
        if (!isHit)
            return;

        var index = HitObject(hitObjName);
        outlineObjs[index].events.Invoke();
    }
}
