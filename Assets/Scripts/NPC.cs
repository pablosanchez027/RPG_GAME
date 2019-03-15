using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Movement.Sys3D;
using UnityEngine.AI;
using Cinemachine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    protected bool isPartner;
    [SerializeField]
    private bool isLeader;

    [SerializeField, Range(0f, 10f)]
    float moveSpeed = 0f;

    protected Animator anim;

    [SerializeField] Transform targetFollower;
    [SerializeField] NavMeshAgent agent;

    [SerializeField] CinemachineVirtualCamera CameraFollow;

    public bool IsLeader { get => isLeader;
        set => isLeader = value; }
    public Transform TargetFollower { get => targetFollower;
        set => targetFollower = value; }
    public CinemachineVirtualCamera CameraFollow1 { get => CameraFollow;
        set => CameraFollow = value; }
    public NavMeshAgent Agent { get => agent;
        set => agent = value; }

    void Start()
    {
        
    }

    protected void Update()
    {
        if (isPartner)
        {
            if (isLeader)
            {
                LeaderBehavior();
            }
            else
            {
                PartnerBehavior();
            }
        }
        else
        {
            NPCBehavior();
        }
    }

    void LeaderBehavior()
    {
        anim.SetFloat("move", Mathf.Abs(Movement3D.Axis.magnitude));

        Movement3D.MoveFacing(transform, moveSpeed);
    }

    void PartnerBehavior()
    {
        //Look at follower
        transform.LookAt(targetFollower);

        //Follow Player
        agent.SetDestination(targetFollower.position);

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    anim.SetFloat("move", 1);
                }
            }
        }

        else
        {
            anim.SetFloat("move", 0);
        }
        //Triggers Animation
        //anim.SetFloat("move", 1);
    }

    void NPCBehavior()
    {

    }
}
