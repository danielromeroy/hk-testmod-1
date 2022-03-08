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
            
            Log("Preloaded obects:");
            Log(preloadedObjects["Crossroads_08"]["Infected Parent/Spitting Zombie"]);
            //Log(preloadedObjects["Scenes"]["knight"]);

            Instance = this;

            Log("Initialized.");

            GameObjects.Add("aspid", preloadedObjects["Crossroads_08"]["Infected Parent/Spitting Zombie"]);

            ModHooks.HeroUpdateHook += OnHeroUpdate;

    }

        public void OnHeroUpdate()
        {
            var knight_transform = HeroController.instance.transform;
            var enemy = GameObjects["aspid"];
            GameObject newEnemy;

            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                Log("Instantiating object at position " + knight_transform.GetPositionX() + ", " + knight_transform.GetPositionY());
                newEnemy = UnityEngine.Object.Instantiate(enemy);
                GameObject.Destroy(newEnemy.GetComponent<EnemyDreamnailReaction>());
                newEnemy.SetActive(true);
                newEnemy.transform.SetPosition2D(knight_transform.GetPositionX(), knight_transform.GetPositionY());
            }

            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                Log("X:");
                Log(knight_transform.GetPositionX());
                Log("Y:");
                Log(knight_transform.GetPositionY());
            }
        }

        public override List<(string, string)> GetPreloadNames()
        {
            return new List<(string, string)>
            {
                ("Crossroads_08", "Infected Parent/Spitting Zombie"),
                //("Scenes", "knight")
            };
        }
    }
}