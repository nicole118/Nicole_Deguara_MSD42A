using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float carSpeed = 10f;
    [SerializeField] float playerHealth = 50f;
    [SerializeField] float padding = 0.5f;
    float Min_Y, Max_Y, Min_X, Max_X;

    // Start is called before the first frame update
    void Start()
    {
        SetMove();
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCar();
    }

    private void MoveCar()
    {
        // gets the horizontal movement of the Car
        var InputX = Input.GetAxis("Horizontal") * Time.deltaTime * carSpeed;

        //the current horizontal psotion of the Player Car
        var newXPos = transform.position.x + InputX;
        //the new position must be between Min_X and Max_X
        newXPos = Mathf.Clamp(newXPos, Min_X, Max_X);

        //gets the vertical movement of the Car
        var InputY = Input.GetAxis("Vertical") * Time.deltaTime;

        //update Player Position
        transform.position = new Vector2(newXPos, InputY);

    }


    private void SetMove()
    {
        //setting the camera border 
        Camera gameCamera = Camera.main;

        Min_X = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        Max_X = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        Min_Y = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        Max_Y = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //access the Damage Dealer from the object that collided with the obstacle
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        //if there is no damageDealer on Trigger
        if (!damageDealer)
        {
            //end this method
            return;
        }

        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        playerHealth -= damageDealer.GetDamage();
        //destroy the obstacle bullet
        damageDealer.Hit();
    }

    }
