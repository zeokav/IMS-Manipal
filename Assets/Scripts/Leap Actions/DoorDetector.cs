using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorDetector : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Changing level");
            SceneManager.LoadScene("Interior");
        }
    }
}
