using UnityEngine;
using System.Collections;

public class VoiceOver4 : MonoBehaviour {

    void PlayVoiceOver4()
    {
        audio.PlayDelayed(26.0f);

    }
    void HaltVO()
    {
        audio.Stop();
    }

}
