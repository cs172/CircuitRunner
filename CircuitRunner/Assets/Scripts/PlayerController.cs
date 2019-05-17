﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Sprite[] playerSprite;

    public SpriteRenderer playerRenderer;

    public Rigidbody rb;


    // Player properties
    private static int numOfLives = 3;
    private static int numOfShields = 2;
    public static int NumOfLives { get => numOfLives; set => numOfLives = value; }
    public static int NumOfShields { get => numOfShields; set => numOfShields = value; }
    //######################################################################################
    private static bool isDead;
    public static bool IsDead { get => isDead; set => isDead = value; }
    //######################################################################################

    void start() 
    {
        isDead = false;

        // Init the num of shields and power ups
        numOfLives = 3;
        numOfShields = 2;  

        rb = GetComponent<Rigidbody> ();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other) 
    {
        if (other.gameObject.CompareTag ("Shield Pick Up")) 
        {      
            if (numOfShields < UIManager.kMaxAmtShields)
            {
                numOfShields++;
            }
            Destroy(other.gameObject);
        } 
        
        if (other.gameObject.CompareTag ("Battery Pick Up"))
        {
            numOfLives++;
            Destroy(other.gameObject);
        }  

        if (other.gameObject.CompareTag("Brick Wall"))
        {
            if (numOfLives > 1) {
                numOfLives--;
            } else {
                isDead = true;
            }
            playerRenderer.sprite = playerSprite[0];
        }
    }
}
