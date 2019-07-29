using UnityEngine;
using System.Collections;

public class SecondaryPortal : MonoBehaviour {
    bool isPortalActive = false;
    GameObject templateShip1;
    
	void Activate()
    {
        if (renderer.enabled == false)
        {
               
            renderer.enabled = true;
            StartCoroutine(Spawner2());
        }
            
        isPortalActive = true;
        audio.Play();
        
        
    }
    void Start()
    {
        templateShip1 = GameObject.FindGameObjectWithTag("EnemyPattern3");    
    }
   IEnumerator Spawner2()
   {
       yield return new WaitForSeconds(5.0f);
       GameObject newShip = Instantiate(templateShip1, transform.position, transform.rotation) as GameObject;
       newShip.SendMessage("Activate");
       StartCoroutine(Spawner2());

   }
    void HaltSpawn()
   {
       StopCoroutine(Spawner2());
   }
      
}
