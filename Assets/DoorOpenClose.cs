using UnityEngine;
using System.Collections;

public class DoorOpenClose : MonoBehaviour
{

    /// <summary>
    /// Script handles the opening and closing of doors
    /// </summary>

    private int CLOSED = 0, OPENNEG = -1, OPENPOS = 1;
    private int doorState;

    public float DoorOpenSpeed = 1;

    private void Start()
    {
        doorState = CLOSED;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Fire1") && doorState == CLOSED)
        {
            StartCoroutine(OpenDoor());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (doorState == OPENNEG)
        {
            StartCoroutine(CloseDoor());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(CloseDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        Quaternion wantedRotation = Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, -90);

        while (gameObject.transform.rotation.z < 90)
        {
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, wantedRotation, DoorOpenSpeed * Time.deltaTime);
            yield return null;
        }
        doorState = OPENNEG;
        gameObject.transform.rotation = wantedRotation;
        yield return null;
    }

    IEnumerator CloseDoor()
    {
        Quaternion wantedRotation = Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, 0);

        /* while (gameObject.transform.rotation.z < 90)
         {
             gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, wantedRotation, DoorOpenSpeed * Time.time);
             yield return null;
         }
         doorState = OPENNEG;*/

        print("Co routine called");

        gameObject.transform.rotation = wantedRotation;
        yield return null;
    }

}


/*
 
    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            print(other.transform.position);
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {

        print("door was asked to be closed");
        CloseDoor();
    }

    private void OpenDoor()
    {
        if(doorState == CLOSED)
            StartCoroutine(RotateImage());
    }

    private void CloseDoor()
    {
        if (doorState != CLOSED)
            StartCoroutine(CloseDoorCoroutine());
    }

    // Use this for initialization
    void Start () {
        doorState = CLOSED;
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    IEnumerator CloseDoorCoroutine()
    {
        print("door was asked to be closed");

        GameObject myObject = gameObject;
        float moveSpeed = 0.1f;
        float y = 180;

        Quaternion wantedRotation = Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, 0);


        myObject.transform.rotation = wantedRotation;
        yield return null;
    }

    IEnumerator RotateImage()
    {
        GameObject myObject = gameObject;
        float moveSpeed = 0.1f;
        float y = 180;

        Quaternion wantedRotation = Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, -90);

        while (myObject.transform.rotation.z < 90)
        {
            myObject.transform.rotation = Quaternion.Slerp(myObject.transform.rotation, wantedRotation, moveSpeed * Time.time);
            yield return null;
        }

        myObject.transform.rotation = wantedRotation;
        yield return null;
    }

     */
