using UnityEngine;
using System.Collections;

public class DoorTouchAction : MonoBehaviour {

    public void onTouch ()
    {
        Debug.Log("Item was touched");
    }

    public void onRemTouch()
    {
        Debug.Log("Touch was removed");
    }
}
