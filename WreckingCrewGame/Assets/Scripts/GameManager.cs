using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
     // -- Observers -- 
    public delegate void OnEventDelegate();
    public OnEventDelegate OnPlayerKilled;
    public OnEventDelegate OnObjectDestroyed;

    // -- SINGLETON --
    private static GameManager instance;
    public static GameManager GetInstance() 
    {
        return instance;
    }

    private void Awake() 
    {
        // Set our Singleton Instance
        if (instance != null) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }

        // Set our Observer Functions
        OnPlayerKilled += Reset;
        OnObjectDestroyed += GainPoints;
    }

    // -- Variables --
    public int Score;
    public Player_Controller pcRef;
    public Transform SpawnPoint;
    public List<Destructible> destructibleRefList;
    public Text scoreDisplay;
    

    // -- Functions --
    private void Reset() 
    {
        pcRef.transform.position = SpawnPoint.position;
        foreach(Destructible d in destructibleRefList)
        {
            d.Reset();
        }

        Score = 0;
        scoreDisplay.text = "Score: " + Score;
    }

    private void GainPoints() 
    {
        Score += 100;
        scoreDisplay.text = "Score: " + Score;
    }
}
