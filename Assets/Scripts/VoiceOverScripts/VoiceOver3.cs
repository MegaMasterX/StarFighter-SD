using UnityEngine;
using System.Collections;

public class VoiceOver3 : MonoBehaviour {

	void PlayVoiceOver3()
    {
        audio.PlayDelayed(16.0f);
        GameObject temp = GameObject.FindGameObjectWithTag("VoiceOverFinal");
        temp.SendMessage("PlayVoiceOver4");

    }

    void HaltVO()
    {
        audio.Stop();

    }
}
