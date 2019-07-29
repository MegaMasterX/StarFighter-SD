//Project StarFighter - Ludum Dare 31 Edition
//Programmed by Bryan "MegaMasterX" Harmon


using UnityEngine;
using System.Collections;
//GameObject temp = GameObject.FindGameObjectWithTag("VoiceOver1");
//temp.SendMessage("PlayVoiceOver1");


//Done and Implemented! TODO: Create Star particles for the backdrop
//FIXED! TODO: Fix the bug where the ships begin spawning before the introduction is completed
//Keeping this as a mechanic. It's chaotic! TODO: Give the ships out of the second portal 3HP per ship, meaning create a new script for them.
//Done and Implemented! TODO: Implement cleanup code to destroy all game objects and disable player movement when the spawner is destroyed
//Done and implemented! TODO: Create a end-title card with special-thanks and whatnot
//Done and Implemented! TODO: Create ambient space effects.
public class PlayerShip : MonoBehaviour {
    int PlayerHealth = 50;
    int MissileDamage = 2;
    int PlayerLives = 3;
    bool isPlayerControlEnabled = true;
    private Vector3 mousePosition;
    public float moveSpeed = 2.0f;
    bool hasGameStarted = false;
    bool isPlayerGunEnabled = true;
    bool FirstTimeKitUsed = false;

    bool HasWinConditionBeenMet = false;

    void OnGUI()
    {
        if (hasGameStarted == false)
        {
            GUI.Label(new Rect(200, 1, 500, 200), "Press ESC to Skip Intro!            Mouse - Move Ship; L Mouse Button - Fire");

        }
        if (isPlayerControlEnabled == true)
        {
            GUI.Label(new Rect(2, (Screen.height - 50.0f), 200, 200), "Player Health: " + PlayerHealth.ToString());
            GUI.Label(new Rect(2, (Screen.height - 40.0f), 200, 200), "Repair Kits Remaining: " + PlayerLives.ToString());

        }

        if (HasWinConditionBeenMet == true)
        {
            GUI.Label(new Rect(40, 180, 500, 200), "Project StarFighter - Ludum Dare 31 Release");
            GUI.Label(new Rect(40, 195, 500, 200), "Programmed & Designed by: Bryan Harmon");
            GUI.Label(new Rect(40, 245, 500, 200), "Dedicated to Michelle D.");
            GUI.Label(new Rect(45, 260, 500, 200), "How do you get a baby astronaut to sleep? You rock-it.");
            GUI.Label(new Rect(40, 300, 500, 200), "Graphics/Voice Acting/SFX Design: Bryan Harmon");
            GUI.Label(new Rect(40, 325, 500, 200), "SFX & Voice Acting Created with Audacity. Music created with Otomata");
            GUI.Label(new Rect(40, 400, 500, 200), "Special Thanks");
            GUI.Label(new Rect(60, 425, 500, 200), "All my Friends and Family - You rock!");
            GUI.Label(new Rect(60, 440, 500, 200), "2xH Studios for letting me take a crack at the 48hr Compo! This one's also for you!");
            GUI.Label(new Rect(60, 465, 500, 200), "Ludum Dare organizers, participants, and judges.");
            GUI.Label(new Rect(60, 480, 500, 200), "David, Christina, Becky, Josh - Thanks for putting up with me this weekend!");

            GUI.Label(new Rect(200, 510, 500, 200), "Press F2 to quit.");

        }
        
    }
	void Start () {
        Screen.showCursor = false;
        GameObject temp = GameObject.FindGameObjectWithTag("VoiceOver1");
        temp.SendMessage("PlayVoiceOver1");
        isPlayerControlEnabled = false;
        StartCoroutine("PlayerShipEnableTimer");

	}
	
	
	void Update () {
        if (isPlayerControlEnabled == true)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            if (isPlayerGunEnabled == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //Instantiate the bullet at runtime and let it do its thang
                    GameObject playerProjectile;
                    GameObject sourceProjectile = GameObject.FindGameObjectWithTag("PlayerMissile");
                    playerProjectile = Instantiate(sourceProjectile, transform.position, transform.rotation) as GameObject;
                    GameObject.Destroy(playerProjectile, 0.5f);

                    audio.Play();
                }
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            //Halt the VO, and start the game
            isPlayerControlEnabled = true;
            GameObject temp = GameObject.FindGameObjectWithTag("VoiceOver1");
            temp.SendMessage("HaltAllVO");
            hasGameStarted = true;
            GameObject SpawnerShip = GameObject.FindGameObjectWithTag("EnemySpawner");
            SpawnerShip.SendMessage("CutsceneEnded");
        }
            
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (HasWinConditionBeenMet == true)
            {
                Application.Quit();
            }
            Application.Quit();
        }
	}
    void FixedUpdate()
    {
        //Check to see what the player's health is at.
        if (PlayerHealth <= 0)
        {
            GameObject SFX_KitUsed = GameObject.FindGameObjectWithTag("SFX_KitUsed");
            SFX_KitUsed.audio.Play();
            if (PlayerLives == 3)
            {
                //This is the first time the player has lost a life.
                GameObject VO_KitUsedFirst = GameObject.FindGameObjectWithTag("Voice_KitUsed");
                VO_KitUsedFirst.audio.Play();
            }
            PlayerLives--;
            if (PlayerLives != 0)
            {
                PlayerHealth = 50;
            }
            else
            {
                //Implemented! TODO: Implement Game Over conditions.
                Application.LoadLevel(0); //Restart the game. Lazily.

            }
            

        }
    }

    void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyMissile")
        {
            PlayerHealth = PlayerHealth - 2;
            
        }
        if (collision.gameObject.tag == "EnemyPattern3")
        {
            PlayerHealth = PlayerHealth - 2;

        }
        if (collision.gameObject.tag == "EnemyPattern1")
            PlayerHealth = PlayerHealth - 2;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyMissile")
        {
            PlayerHealth = PlayerHealth - 2;

        }
        if (collision.gameObject.tag == "EnemyPattern3")
        {
            PlayerHealth = PlayerHealth - 2;

        }
        if (collision.gameObject.tag == "EnemyPattern1")
            PlayerHealth = PlayerHealth - 2;

    }

    IEnumerator PlayerShipEnableTimer()
    {
        yield return new WaitForSeconds(29.0F);
        isPlayerControlEnabled = true;
        hasGameStarted = true;
        GameObject SpawnerShip = GameObject.FindGameObjectWithTag("EnemySpawner");
        SpawnerShip.SendMessage("CutsceneEnded");
        //Enable all of the enemy spawners and their shields

    }
    
   
    void EnablePlayerShip()
    {
        isPlayerControlEnabled = true;

    }

    void DisablePlayerShip()
    {
        isPlayerControlEnabled = false;
    }

    void StartGame()
    {
        hasGameStarted = true;
    }

    void enablePlayerGuns()
    {
        isPlayerGunEnabled = true;
    }
    void DisablePlayerGuns()
    {
        isPlayerGunEnabled = false;

    }

    void AcceptDamage()
    {
        PlayerHealth = PlayerHealth - 2;
    }


    //Ending Cleanup and transition.
    void GameIsEnding()
    {
        isPlayerControlEnabled = false;
        isPlayerGunEnabled = false;
        StartCoroutine(FinalStages());
    }

    IEnumerator FinalStages()
    {
        //Perform cleanup of any objects remaining and enable the Credits UI elements.
        yield return new WaitForSeconds(7.0f);
        rigidbody2D.AddForce(Vector2.up * 300.0f);
        HasWinConditionBeenMet = true;

    }

}
