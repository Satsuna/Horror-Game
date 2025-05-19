using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    public float waypointReachedThreshold = 1f;
    public float ChaseSpeed = 6f;
    public float WanderSpeed = 2f;
    public EnemyVision enemyVision;
    void Update()
    {
        if (enemyVision.inChase == true)
        {
            Chase();
        }
        else
        {
            Wander();
        }
    }

    public void Wander()
    {
        agent.speed = WanderSpeed;
        if (waypoints.Length == 0) return;

        if (!agent.pathPending && agent.remainingDistance <= waypointReachedThreshold)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    public void Chase() {
        agent.speed = ChaseSpeed;
        agent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Result");
            PlayerPrefs.SetInt("Jumpscare", 1);
        }
    }
}
