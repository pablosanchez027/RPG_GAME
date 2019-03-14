using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using Core.Movement.Sys3D;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform targetFollower;
    [SerializeField] NavMeshAgent agent;

    [SerializeField] CinemachineVirtualCamera Follow;

    Animator anim;

    void Update()
    {
        agent.SetDestination(targetFollower.position);

        
        //anim.SetFloat("move", );


        if (Input.GetButtonDown("Jump"))
        {
            agent.enabled = !agent.enabled;

            Follow.enabled = !Follow.enabled;
        }
    }
}
