using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public PlayableDirector jumpscare;
    public TextMeshProUGUI result;
    public GameObject canvas;
    private IEnumerator coroutine;
    public AudioSource jumpscareSfx;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        if (PlayerPrefs.HasKey("Jumpscare"))
        {
            jumpscareSfx.Play();
            canvas.SetActive(false);
            jumpscare.Play();
            PlayerPrefs.DeleteKey("Jumpscare");
            coroutine = Wait(1.5f);
            StartCoroutine(coroutine);
        }
        else
        {
            canvas.SetActive(true);
            result.text = "You Escaped!";
        }
    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canvas.SetActive(true);
        result.text = "You Died!";
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
