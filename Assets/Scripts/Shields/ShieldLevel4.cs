using UnityEngine;
using System.Collections;

public class ShieldLevel4 : MonoBehaviour {
    int ShieldHealth = 14;
    bool IsShieldActive = false;
    bool isPoweringDown = false;
    void OnGUI()
    {
        if (IsShieldActive == true)
        {
            if (isPoweringDown == false)
                GUI.Label(new Rect(1, 1, 200, 200), "Level 4 Shield: " + ShieldHealth.ToString());
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
            if (collider.gameObject.tag == "PlayerMissile")
            {
                ShieldHealth = ShieldHealth - 2;
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
            GameObject temp2 = GameObject.FindGameObjectWithTag("SpawnerVO4");
            temp2.SendMessage("StartVO");
        }
        
       
    }

    void ActivateLevel4Shield()
    {
        IsShieldActive = true;

    }

    IEnumerator ShieldPowerDown()
    {
        yield return new WaitForSeconds(6.0f);
        GameObject.Destroy(this.gameObject);

    }
}
