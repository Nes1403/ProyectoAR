using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public GameObject enemigoPrefabOleada3;
    public GameObject enemigoPrefabOleada5;
    public Transform puntoCentral;
    public float radio;

    private float tiempoEntreOleadas = 3f;
    private float tiempoUltimoMensaje = 0f;
    private int numeroOleada = 1;
    private List<GameObject> enemigosVivos = new List<GameObject>();
    private bool mostrandoMensaje = false;

    void Update()
    {
        enemigosVivos.RemoveAll(enemigo => enemigo == null);

        if (enemigosVivos.Count == 0)
        {
            if (!mostrandoMensaje)
            {
                // Iniciar la cuenta atrás
                tiempoUltimoMensaje = Time.time;
                mostrandoMensaje = true;
            }
            else
            {
                // Controlar el tiempo de espera
                if (Time.time - tiempoUltimoMensaje >= tiempoEntreOleadas)
                {
                    GenerarOleada();
                    numeroOleada++;
                    mostrandoMensaje = false;
                }
            }
        }
    }

    void GenerarOleada()
    {
        int numeroDeEnemigos = numeroOleada + 2;

        for (int i = 0; i < numeroDeEnemigos; i++)
        {
            InstanciarEnemigo(enemigoPrefab);
        }

        if (numeroOleada >= 3)
        {
            int enemigosTipo2 = (numeroDeEnemigos / 3);
            for (int i = 0; i < enemigosTipo2; i++)
            {
                InstanciarEnemigo(enemigoPrefabOleada3);
            }
        }

        if (numeroOleada >= 5)
        {
            int enemigosTipo3 = (numeroDeEnemigos / 4);
            for (int i = 0; i < enemigosTipo3; i++)
            {
                InstanciarEnemigo(enemigoPrefabOleada5);
            }
        }
        #if UNITY_ANDROID || UNITY_IOS
        Handheld.Vibrate();
        #endif
    }

    void InstanciarEnemigo(GameObject prefab)
    {
        Vector2 puntoAleatorio = Random.insideUnitCircle * radio;
        Vector3 posicionAleatoria = new Vector3(puntoAleatorio.x, 0, puntoAleatorio.y) + puntoCentral.position;
        posicionAleatoria.y = puntoCentral.position.y + 0.1f;

        if (Vector3.Distance(puntoCentral.position, posicionAleatoria) < 1f)
        {
            posicionAleatoria += (posicionAleatoria - puntoCentral.position).normalized * 2f; 
        }

        GameObject nuevoEnemigo = Instantiate(prefab, posicionAleatoria, Quaternion.identity);
        enemigosVivos.Add(nuevoEnemigo);
    }
}
