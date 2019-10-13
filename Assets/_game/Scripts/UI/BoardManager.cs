using UnityEngine;
using System;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.

namespace Completed

{

    public class BoardManager : MonoBehaviour
    {
        // Using Serializable allows us to embed a class with sub properties in the inspector.
        [Serializable]
        public class Count
        {
            public int minimum;             //Minimum value for our Count class.
            public int maximum;             //Maximum value for our Count class.


            //Assignment constructor.
            public Count(int min, int max)
            {
                minimum = min;
                maximum = max;
            }
        }

                public GameObject enemy;                                 //Array of enemy prefabs.
        public GameObject floor;                                 //Array of floor prefabs.
        public GameObject enemyShell;                                 //Array of floor prefabs.

        private Transform boardHolder;                                  //A variable to store a reference to the transform of our Board object.
        private GameObject enemyGhostSpawned;

        

        //Sets up the outer walls and floor (background) of the game board.
        void BoardSetup()
        {
            //Instantiate Board and set boardHolder to its transform.
            boardHolder = new GameObject("Board").transform;

            
                    //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
                    GameObject instance =
                        Instantiate(floor, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;

                    //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
                    instance.transform.SetParent(boardHolder);
        }

        void EnemySetup(int level)
        {
            for (int i = -2; i < level -2; i++)
            {
                enemyGhostSpawned = new GameObject("ghostEnemy");
               // enemyGhostSpawned = Instantiate(enemyShell, new Vector3(i, 1, 2), Quaternion.identity) as GameObject;
                enemyGhostSpawned.transform.SetParent(boardHolder);
               // GameObject enemySpawned = Instantiate(enemy, new Vector3(i, 1, 2), Quaternion.identity) as GameObject;
              //  enemySpawned.transform.SetParent(enemyGhostSpawned.transform);
            }
        }



        //SetupScene initializes our level and calls the previous functions to lay out the game board
        public void SetupScene(int level)
        {
            
            //Creates the outer walls and floor.
            BoardSetup();
            EnemySetup(level);

            
        }
    }
}
