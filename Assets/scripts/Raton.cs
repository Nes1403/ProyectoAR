using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raton : MonoBehaviour{
    
    public int salud;

    public GameObject miniRata;

    public float velocidad;


    public void Update(){
        GameObject tirador = GameObject.FindGameObjectWithTag("Jugador");
        Vector3 posicionSuelo = new Vector3(tirador.transform.position.x, transform.position.y, tirador.transform.position.z);
        Vector3 direccionTiradorSuelo= posicionSuelo - transform.position;
        transform.right = -direccionTiradorSuelo.normalized;
        transform.position += Vector3.Normalize(posicionSuelo - transform.position) * velocidad * Time.deltaTime;
    }

    public void RecibirDano(int dano){
        salud -= dano;
        if(salud <= 0){
            Destroy(gameObject);
            if(miniRata != null){
            Instantiate(miniRata, transform.position, transform.rotation);
            Instantiate(miniRata, transform.position, transform.rotation);
            }
        }
    }
        
}
