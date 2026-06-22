using System;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private int currentScore { get; set; }

    public int CurrentScore => currentScore;

    private int MoldQuantity = 0;

    public static ScoreController Instance = null;

    #region Events
    public static Action<int> OnScoreIncrement;
    #endregion

    void Awake()
    {
        if (Instance) Destroy(Instance);
        else Instance = this;
    }

    public void IncrementScore(int value)
    {
        if (GameObject.FindAnyObjectByType<AudioController>())
            AudioController.Instance.CollectAudio();
        currentScore += value;
        MoldQuantity++;
        OnScoreIncrement?.Invoke(CurrentScore);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Points", CurrentScore);
        PlayerPrefs.SetInt("Molds", MoldQuantity);
    }

}
