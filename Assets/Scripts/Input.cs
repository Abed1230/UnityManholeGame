using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour {

    public delegate void ButtonPressed();
    public static event ButtonPressed OnTopLeftPressed;
    public static event ButtonPressed OnTopRightPressed;
    public static event ButtonPressed OnBottomLeftPressed;
    public static event ButtonPressed OnBottomRightPressed;

    public int id;

    private void OnMouseDown()
    {
        if (OnTopLeftPressed != null && id == 0)
        {
            OnTopLeftPressed();
        }
        else if (OnTopRightPressed != null && id == 1)
        {
            OnTopRightPressed();
        }
        else if (OnBottomLeftPressed != null && id == 2)
        {
            OnBottomLeftPressed();
        }
        else if (OnBottomRightPressed != null && id == 3)
        {
            OnBottomRightPressed();
        }

    }
}
