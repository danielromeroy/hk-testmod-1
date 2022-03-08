using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace TestingMod_1
{
    public class TestingMod_1 : Mod
    {
        internal static TestingMod_1 Instance;

        public static readonly Dictionary<string, GameObject> GameObjects = new Dictionary<string, GameObject>();
        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            
            Log("Initializing...");

            Log("Hi");
            Log(preloadedObjects["GG_Hornet_2"]["Boss Holder/Hornet Boss 2"]);

            Instance = this;

            Log("Initialized.");

            GameObjects.Add("hornet", preloadedObjects["GG_Hornet_2"]["Boss Holder/Hornet Boss 2"]);

            ModHooks.HeroUpdateHook += OnHeroUpdate;
    }

        public void OnHeroUpdate()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Log("Trying to instantiate hornet");
                var hornet = UnityEngine.Object.Instantiate(GameObjects["hornet"]);
                var knight_pos = HeroController.FindObjectOfType<Transform>();
                hornet.transform.SetPosition2D(knight_pos.GetPositionX(), knight_pos.GetPositionY());
                hornet.SetActive(true);
            }
        }

        public override List<(string, string)> GetPreloadNames()
        {
            return new List<(string, string)>
            {
                ("GG_Hornet_2", "Boss Holder/Hornet Boss 2"),
                ("Cliffs_01","Cornifer Card")
            };
        }

        public void LogPreloadedObjects()
        {
            var preloaded = GetPreloadNames();
            Log(preloaded);

        }
    }
}