using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementMeteorites : MonoBehaviour
{
    public float vitesseX; //vitesse X de base
    public float vitesseY; //vitesse Y de base
    private float vitesseRandomX; //vitesse al�atoire en X pour la m�t�orite
    private float vitesseRandomY; //vitesse al�atoire en Y pour la m�t�orite
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

        transform.Translate(vitesseRandomX, vitesseRandomY, 0); //d�place la m�t�orite
        if (transform.position.y <= positionFin) //si la m�t�orite sort de la sc�ne
        {
            Invoke("VitesseMeteorite", 0f); //on lui reattribue une autre vitesse
            transform.position = new Vector2(Random.Range(-deplacementAleatoire, deplacementAleatoire), positionDebut); //on la replace en haut de la sc�ne
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Personnage") //quand la m�t�orite touche le personnage
        {
            GetComponent<Collider2D>().enabled = false; //on d�sactive le collider pour qu'elle passe au travers
        }
    }

    void VitesseMeteorite() //attribue une vitesse X et Y al�atoire
    {
        vitesseRandomX = (Random.Range(-vitesseX, vitesseX));
        vitesseRandomY = (Random.Range(vitesseY * 0.75f, vitesseY * 1.25f));
    }
}
