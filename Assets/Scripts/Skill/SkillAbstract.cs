﻿using System.Collections.Generic;
using Loader;
using Player;
using UnityEngine;


namespace Skill
{
    public abstract class SkillAbstract: ScriptableObject
    {
        public string skillName;
        public string skillDescription;
        public float skillCooldown;
        public AudioClip skillSound;
        public PlayerStats playerStats;
        public List<string> upgradeable = new List<string>();
        protected virtual void Awake()
        {
            playerStats = GameAssetsLoader.Singleton.so_PlayerStats;
        }

        protected virtual void Start()
        {
            
        }


        public abstract bool PrepareSkill();
        public abstract void TriggerSkill();
        public abstract void UpgradeSkill(string args);
    }
}
