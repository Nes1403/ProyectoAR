using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirador : MonoBehaviour{

    public GameObject prefabBala;

    public float velocidad;

    public void Dispara(){
        GameObject nuevaBala = Instantiate(prefabBala, transform.position, transform.rotation);
        nuevaBala.GetComponent<Rigidbody>().velocity = transform.forward * velocidad;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
