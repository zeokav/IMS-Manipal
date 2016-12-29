using UnityEngine;
using System.Collections;

public class TopDownController : MonoBehaviour {

    /// <summary>
    /// Controls the Top Down Camera
    /// </summary>

    [SerializeField]
    private float MoveSpeed;

    private bool up, down, left, right;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        GetInput();

        if (up)
        {
            transform.Translate(-1*transform.forward * MoveSpeed);
        }
        else if (left)
        {
            transform.Translate(-1 * transform.right * MoveSpeed);
        }
        else if (right)
        {
            transform.Translate(transform.right * MoveSpeed);
        }
        else if (down)
        {
            transform.Translate(transform.forward * MoveSpeed);
        }
    }

    private void GetInput()
    {
        up = Input.GetKey(KeyCode.W);
        down = Input.GetKey(KeyCode.S);
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
    }
}
