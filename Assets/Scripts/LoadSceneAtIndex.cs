using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSceneAtIndex : MonoBehaviour {

    public void LoadThisScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
