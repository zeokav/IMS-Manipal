using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("VRMainMenu");
           // SceneManager.LoadScene(0);              //load the main menu
        }
	}

   
}
