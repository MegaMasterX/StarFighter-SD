using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    int SpawnerShieldLevel = 2;
    int SpawnerShieldHealth = 100;
    bool AllShieldsDown = false;
    int SpawnerHealth = 200;
    int SpawnerLevel = 4;

    void OnGUI()
    {
        if (AllShieldsDown == true)
        {
            GUI.Label(new Rect(400, 1, 200, 200), "Spawner Hull Integrity: " + SpawnerHealth.ToString() + "%");
        }
    }

    void Start()
    {
        

    }

    void CutsceneEnded()
    {
        StartCoroutine(SpawnTimer());
    }
	void OnCollisionEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "PlayerMissile")
        {
            
            SpawnerShieldHealth = SpawnerShieldHealth - 2;

        }
    }
    
    void Update()
    {
        if (SpawnerHealth == 2)
        {
            audio.Play();
        }
        if (SpawnerHealth == 0)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Portal1");
            GameObject.Destroy(temp);
            GameObject temp2 = GameObject.FindGameObjectWithTag("VoiceOver_Victory");
            temp2.SendMessage("StartVO");
            
            GameObject SecondPortal = GameObject.FindGameObjectWithTag("Portal2");
            SecondPortal.SendMessage("HaltSpawn");
            GameObject.Destroy(SecondPortal.gameObject);
            //Cleanup all the stray ships
            GameObject[] PrimaryShips = GameObject.FindGameObjectsWithTag("EnemyPattern1");
            foreach (GameObject pShip in PrimaryShips)
            {
                GameObject.Destroy(pShip.gameObject);
            }
            GameObject[] SecondaryShips = GameObject.FindGameObjectsWithTag("EnemyPattern3");
            foreach (GameObject target in SecondaryShips)
            {
                GameObject.Destroy(target.gameObject);
            }

            GameObject PlayerShip = GameObject.FindGameObjectWithTag("Player");
            PlayerShip.SendMessage("GameIsEnding");

            GameObject.Destroy(this.gameObject);

        }
        

    }

    void TakeDamage()
    {
        SpawnerHealth = SpawnerHealth - 2;
    }

    void HullBreached()
    {
        AllShieldsDown = true;

    }

    IEnumerator SpawnTimer()
    {
        GameObject sourceClone = GameObject.FindGameObjectWithTag("EnemyPattern1");
        GameObject DatCloneDoe;
        switch (SpawnerLevel)
        {
            case 4:
                //The interval for this should be 8 seconds, 8.0F
                yield return new WaitForSeconds(8.0f);
                
                DatCloneDoe = Instantiate(sourceClone, rigidbody2D.position, transform.rotation) as GameObject;
                DatCloneDoe.SendMessage("Activate");

                StartCoroutine(SpawnTimer());

                break;
            case 3:
                //The interval for this should be 8 seconds, 8.0F
                yield return new WaitForSeconds(4.0f);
                
                DatCloneDoe = Instantiate(sourceClone, rigidbody2D.position, transform.rotation) as GameObject;
                DatCloneDoe.SendMessage("Activate");
                
                
                StartCoroutine(SpawnTimer());

                break;
            case 2:
                //The interval for this should be 8 seconds, 8.0F
                yield return new WaitForSeconds(2.0f);


                DatCloneDoe = Instantiate(sourceClone, rigidbody2D.position, transform.rotation) as GameObject;
                GameObject newSpawner = GameObject.FindGameObjectWithTag("Portal2");
                newSpawner.SendMessage("Activate");
                DatCloneDoe.SendMessage("Activate");

                StartCoroutine(SpawnTimer());

                break;
            case 1:
                //The interval for this should be 8 seconds, 8.0F
                yield return new WaitForSeconds(1.4f);

                DatCloneDoe = Instantiate(sourceClone, rigidbody2D.position, transform.rotation) as GameObject;
                DatCloneDoe.SendMessage("Activate");

                StartCoroutine(SpawnTimer());
                break;
            default:
                break;
        }
        

    }
   

    void ShiftToLevel2()
    {
        SpawnerLevel = 3;

    }

    void ShiftToLevel3()
    {
        SpawnerLevel = 2;

    }
    void ShiftToLevel4()
    {
        SpawnerLevel = 1;

    }
}
