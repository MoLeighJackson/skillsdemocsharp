using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameStateManager : MonoBehaviour {

    // properties
    public GameObject playerPrefab;
    public Text continueText;
    public Text scoreText;
    private float timeElapsed = 0f;
    private float bestTime = 0f;
    private float blinkTime = 0f;
    private bool blink;
    private bool gameStarted;
    private GameObject player;
    private TimeManager timeManager;
    private GameObject floor;
    private ObjectSpawner spawner;
    private bool beatBestTime;
    
    
    // 1st method called
    void Awake()
    {
        floor = GameObject.Find("Track");
       spawner = GameObject.Find("Object Spawner").GetComponent<ObjectSpawner>();
        //// time manager logic (chapter 6)
        timeManager = GetComponent<TimeManager>();
    }


    // start method
    void Start()
    {
        // starts with track at bottom of screen and spawner is deactivated
        var floorHeight = floor.transform.localScale.y;

        var pos = floor.transform.position;
        pos.x = 0;
        pos.y = -((Screen.height / DynamicCamera.pixelsToUnits) / 2) + (floorHeight / 2);
        //conveyorBelt.transform.position = pos;

        spawner.active = false;

        Time.timeScale = 0; // when game loads time scale equals 0

        continueText.text = "PRESS ANY KEY TO START";
        //ResetGame();

        bestTime = PlayerPrefs.GetFloat("BestTime");

    }


    // update method
    void Update()
    {
        if (!gameStarted && Time.timeScale == 0)
        {
            if (Input.anyKeyDown)
            {
                timeManager.ManipulateTime(1, 1f);
                ResetGame();
            }
        }
        if (!gameStarted)
        {
            blinkTime++;

            if(blinkTime % 40 == 0)
            {
                blink = !blink;
            }

            continueText.canvasRenderer.SetAlpha(blink ? 0 : 1);

            var textColor = beatBestTime ? "#ff0" : "#fff";

            scoreText.text = "TIME: " + FormatTime(timeElapsed) + "\n<color="+ textColor+">BEST: " + FormatTime(bestTime)+"</color>";

        }
        else
        {
            timeElapsed += Time.deltaTime;
            scoreText.text = "TIME: " + FormatTime(timeElapsed);
        }
    }


    //// method
    ////player has been pushed or carried off screen
    //// player is out
    //// game over

    void OnPlayerOut()
    {
        spawner.active = false;


        //    // when the player is out, get a ref to the delete off screen script
        var playerOutScript = player.GetComponent<DeleteOffscreenObject>();
        playerOutScript.DestroyCallback -= OnPlayerOut;

        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        timeManager.ManipulateTime(0, 5.5f);
        gameStarted = false;

        continueText.text = "PRESS ANY KEY TO RESTART";

        if(timeElapsed > bestTime)
        {
            bestTime = timeElapsed;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            beatBestTime = true;

        }
    }


    //// Reset Game method

    void ResetGame()
    {
        spawner.active = true;

        player = GameObjectUtility.Instantiate(playerPrefab, new Vector3(0, (Screen.height / DynamicCamera.pixelsToUnits) / 2 + 100, 0));

        var playerOutScript = player.GetComponent<DeleteOffscreenObject>();
        playerOutScript.DestroyCallback += OnPlayerOut;

        gameStarted = true;

        continueText.canvasRenderer.SetAlpha(0);

        timeElapsed = 0;

        beatBestTime = false;
    }

    string FormatTime(float value)
    {
        TimeSpan t = TimeSpan.FromSeconds(value);
        return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }
}
