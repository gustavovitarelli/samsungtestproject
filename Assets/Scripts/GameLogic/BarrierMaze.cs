using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class BarrierMaze : MonoBehaviour {

    public GameObject[] barrierPrefabs;
    public GameObject[] elementsPrefabs;
    public GameObject pointsPrefabs;
    public GameObject characterPrefab;

    public LookatTarget look;
    public HandHeldCam camlook;

    public int gridSize = 10;
    public int gridNumber = 10;

    public int barrierNum = 10;
    public int itemsNum = 30;

    public GameObject objGO;
    public GameObject characterGO;

    public int[,] grid;

    // Use this for initialization
    void Start () {
		
	}

    public void ResetMaze(){
        //camlook.enabled = false;
        Destroy(objGO);
        Destroy(characterGO);
    }

    public void DistribuiteElements(){
        GameObject characterGO = Instantiate(characterPrefab, new Vector3(0, 0, 0), this.transform.rotation);
        look.SetTarget(characterGO.transform);
        //camlook.enabled = true;
        //camlook.SetTarget(characterGO.transform);

        objGO = new GameObject();
        objGO.name = "MazeObjects";

        grid = new int[10, 10];
        // Distribute Points
        for (int i = 0; i < GameManager.Instance.targetPoints-1; i++) {
            int randomPosX = Random.RandomRange(0, gridNumber);
            int randomPosZ = Random.RandomRange(0, gridNumber);
            grid[randomPosX, randomPosZ] = 1;
            GameObject pGO = Instantiate(pointsPrefabs, new Vector3(randomPosX * gridSize + 0.5f, 0, randomPosZ * gridSize + 0.5f) +transform.position, this.transform.rotation);
            pGO.transform.parent = objGO.transform;
        }

        // Distribuite Barriers
        for (int i = 0; i < barrierNum; i++)
        {
            int randomPosX = Random.RandomRange(0, gridNumber);
            int randomPosZ = Random.RandomRange(0, gridNumber);
            int randomb = Random.RandomRange(0, barrierPrefabs.Length-1);
            grid[randomPosX, randomPosZ] = 2;
            GameObject pGO = Instantiate(barrierPrefabs[randomb], new Vector3(randomPosX * gridSize * 1.5f, 0, randomPosZ * gridSize  * 1.5f) + transform.position, this.transform.rotation);
            pGO.transform.parent = objGO.transform;
        }

        // Distribuite Other Elements
        for (int i = 0; i < itemsNum; i++)
        {
            int randomPosX = Random.RandomRange(0, gridNumber);
            int randomPosZ = Random.RandomRange(0, gridNumber);
            int randomb = Random.RandomRange(0, elementsPrefabs.Length - 1);
            grid[randomPosX, randomPosZ] = 2;
            GameObject pGO = Instantiate(elementsPrefabs[randomb], new Vector3(randomPosX * gridSize * 1.5f, 0, randomPosZ * gridSize * 1.5f) + transform.position, this.transform.rotation);
            pGO.transform.parent = objGO.transform;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
