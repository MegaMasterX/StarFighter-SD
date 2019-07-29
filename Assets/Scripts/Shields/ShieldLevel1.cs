using UnityEngine;
using System.Collections;

public class ShieldLevel1 : MonoBehaviour {
    int ShieldHealth = 50;
    bool isPoweringDown = false;

    void OnGUI()
    {
        if (isPoweringDown == false)
        {
            GUI.Label(new Rect(1, 1, 200, 200), "Shield Health: " + ShieldHealth.ToString());
        }
       
    }
    /*
    void OnCollisionEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "PlayerMissile")
        {
            ShieldHealth = ShieldHealth - 2;
        }
    }
	*/
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "PlayerMissile")
        {
            ShieldHealth = ShieldHealth - 2;
        }
    }
    void Update()
    {
        if (ShieldHealth == 0)
        {

            GameObject temp2 = GameObject.FindGameObjectWithTag("SpawnerVO1");
            temp2.SendMessage("StartVO");
            GameObject temp = GameObject.FindGameObjectWithTag("SpawnerShield2");
            temp.SendMessage("ActivateLevel2Shield");
            audio.Play();
            //GameObject.Destroy(this.gameObject);
            isPoweringDown = true;
            
            GameObject mainSpawner = GameObject.FindGameObjectWithTag("EnemySpawner");
            mainSpawner.SendMessage("ShiftToLevel2");

            StartCoroutine(TimeDestoryDelay());

        }
    }

    IEnumerator TimeDestoryDelay()
    {
        yield return new WaitForSeconds(6.0f);
        GameObject playerShip = GameObject.FindGameObjectWithTag("Player");
        playerShip.SendMessage("EnablePlayerShip");
        
        GameObject.Destroy(this.gameObject);

    }
}
