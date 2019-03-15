using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.PartySystem;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    PartySystem partySystem;

    private void Start()
    {
        partySystem.InitLeader();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            partySystem.ChangeLeader();
        }
    }
}
