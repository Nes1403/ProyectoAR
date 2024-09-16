using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public GameObject enemigoPrefabOleada3;
    public GameObject enemigoPrefabOleada5;
    public Transform puntoCentral;
    public float radio;

    public TextMeshProUGUI mensajeOleadaUI;

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
                // Iniciar la cuenta atrás para mostrar el mensaje
                tiempoUltimoMensaje = Time.time;
                mostrandoMensaje = true;
                mensajeOleadaUI.text = "¡Prepárate para la Oleada " + numeroOleada + "!";
                mensajeOleadaUI.gameObject.SetActive(true);
            }
            else
            {
                // Controlar el tiempo de espera del mensaje
                if (Time.time - tiempoUltimoMensaje >= tiempoEntreOleadas)
                {
                    mensajeOleadaUI.gameObject.SetActive(false);
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
    }

    void InstanciarEnemigo(GameObject prefab)
    {
        Vector3 posicionAleatoria = puntoCentral.position + Random.onUnitSphere * radio;
        posicionAleatoria.y = puntoCentral.position.y + 0.1f;

        GameObject nuevoEnemigo = Instantiate(prefab, posicionAleatoria, Quaternion.identity);
        enemigosVivos.Add(nuevoEnemigo);
    }
}
