using UnityEngine;
using System.Collections;

public class FX_Explosion : MonoBehaviour {

	void Activate()
    {
        this.Activate();
        StartCoroutine(ExplosionTerm());
    }
	IEnumerator ExplosionTerm()
    {
        yield return new WaitForSeconds(2.5f);
        GameObject.Destroy(this.gameObject);

    }
}
