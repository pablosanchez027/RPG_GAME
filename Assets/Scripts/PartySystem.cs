﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.PartySystem
{
    [Serializable]
    public class PartySystem
    {
        [SerializeField]
        List<NPC> characters;

        public List<NPC> Characters
        {
            get => characters;
            set => characters = value;
        }

        public void InitLeader()
        {

            characters[0].IsLeader = true;
        }

        public void ChangeLeader()
        {
            NPC lastLeader = characters[0];
            lastLeader.IsLeader = false;
            characters.RemoveAt(0);
            characters.Add(lastLeader);
            InitLeader();
           
            lastLeader.CameraFollow1.enabled = false;

            for (int i=0;i<characters.Count;i++)
            {
                if(i>0)
                {
                    characters[i].TargetFollower = characters[i - 1].transform;
                    characters[i].Agent.enabled = true;
                }
            }

            characters[0].Agent.enabled = false;
            characters[0].CameraFollow1.enabled = true;
        }
    }
}
