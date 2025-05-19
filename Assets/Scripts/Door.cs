using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject textG;
    public Player player;
    private void OnTriggerStay(Collider other)
    {
        textG.SetActive(true);
        if (!player.hasKey)
        {
            text.text = "You need a key!";
        }
        else
        {
            textG.SetActive(true);
            SceneManager.LoadScene("Result");
        }
    }

    private void OnTriggerExit(Collider other) {
        textG.SetActive(false);
    }
}
