using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    public string sceneToChange;
    void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        if(GameObject.FindAnyObjectByType<ScoreController>())
        ScoreController.Instance.SaveData();
        if(GameObject.FindAnyObjectByType<ScenesController>())
        ScenesController.Instance.ChangeScene(sceneToChange);
    }
}
