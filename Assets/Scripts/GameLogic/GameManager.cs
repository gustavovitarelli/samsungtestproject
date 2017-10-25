using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int points = 0;
    public int targetPoints = 10;

    public  int xp = 10;

    public BarrierMaze maze;
    
    public enum GameState
    {
        intro,
        mainmenu,
        gameplay,
        settings,
        pause,
        quit,
        end
    }

    public void ResetGame()
    {
        xp = 10;
        points = 0;

        maze.ResetMaze();
    }

    public void BackToMenu() {
        ResetGame();
        state = GameState.mainmenu;
    }

    public void StartGame() {
        maze.DistribuiteElements();
        state = GameState.gameplay;
    }

    public void PauseGame() {
        state = GameState.pause;
    }

    public void QuitGame() {
        BackToMenu();
    }

    public void EnterSettings() {
        state = GameState.settings;
    }

    public void EndGame() {
        state = GameState.end;
    }

    public GameState state = GameState.intro;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
    }

    // Use this for initialization
    void Start () {
        state = GameState.mainmenu;
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    
    }


    // Update is called once per frame
    void Update () {

        if (xp == 0) state = GameState.end;
        if (points == targetPoints) state = GameState.end;

    }
}
