using UnityEngine;
using System.Collections;

public class Portal2 : MonoBehaviour {
    int SpawnerLevel = 3;
    bool isPortalEnabled = false;

	// Use this for initialization
    void Start()
    {
        // Update is called once per frame
    }
	void Update () {
	
	}

    IEnumerator SpawnTimer()
    {

        if (isPortalEnabled == true)
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
    }

    void Activate()
    {
        
        isPortalEnabled = true;

    }
}
