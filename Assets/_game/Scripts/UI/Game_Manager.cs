using UnityEngine;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 

public class Game_Manager : MonoBehaviour
{

    public static Game_Manager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
                                                            //   private BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.
    public int level = 5;                                  //Current level number, expressed in game as "Day 1".

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        //  boardScript = GetComponent<BoardManager>();

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        //Call the SetupScene function of the BoardManager script, pass it current level number.
        BoardSetup();

    }



    //Update is called every frame.
    void Update()
    {

    }




    public GameObject enemy;                                 //Array of enemy prefabs.
   // public GameObject floor;                                 //Array of floor prefabs.
    public GameObject enemyShell;                                 //Array of floor prefabs.

    private Transform boardHolder;                                  //A variable to store a reference to the transform of our Board object.




    //Sets up the outer walls and floor (background) of the game board.
    void BoardSetup()
    {
        //Instantiate Board and set boardHolder to its transform.
        boardHolder = new GameObject("Board").transform;


        //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
        //GameObject instance =
           // Instantiate(floor, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;

        //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
        instance.transform.SetParent(boardHolder);
    }

    void EnemySetup(int level)
    {
        StartCoroutine(Example());
        for (int i = -5; i < level - 5; i++)
        {
            //GameObject enemyGhostSpawned = Instantiate(enemyShell, new Vector3(i, 1, 2), Quaternion.identity) as GameObject;
            //enemyGhostSpawned.transform.SetParent(boardHolder);

            StartCoroutine(Example());
        }
    }



    //SetupScene initializes our level and calls the previous functions to lay out the game board
    public void SetupScene(int level)
    {

        //Creates the outer walls and floor.
      //  BoardSetup();
        EnemySetup(level);


    }

    IEnumerator Example()
    {
        for (int i = -5; i < level - 5; i++)
        {
           
            GameObject enemySpawned = Instantiate(enemy, new Vector3(0f, 0.2f, 10f), Quaternion.Euler(0, 180, 0)) as GameObject;
            enemySpawned.transform.SetParent(boardHolder.transform);
            yield return new WaitForSeconds(5);
        }
      

    }

}








    