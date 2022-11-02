using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float Speed = 3.0f;

    public bool CanClimb = false;
    public Rigidbody2D rigid2D;
    public BoxCollider2D collider2D;

    private void Awake() 
    {
        rigid2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    private void Update() 
    {
        Motion();
    }

    public void Motion() 
    {
        float x = Input.GetAxis("Horizontal");
        float y = 0;
        
        if (CanClimb) 
        {
            y = Input.GetAxis("Vertical");
        }
        

        transform.position += new Vector3(x, y, 0) * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == 6) 
        {
            CanClimb = true;
            rigid2D.gravityScale = 0.0f;
            collider2D.isTrigger = true;
        }        

        if (other.tag == "Enemy") 
        {
            GameManager.GetInstance().OnPlayerKilled?.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.tag == "Interactable") 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                other.GetComponent<Interactable>().Interact();
            }            
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.layer == 6) 
        {
            CanClimb = false;
            rigid2D.gravityScale = 1.0f;
            collider2D.isTrigger = false;
        }
    }
}
