using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject option;
    public GameObject credits;
    public void StartButton() {
        SceneManager.LoadScene("Game");
    }

    public void OptionsButton() {
        credits.SetActive(false);
        if (option.activeSelf) {
            option.SetActive(true);
        }
        else {
            option.SetActive(false);
        }
    }

    public void CreditsButton() {
        option.SetActive(true);
        if (credits.activeSelf) {
            credits.SetActive(true);
        }
        else {
            credits.SetActive(false);
        }
    } 

    public void ExitButton() {
        Application.Quit();
    }
}
