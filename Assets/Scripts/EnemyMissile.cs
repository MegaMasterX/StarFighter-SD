using UnityEngine;
using System.Collections;

public class EnemyMissile : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Space")
        {
            GameObject.Destroy(this.gameObject);

        }
        if (collider.gameObject.tag == "Player")
        {
            

            GameObject.Destroy(this.gameObject);

        }
    }


    void OnCollisionEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
            collider.gameObject.SendMessage("AcceptDamage");
    }
    void Start()
    {
        //Detect where the player's position is in WorldSpace and save a snapshot of it.
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");


        rigidbody2D.velocity = (tempPlayer.transform.position - transform.position).normalized * 10.0f;

    }
}
