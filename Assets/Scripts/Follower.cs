using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class Follower : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)]
    float moveSpeed = 0f;
    [SerializeField] Transform targetFollower;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Player player;

    [SerializeField] CinemachineVirtualCamera Follow;
    Animator anim;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(targetFollower.position);

        if (Input.GetButtonDown("Jump"))
        {
            agent.enabled = !agent.enabled;

            player.enabled = !agent.enabled;

            Follow.enabled = !Follow.enabled;
        }
    }
}
