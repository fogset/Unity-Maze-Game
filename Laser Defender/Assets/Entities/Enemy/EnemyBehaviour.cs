using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
    public GameObject projectile;
    public float health = 250;

	void OnTriggerEnter2D(Collider2D collider)
    {
        
        Projectile missile= collider.gameObject.GetComponent<Projectile>();
       
        if (missile)
        {
            health -= missile.getDamage();
            missile.Hit();
            if (health <= 0){
                Destroy(gameObject);
            }
            
        }
        
            
    }
   


}
