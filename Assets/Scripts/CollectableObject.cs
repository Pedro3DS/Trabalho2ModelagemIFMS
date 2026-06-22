using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    [SerializeField] private int collectableValue;

    public int CollectableValue => collectableValue;

    void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        if(GameObject.FindAnyObjectByType(typeof(ScoreController)))
            ScoreController.Instance.IncrementScore(CollectableValue);

        Destroy(this.gameObject);

    }
}
