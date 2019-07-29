using UnityEngine;
using System.Collections;

public class SpawnerVoiceOver4 : MonoBehaviour {

	void StartVO()
    {
        audio.PlayDelayed(4.0f);
        StartCoroutine(ShieldsAreDown());

    }
    IEnumerator ShieldsAreDown()
    {
        yield return new WaitForSeconds(3.0f);
        GameObject temp = GameObject.FindGameObjectWithTag("EnemySpawner");
        temp.SendMessage("HullBreached");

    }
}
