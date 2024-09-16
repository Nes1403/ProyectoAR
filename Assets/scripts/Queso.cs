using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using TMPro;
using UnityEngine;

public class Queso : MonoBehaviour
{
    public int salud;
    public Text gameOverText;
    public GameObject mensajePrefab;


    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }



    public void OnCollisionEnter(Collision collision){
        if(collision.collider.TryGetComponent(out Raton atacable)){
            salud -= 1;
            if(salud <= 0){
                Destroy(gameObject);
                GameOver();
            }
        }
    }


    void GameOver()
    {
        Time.timeScale = 0;
        GameObject mensaje = Instantiate(mensajePrefab);
        TextMeshProUGUI texto = mensaje.GetComponentInChildren<TextMeshProUGUI>();
        texto.text = "Game Over";
    }
}
