using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {
    GameObject tempPlayer;
    private float Range;
    bool isOutofBounds = true;

    void OnGUI()
    {

    }
	// Use this for initialization
	void Start () {
        //rigidbody2D.AddForce(-Vector2.up * 20.0f);
        tempPlayer = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FireMissileInterval());
	}
	
	// Update is called once per frame
	void Update () {
        if (isOutofBounds == false)
        {
            rigidbody2D.transform.position = Vector3.MoveTowards(rigidbody2D.transform.position, tempPlayer.transform.position, (1.0f * Time.deltaTime));
        }
        
	}
    
    void OnCollisionEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Space")
        {
            isOutofBounds = true;

        }
    }
    IEnumerator FireMissileInterval()
    {
        yield return new WaitForSeconds(4.0f);
        GameObject SourceMissile = GameObject.FindGameObjectWithTag("EnemyMissile");
        GameObject tempMissle;
        tempMissle = Instantiate(SourceMissile, transform.position, transform.rotation) as GameObject;
        StartCoroutine(FireMissileInterval());
        GameObject.Destroy(tempMissle, 0.5f);

    }

    void ShipHit()
    {
        GameObject.Destroy(this.gameObject);

    }

    void Activate()
    {
        isOutofBounds = false;
    }
}
