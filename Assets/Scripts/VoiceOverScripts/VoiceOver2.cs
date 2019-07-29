using UnityEngine;
using System.Collections;

public class VoiceOver2 : MonoBehaviour {
    void PlayVoiceOver2()
    {
        audio.PlayDelayed(7.8f);
        GameObject temp = GameObject.FindGameObjectWithTag("VoiceOver3");
        temp.SendMessage("PlayVoiceOver3");

    }
    void HaltVO()
    {
        audio.Stop();

    }
}
