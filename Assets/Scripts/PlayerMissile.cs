using UnityEngine;
using System.Collections;

public class PlayerMissile : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Space")
        {
            GameObject.Destroy(this.gameObject);

        }
        if (collider.gameObject.tag == "EnemySpawner")
        {
            GameObject temp = GameObject.FindGameObjectWithTag("EnemySpawner");
            temp.SendMessage("TakeDamage");

            GameObject.Destroy(this.gameObject);

        }
        if (collider.gameObject.tag == "EnemyPattern1")
        {
            collider.gameObject.SendMessage("ShipHit");
        }
        

    }


    
    void Start()
    {
        rigidbody2D.AddForce(Vector2.up * 2000);
        
    }
}
