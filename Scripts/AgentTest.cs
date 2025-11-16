using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentTest : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField]
    private Transform player;

    void Awake()
    {
        this.agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        this.agent.SetDestination(player.position);
    }
}
