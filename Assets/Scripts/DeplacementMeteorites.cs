using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementMeteorites : MonoBehaviour
{
    public float vitesseX; //vitesse X de base
    public float vitesseY; //vitesse Y de base
    private float vitesseRandomX; //vitesse aléatoire en X pour la météorite
    private float vitesseRandomY; //vitesse aléatoire en Y pour la météorite
    public float positionFin;
    public float positionDebut;
    public float deplacementAleatoire;
    public GameObject Personnage;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("VitesseMeteorite", 0f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(vitesseRandomX, vitesseRandomY, 0); //déplace la météorite
        if (transform.position.y <= positionFin) //si la météorite sort de la scène
        {
            Invoke("VitesseMeteorite", 0f); //on lui reattribue une autre vitesse
            transform.position = new Vector2(Random.Range(-deplacementAleatoire, deplacementAleatoire), positionDebut); //on la replace en haut de la scène
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Personnage") //quand la météorite touche le personnage
        {
            GetComponent<Collider2D>().enabled = false; //on désactive le collider pour qu'elle passe au travers
        }
    }

    void VitesseMeteorite() //attribue une vitesse X et Y aléatoire
    {
        vitesseRandomX = (Random.Range(-vitesseX, vitesseX));
        vitesseRandomY = (Random.Range(vitesseY * 0.75f, vitesseY * 1.25f));
    }
}
