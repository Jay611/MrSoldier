using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    //Where's the camera?
    public Transform cam;

    private void Start()
    {
        //Search for the soldier in case we forgot to put the soldier in unity
        cam = GameObject.Find("Soldier").transform;
    }
    void LateUpdate()
    {
        //Face the Health System UI towards the camera
        transform.LookAt(transform.position + cam.forward);
    }
}
