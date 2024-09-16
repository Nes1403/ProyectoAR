using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour{
    public GameObject enemigoPrefab;          
    public GameObject enemigoPrefabOleada3;   
    public GameObject enemigoPrefabOleada5;   
    public Transform puntoCentral;            
    public float radio;                       
    public float intervaloGeneracion;         

    private float tiempoUltimaGeneracion;
    private int numeroOleada = 1;            
    private List<GameObject> enemigosVivos = new List<GameObject>();

    void Start(){
        tiempoUltimaGeneracion = Time.time;
    }

    void Update(){
        enemigosVivos.RemoveAll(enemigo => enemigo == null);

        if (enemigosVivos.Count == 0 && Time.time - tiempoUltimaGeneracion >= intervaloGeneracion){
            GenerarOleada();
            tiempoUltimaGeneracion = Time.time;
            numeroOleada++;
        }
    }

    void GenerarOleada(){

        int numeroDeEnemigos = numeroOleada + 2;

        for (int i = 0; i < numeroDeEnemigos; i++){
            InstanciarEnemigo(enemigoPrefab);
        }

        if (numeroOleada >= 3){
            int enemigosTipo2 = (numeroDeEnemigos / 3);
            for (int i = 0; i < enemigosTipo2; i++){
                InstanciarEnemigo(enemigoPrefabOleada3);
            }
        }
        if (numeroOleada >= 5){
            int enemigosTipo3 = (numeroDeEnemigos / 4);
            for (int i = 0; i < enemigosTipo3; i++){
                InstanciarEnemigo(enemigoPrefabOleada5);
            }
        }
    }

    void InstanciarEnemigo(GameObject prefab)
    {
        // Calcula una posición aleatoria alrededor del punto central
        Vector3 posicionAleatoria = puntoCentral.position + Random.onUnitSphere * radio;
        posicionAleatoria.y = puntoCentral.position.y + 0.1f; // Ajusta la altura si es necesario

        // Instancia el enemigo en la posición calculada
        GameObject nuevoEnemigo = Instantiate(prefab, posicionAleatoria, Quaternion.identity);

        // Añade el enemigo a la lista de enemigos vivos
        enemigosVivos.Add(nuevoEnemigo);
    }
}
