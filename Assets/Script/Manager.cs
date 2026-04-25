using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public TMP_Text NamaText;
    public GameObject panel;

    public void LoadScene(string NamaScene)
    {
        SceneManager.LoadScene(NamaScene);
    }

    public void SetNamaPanel(string NamaPanel)
    {
        NamaText.SetText(NamaPanel);
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    public void exit()
    {
        Application.Quit();
    }
}