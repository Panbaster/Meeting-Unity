using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour {

    public GameObject uiCanvas;
    public GameObject pauseMenuCanvas;

    bool gamePause;
    GameObject[] canvases;

	void Start () {
        gamePause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	//Controler for players input witch work in any case
	void Update () {
        //Pause menu + stoping game
        if (Input.GetButtonDown("Cancel"))
        {
            if (gamePause)
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                canvases = GameObject.FindGameObjectsWithTag("UI");
                for (int i = 0; i < canvases.Length; i++)
                    canvases[i].SetActive(false);
                uiCanvas.SetActive(true);
                gamePause = false;
            }
            else
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                canvases = GameObject.FindGameObjectsWithTag("UI");
                for (int i = 0; i < canvases.Length; i++)
                    canvases[i].SetActive(false);
                pauseMenuCanvas.SetActive(true);
                gamePause = true;
            }

        }
    }
}
