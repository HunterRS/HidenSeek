using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{

    enum State { Walking, Waiting};
    private State state = State.Walking;

    public float waitTime = 5f;
    public float waitTicker = .02f;

    private NavMeshAgent agent;

    public Animator animator;

    private void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    public void GoToLocation()
    {
        agent.SetDestination(RandomNavmeshLocation(Random.Range(20f,100f)));
        //agent.SetDestination(GameManager.instance.locations[Random.Range(0, (GameManager.instance.locations.Count - 1))]);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Walking)
        {
            animator.SetBool("Speed", true);
        }
        else
        {
            animator.SetBool("Speed", false);
        }


        if (state == State.Walking)
        {
            if (agent.pathPending) return;

            if (agent.remainingDistance < .05f)
            {
                state = State.Waiting;
            }
        }
        else if (state == State.Waiting)
        {
            waitTime -= waitTicker;

            if (waitTime < 0)
            {
                GoToLocation();
                waitTime = 5f;
                state = State.Walking;
            }
        }
    }
    private void OnMouseDown()
    {
        Destroy(this.gameObject);
    }


    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
