using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public static ScenesController Instance = null;

    void Awake()
    {
        if(Instance) Destroy(Instance);
        else Instance = this;
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
