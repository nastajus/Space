using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidSpawner : Logger {

    //find all other AsteroidSpawner, Draw rays between them.
    //public bool spawnerExists = false;
    bool spawnerFound = false;
    static AsteroidSpawner spawnerGod = null;
    static int spawnerNumberCounter = 0;
    public int spawnerNumber;
    List<AsteroidSpawner> asteroidSpawners;

    void Awake()
    {
        if (this.gameObject.tag != "AsteroidSpawner")
        {
            this.gameObject.tag = "AsteroidSpawner";
            Debug.LogWarning("AsteroidSpawner tag was missing, adding.");
        }
        if (spawnerGod == null)
        {
            spawnerGod = this;
            Log("spawnerGod set to : " + this.gameObject.name);
        }
        //spawnerExists = true;
    }

    void Start () {
        if (this == spawnerGod)
        {
            FindAsteroidSpawner();
        }
	}
	
	void Update () {
	
	}

    /**
     *  Finds other objects with tag/script with this name. Occurs only once. 
     */
    public void FindAsteroidSpawner()
    {

        List<GameObject> asteroidSpawnerGOs = new List<GameObject>(GameObject.FindGameObjectsWithTag("AsteroidSpawner"));
        foreach (GameObject astSpawn in asteroidSpawnerGOs ){
            var scriptRef = astSpawn.GetComponent<AsteroidSpawner>();
            asteroidSpawners.Add(scriptRef);
            scriptRef.spawnerNumber = ++spawnerNumberCounter;
            Log(scriptRef.gameObject.name + " #'d: " + scriptRef.spawnerNumber);
        }
    }
}
