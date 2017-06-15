using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

    /// <summary>
    /// Manages opening and closing of doors
    /// </summary>

    // INSPECTOR SETTINGS
    [Header("Door Settings")]
    [Tooltip("The initial angle of the door/window.")]
    public float InitialAngle = 0.0F;
    [Tooltip("The amount of degrees the door/window rotates.")]
    public float RotationAngle = 90.0F;

    //PUBLIC VARIABLES
    public float Speed = 1;

    //PRIVATE VARIABLES
    private Quaternion InitialRot, FinalRot;

    private bool Running = false;

    private int State;

	void Start ()
    {
        InitialRot = Quaternion.Euler(0, -InitialAngle, 0);
        FinalRot = Quaternion.Euler(0, -InitialAngle - RotationAngle, 0);
    }
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position)<3)
        {
            StartCoroutine(OpenDoor());
        }
	}

    IEnumerator OpenDoor()
    {
        if (!Running)
        {
            //Change state from 1 to 0 and back (= alternate between FinalRot and InitialRot).
            if (gameObject.transform.rotation == (State == 0 ? FinalRot : InitialRot))
            {
                State ^= 1;
            }

            //Set 'FinalRotation' to 'FinalRot' when moving and to 'InitialRot' when moving back.
            Quaternion FinalRotation = ((State == 0) ? FinalRot : InitialRot);

            //Make the door/window rotate until it is fully opened/closed.
            while (Mathf.Abs(Quaternion.Angle(FinalRotation, gameObject.transform.rotation)) > 0.01f)
            {
                Running = true;
                gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, FinalRotation, Time.deltaTime * Speed);

                yield return new WaitForEndOfFrame();
            }

            Running = false;
        }
    }
}
