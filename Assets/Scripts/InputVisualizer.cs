using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputVisualizer : MonoBehaviour
{
    public Text f1Text;
    public Text f2Text;
    public Text f3Text;
    public Text scrollText;

    private float NotScrollTime = 0;

    void Update()
    {
        // F1 Key
        if (Input.GetKey(KeyCode.F1))
        {
            f1Text.text = "F1 Hold";
        }
        else if (Input.GetKeyUp(KeyCode.F1))
        {
            f1Text.text = "F1";
        }

        // F2 Key
        if (Input.GetKey(KeyCode.F2))
        {
            f2Text.text = "F2 Hold";
        }
        else if (Input.GetKeyUp(KeyCode.F2))
        {
            f2Text.text = "F2";
        }

        // F3 Key
        if (Input.GetKey(KeyCode.F3))
        {
            f3Text.text = "F3 Hold";
        }
        else if (Input.GetKeyUp(KeyCode.F3))
        {
            f3Text.text = "F3";
        }

        // Mouse Scroll
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            NotScrollTime = 0;
            scrollText.text = "Scroll: " + scroll;
        }
        else if (NotScrollTime > 0.3)
        {
            scrollText.text = "Scroll";
        }
        else
        {
            NotScrollTime += Time.deltaTime;
        }

    }
}
