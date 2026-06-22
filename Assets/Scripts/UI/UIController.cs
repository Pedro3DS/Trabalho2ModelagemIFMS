using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text PointsText;

    #region Actions
    
    
    void OnEnable()
    {
        ScoreController.OnScoreIncrement += UpdateScoreText;
    }
    void OnDisable()
    {
        ScoreController.OnScoreIncrement -= UpdateScoreText;
    }
    #endregion

    private void UpdateScoreText(int value) => PointsText.text = value.ToString();
}
