using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Lock : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Locks camera rotation so that i doesn't spin with player
        GetComponent<Transform>().eulerAngles = new Vector3(0f, 0f, 0f);
    }
}
