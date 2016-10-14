using UnityEngine;
using System.Collections;

public class FingerAction : MonoBehaviour {

    public TextMesh hud;

    public void addText ()
    {
        hud.text = "Hello";   
    }

    public void remText()
    {
        hud.text = "Bye";
    }
}
