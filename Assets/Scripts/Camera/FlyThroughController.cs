using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class FlyThroughController : MonoBehaviour {

    /// <summary>
    /// This script controls the gameobject which holds the Oculus Camera Rig
    /// For now it takes inputs from W,A,S,D and the mouse
    /// </summary>


    [SerializeField]
    private float MoveSpeed;

    private MouseLook mouseLook;
    private Camera m_camera;

    private bool forward, backward, left, right;    

	// Use this for initialization
	void Start () {
        m_camera = Camera.main;
        mouseLook = new MouseLook();
        mouseLook.Init(transform, m_camera.transform);
	}
	
	// Update is called once per frame
	void Update () {

        RotateView();
        GetInput();

        //Not sure why Vector3 works and transform.forward errs (?)

        if(forward)
        {
            transform.Translate(Vector3.forward * MoveSpeed);
        }
        else if(left)
        {
            transform.Translate(Vector3.left * MoveSpeed);
        }
        else if(right)
        {
            transform.Translate( Vector3.right * MoveSpeed);
        }
        else if(backward)
        {
            transform.Translate(Vector3.back * MoveSpeed);
        }
	}

    private void FixedUpdate()
    {
        mouseLook.UpdateCursorLock();
    }

    private void RotateView()
    {
        mouseLook.LookRotation(transform, m_camera.transform);
    }

    private void GetInput()
    {
        forward = Input.GetKey(KeyCode.W);
        backward = Input.GetKey(KeyCode.S);
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
    }
}
