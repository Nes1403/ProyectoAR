using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 

using UnityEngine;

public class Queso : MonoBehaviour
{
    public int salud;



    public void OnCollisionEnter(Collision collision){
        if(collision.collider.TryGetComponent(out Raton atacable)){
            salud -= 1;
            atacable.RecibirDano(10000);
            if(salud <= 0){
                Destroy(gameObject);
            }
        }
    }
}
