using UnityEngine;
using System.Collections;

public class StarEmitter : MonoBehaviour {

    bool isActivated = false;

	void Start () {
        StartCoroutine(FireStar());
	}
	
    IEnumerator FireStar()
    {
        yield return new WaitForSeconds(7.0f);
        GameObject NewStar1;
        GameObject SourceStar1 = GameObject.FindGameObjectWithTag("Star1");
        NewStar1 = Instantiate(SourceStar1, transform.position, transform.rotation) as GameObject;
        NewStar1.SendMessage("Activate");
        StartCoroutine(FireStar());
    }
	
    void Activate()
    {
        isActivated = true;
        rigidbody2D.AddForce(-Vector2.up * 20.00f);
        
    }
}
