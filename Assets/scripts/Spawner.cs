using UnityEngine;
using System.Collections.Generic; // Para usar listas

public class Spawner : MonoBehaviour
{
    public GameObject enemigoPrefab;   // Prefab del enemigo a generar
    public Transform puntoCentral;      // Punto central alrededor del cual se generarán los enemigos
    public float radio = 10f;           // Radio alrededor del punto central
    public float intervaloGeneracion = 5f; // Tiempo en segundos entre oleadas

    private float tiempoUltimaGeneracion;
    private int numeroOleada = 1;       // Contador para el número de oleada
    private List<GameObject> enemigosVivos = new List<GameObject>(); // Lista de enemigos vivos

    void Start()
    {
        // Inicializa el tiempo de la última generación
        tiempoUltimaGeneracion = Time.time;
    }

    void Update()
    {
        // Elimina enemigos destruidos de la lista
        enemigosVivos.RemoveAll(enemigo => enemigo == null);

        // Comprueba si no hay enemigos vivos y ha pasado el intervalo de tiempo para la siguiente oleada
        if (enemigosVivos.Count == 0 && Time.time - tiempoUltimaGeneracion >= intervaloGeneracion)
        {
            // Imprime el número de la oleada antes de generar los enemigos
            Debug.Log("Generando oleada número: " + numeroOleada);

            GenerarOleada();
            tiempoUltimaGeneracion = Time.time;
            numeroOleada++; // Incrementa el contador de oleadas después de cada generación
        }
    }

    void GenerarOleada()
    {
        // Determina el número de enemigos en esta oleada (puedes ajustarlo según tus necesidades)
        int numeroDeEnemigos = 2;

        for (int i = 0; i < numeroDeEnemigos; i++)
        {
            // Calcula una posición aleatoria alrededor del punto central
            Vector3 posicionAleatoria = puntoCentral.position + Random.onUnitSphere * radio;
            posicionAleatoria.y = puntoCentral.position.y; // Opcional: Ajusta la altura si es necesario

            // Instancia el enemigo en la posición calculada
            GameObject nuevoEnemigo = Instantiate(enemigoPrefab, posicionAleatoria, Quaternion.identity);

            // Añade el enemigo a la lista de enemigos vivos
            enemigosVivos.Add(nuevoEnemigo);
        }
    }
}
