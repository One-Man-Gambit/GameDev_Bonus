using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        OnObjectDestroyed += OnObjectDestroyed;
    }

    // -- Variables --
    public int Score;
    public Player_Controller pcRef;
    public Transform SpawnPoint;
    public List<Destructible> destructibleRefList;
    

    // -- Functions --
    private void Reset() 
    {
        pcRef.transform.position = SpawnPoint.position;
        foreach(Destructible d in destructibleRefList)
        {
            d.Reset();
        }
    }

    private void GainPoints() 
    {
        Score += 100;
    }
}
