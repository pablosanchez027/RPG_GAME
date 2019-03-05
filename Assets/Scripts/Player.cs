using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Movement.Sys3D;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)]
    float moveSpeed = 0f;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("move", Mathf.Abs(Movement3D.Axis.magnitude));

        Movement3D.MoveFacing(transform, moveSpeed);
    }
}
