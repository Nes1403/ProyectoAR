using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour{

    public int dano;


    public void OnCollisionEnter(Collision collision){
        Debug.Log("chocamos con " + collision.collider.name);
        Destroy(gameObject,1f);
        if(collision.collider.TryGetComponent(out Raton atacable)){
            atacable.RecibirDano(dano);
        }

    }
        
    
}
