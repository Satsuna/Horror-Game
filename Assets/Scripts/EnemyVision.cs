using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public bool inChase = false;
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered");
            inChase = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Exit");
            inChase = false;
        }
    }
}
