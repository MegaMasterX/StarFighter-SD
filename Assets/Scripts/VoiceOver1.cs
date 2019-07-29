using UnityEngine;
using System.Collections;

public class VoiceOver1 : MonoBehaviour {


    void PlayVoiceOver1()
    {
        audio.PlayDelayed(1.0f);
        GameObject temp = GameObject.FindGameObjectWithTag("VoiceOver2");
        temp.SendMessage("PlayVoiceOver2");

        //audio.Play(10);

    }

    void HaltAllVO()
    {
        audio.Stop();
        GameObject VO2 = GameObject.FindGameObjectWithTag("VoiceOver2");
        GameObject VO3 = GameObject.FindGameObjectWithTag("VoiceOver3");
        GameObject VO4 = GameObject.FindGameObjectWithTag("VoiceOverFinal");
        VO2.SendMessage("HaltVO");
        VO3.SendMessage("HaltVO");
        VO4.SendMessage("HaltVO");

    }
}
