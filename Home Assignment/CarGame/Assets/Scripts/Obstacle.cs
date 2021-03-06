﻿using System.Collections;
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

    //explosion particle
    [SerializeField] GameObject deathEffect;
    [SerializeField] float explosionTime;

    //sound
    [SerializeField] AudioClip obsstacleDieJingle;
    [SerializeField] [Range(0, 1)] float obstacleDieJingleVolume = 0.75f;

    [SerializeField] int scoreValue = 50;

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

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        //destroy bullet
        damageDealer.Hit();
        //if health is less than 0
        if (health <= 0)
        {
            //destroy obstacle & create explosion
            Die();
        }
    }
    private void Die()
    {
        //destroy obstacle
        Destroy(gameObject);

        AudioSource.PlayClipAtPoint(obsstacleDieJingle, Camera.main.transform.position, obstacleDieJingleVolume);

        //create the explosion 
        GameObject explosion = Instantiate(deathEffect, transform.position, Quaternion.identity);
        //destroy after 1 sec
        Destroy(explosion, 1f);

        //add score to GameSession score
        FindObjectOfType<GameSessions>().AddToScore(scoreValue);

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
