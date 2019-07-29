using UnityEngine;
using System.Collections;

public class SpawnerVoiceOver1 : MonoBehaviour {

    void StartVO()
    {
        //GameObject playerShip = GameObject.FindGameObjectWithTag("Player");
        //playerShip.SendMessage("DisablePlayerShip");
        
        audio.PlayDelayed(4.0f);

    }
    
}
