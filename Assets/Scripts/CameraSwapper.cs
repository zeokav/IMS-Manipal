using UnityEngine;
using System.Collections;

public class CameraSwapper : MonoBehaviour {

    /// <summary>
    /// Checks for key presses from the keyboard and swaps between cameras
    /// C : OVRPlayer
    /// V : Fly Through Camera
    /// B : Top Down Camera
    /// 
    /// Currently mapped to the keyboard. Can be changed later.
    /// 
    /// </summary>

    [SerializeField]
    private GameObject OVRPlayer, FlyThrough, TopDown;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKeyDown(KeyCode.C))
        {
            OVRPlayer.SetActive(true);
            FlyThrough.SetActive(false);
            TopDown.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.V))
        {
            OVRPlayer.SetActive(false);
            FlyThrough.SetActive(true);
            TopDown.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.B))
        {
            OVRPlayer.SetActive(false);
            FlyThrough.SetActive(false);
            TopDown.SetActive(true);
        }
	}
}
