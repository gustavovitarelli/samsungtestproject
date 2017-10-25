using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject introPanel;
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject pausePanel;
    public GameObject quitPanel;
    public GameObject hudPanel;
    public GameObject endPanel;

    public Text pointsLabel;
    public Image xpProgress;

    // Use this for initialization
    void Start () {
		
	}

    public void UpdatePoints() {
        pointsLabel.text =  ""+ GameManager.Instance.points;
    }

    public void UpdateXP() {
        xpProgress.fillAmount = GameManager.Instance.xp/10.0f ;
    }
	
	// Update is called once per frame
	void Update () {
        switch (GameManager.Instance.state) {
            case GameManager.GameState.intro:
                introPanel.SetActive(true);
                mainMenuPanel.SetActive(false);
                settingsPanel.SetActive(false);
                pausePanel.SetActive(false);
                quitPanel.SetActive(false);
                hudPanel.SetActive(false);
                endPanel.SetActive(false);
                break;
            case GameManager.GameState.mainmenu:
                introPanel.SetActive(false);
                mainMenuPanel.SetActive(true);
                settingsPanel.SetActive(false);
                pausePanel.SetActive(false);
                quitPanel.SetActive(false);
                hudPanel.SetActive(false);
                endPanel.SetActive(false);
                break;
            case GameManager.GameState.settings:
                introPanel.SetActive(false);
                mainMenuPanel.SetActive(false);
                settingsPanel.SetActive(true);
                pausePanel.SetActive(false);
                quitPanel.SetActive(false);
                hudPanel.SetActive(false);
                endPanel.SetActive(false);
                break;
            case GameManager.GameState.gameplay:
                introPanel.SetActive(false);
                mainMenuPanel.SetActive(false);
                settingsPanel.SetActive(false);
                pausePanel.SetActive(false);
                quitPanel.SetActive(false);
                hudPanel.SetActive(true);
                endPanel.SetActive(false);

                UpdatePoints();
                UpdateXP();
                break;
            case GameManager.GameState.end:
                introPanel.SetActive(false);
                mainMenuPanel.SetActive(false);
                settingsPanel.SetActive(false);
                pausePanel.SetActive(false);
                quitPanel.SetActive(false);
                hudPanel.SetActive(false);
                endPanel.SetActive(true);
                break;
            case GameManager.GameState.pause:
                introPanel.SetActive(false);
                mainMenuPanel.SetActive(false);
                settingsPanel.SetActive(false);
                pausePanel.SetActive(true);
                quitPanel.SetActive(false);
                hudPanel.SetActive(false);
                endPanel.SetActive(false);
                break;
            case GameManager.GameState.quit:
                introPanel.SetActive(false);
                mainMenuPanel.SetActive(false);
                settingsPanel.SetActive(false);
                pausePanel.SetActive(false);
                quitPanel.SetActive(true);
                hudPanel.SetActive(false);
                endPanel.SetActive(false);
                break;
        }
	}
}
