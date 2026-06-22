using UnityEngine;
using UnityEngine.InputSystem;

public class HelperTab : MonoBehaviour
{
    [SerializeField] private GameObject HelperButton;
    [SerializeField] private GameObject HelperTabImage;

    public bool isTabHidden = false;

    public void OnTab(InputAction.CallbackContext contex)
    {
        OpenCloseTab();
    }

    void Start()
    {
        OpenCloseTab();
    }

    private void OpenCloseTab()
    {
        if (isTabHidden)
        {
            HelperTabImage.SetActive(true);
            HelperButton.SetActive(false);
            isTabHidden = false;
        }
        else
        {
            HelperTabImage.SetActive(false);
            HelperButton.SetActive(true);
            isTabHidden = true;
        }
    }
}
