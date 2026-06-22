using TMPro;
using UnityEngine;

public class EndSceneUiController : MonoBehaviour
{
    [SerializeField] private TMP_Text MoldsText;
    [SerializeField] private TMP_Text PointsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        MoldsText.text = $"{PlayerPrefs.GetInt("Molds")} Mofinhos Coletados";
        PointsText.text = $"{PlayerPrefs.GetInt("Points")} Pontos";
    }

    
}
