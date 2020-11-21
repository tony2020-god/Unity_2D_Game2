using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject GameDescriptionImage;
    public void StartGame()
    {
        SceneManager.LoadScene("關卡1");
    }
    public void GameDescription()
    {
        GameDescriptionImage.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void CloseDescription()
    {
        GameDescriptionImage.SetActive(false);
    }
}
