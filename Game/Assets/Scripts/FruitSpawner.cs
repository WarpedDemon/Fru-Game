using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace fruit
{
    public class FruitSpawner : MonoBehaviour
    {
        public Text targetSpawned;
        public string SpawnerType;
        public Text TargetFruit;
        public GameObject fruitPrefab;
        public Transform[] spawnPoints;
        public Text OnScreen;
        public int fruit;
        public float minDelay = .1f;
        public float maxDelay = 1f;
        Fruit f;
        // Use this for initialization
        void Start()
        {
            StartCoroutine(SpawnFruits());
        }

        private void Update()
        {
            fruit = Int32.Parse(OnScreen.text);
        }

        IEnumerator SpawnFruits()
        {
            while (true)
            {
                if (SpawnerType == TargetFruit.text)
                {
                    string virtualCount = targetSpawned.text;
                    int virtualCountInt = Int32.Parse(virtualCount);
                    virtualCountInt += 1;
                    targetSpawned.text = virtualCountInt.ToString();
                }

                float delay = UnityEngine.Random.Range(minDelay, maxDelay);
                yield return new WaitForSeconds(delay);

                int spawnIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[spawnIndex];

                GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
                fruit += 1;
                OnScreen.text = fruit.ToString();
                Destroy(spawnedFruit, 5f);
            }
        }

    }
}