using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //Serialised Fields
    [SerializeField] float health = 5;

    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBullets = 0.2f;
    [SerializeField] float maxTimeBullets = 3f;

    [SerializeField] GameObject obstableBulletPrefab;
    [SerializeField] float obstableBulletsSpeed = 0.3f;

    //reduces health when an obstacle collides with an object with Damage Dealer 
    private void OnTriggerEnter2D(Collider2D other)
    {

        //access the Damage Dealer from the object that collided with the obstacle
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        //reduce health
        health -= damageDealer.GetDamage();
    }

    private void ObstacleShoot()
    {   //spawn as an enemy bullet near the obstacle
        GameObject obstacleBullet = Instantiate(obstableBulletPrefab, transform.position, Quaternion.identity) as GameObject;
      
        //enemy laser shoots downwards
        obstacleBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstableBulletsSpeed);
    }



    private void CountDownShoot()
    {
        //each frame means less time the frame takes to run
        shotCounter -= Time.deltaTime;
        //if reaches 0
        if (shotCounter <= 0f)
        {
            ObstacleShoot();

            //reset shotCounter after every fire
            shotCounter = Random.Range(minTimeBullets, maxTimeBullets);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBullets, maxTimeBullets);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownShoot();
    }


}
