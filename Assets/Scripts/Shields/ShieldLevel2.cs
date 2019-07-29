using UnityEngine;
using System.Collections;

public class ShieldLevel2 : MonoBehaviour {
    int ShieldHealth = 30;
    bool IsShieldActive = false;
    bool isPoweringDown = false;
    bool TakingNullDamage = true;
    void OnGUI()
    {
        if (IsShieldActive == true)
        {
            if (isPoweringDown == false)
                GUI.Label(new Rect(1, 1, 200, 200), "Level 2 Shield: " + ShieldHealth.ToString());
        }
            
    }
    void OnCollisionEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "PlayerMissile")
        {

        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (IsShieldActive == true)
        {
            if (TakingNullDamage == false)
            {
                if (collider.gameObject.tag == "PlayerMissile")
                {
                    ShieldHealth = ShieldHealth - 2;
                }
            }
           
        }
        
    }
    void Update()
    {
        if (ShieldHealth == 0)
        {
            audio.Play();
            StartCoroutine(ShieldPowerDown());
            isPoweringDown = true;
            GameObject temp2 = GameObject.FindGameObjectWithTag("SpawnerVO2");
            temp2.SendMessage("StartVO");
            GameObject mainSpawner = GameObject.FindGameObjectWithTag("EnemySpawner");
            mainSpawner.SendMessage("ShiftToLevel3");
            GameObject NextPortal = GameObject.FindGameObjectWithTag("Portal2");
            //NextPortal.renderer.enabled = true;
            NextPortal.SendMessage("Activate");
        }   
    }

    void ActivateLevel2Shield()
    {
        IsShieldActive = true;
        StartCoroutine(ShieldsUp());

    }

    IEnumerator ShieldPowerDown()
    {
        yield return new WaitForSeconds(6.0f);
        GameObject temp = GameObject.FindGameObjectWithTag("SpawnerShield3");
        temp.SendMessage("ActivateLevel3Shield");

        GameObject.Destroy(this.gameObject);

    }
    IEnumerator ShieldsUp()
    {
        //This delay is to prevent the player from nuking the shield so hard the transition and second spawner breaks.
        yield return new WaitForSeconds(3.0f);
        TakingNullDamage = false;
    }
}
