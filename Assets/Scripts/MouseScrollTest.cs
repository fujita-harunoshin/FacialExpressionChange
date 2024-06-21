using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScrollTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.F1) || Input.GetKey(KeyCode.F2) || Input.GetKey(KeyCode.F3))
        {
            Debug.Log("Key held down: " + (Input.GetKey(KeyCode.F1) ? "F1" : Input.GetKey(KeyCode.F2) ? "F2" : "F3"));
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Debug.Log("Mouse ScrollWheel value: " + scroll);
        }
    }
}
