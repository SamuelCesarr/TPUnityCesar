using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControllerPersonnage : MonoBehaviour
{
    public float vitesseX;
    public float vitesseY;
    public float vitesseXMax;
    public float vitesseSaut;
    public AudioClip sonMort;
    public bool controlsEnabled; //les contr�les peuvent �tre utilis�s
    public float vitesseMaximale;
    public GameObject Meteorite;
    public TMP_Text pointageTexte;
    public int pointage = 0;
    public GameObject objetCoeur;
    public AudioClip sonCoeur;


    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") && controlsEnabled == true) //quand la touche D est appuy�e
        {
            vitesseX = vitesseXMax;

            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey("a") && controlsEnabled == true) //quand la touche A est appuy�e
        {
            vitesseX = -vitesseXMax;

            GetComponent<SpriteRenderer>().flipX = true; //on flip le sprite dans l'autre direction
        }
        else
        {
            vitesseX = GetComponent<Rigidbody2D>().velocity.x; //si aucune touche n'est appuy�e la vitesse reste la m�me
        }


        //Commande de saut
        if (Input.GetKeyDown("w") && Physics2D.OverlapCircle(transform.position, 0.5f) && !GetComponent<Animator>().GetBool("saut") && controlsEnabled == true) //quand la touche W est appuy�e et qu'on touche au plancher
        {
            vitesseY = vitesseSaut;
            GetComponent<Animator>().SetBool("saut", true);
        }
        else
        {
            vitesseY = GetComponent<Rigidbody2D>().velocity.y;
        }


        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);

        //Gestion des animations

        //Animation de course
        if (vitesseX > 0.9f || vitesseX < -0.9f)
        {
            GetComponent<Animator>().SetBool("course", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("course", false);
        }        

    }
    void OnCollisionEnter2D(Collision2D collision)

    {
        //Animation de saut
        if (Physics2D.OverlapCircle(transform.position, 0.5f)) //si le collider du personnage touche un autre collider (le plancher)
        {
            GetComponent<Animator>().SetBool("saut", false);
        }

        //Animation de mort
        if (collision.gameObject.tag == "Meteorite") //Quand le personnage touche l'objet tagg�
        {
            GetComponent<Animator>().SetBool("mort", true); //on active la mort
            GetComponent<AudioSource>().PlayOneShot(sonMort, 1f); //on joue le son de mort
            controlsEnabled = false; //on d�sactive les contr�les du personnage
            Invoke("RelancerJeu", 2f);
        }
        else if (collision.gameObject.name == "Coeur") //Quand le personnage touche un coeur
        {
            pointage++; //on augmente le pointage de 1
            collision.gameObject.SetActive(false); //on d�sactive le coeur
            GetComponent<AudioSource>().PlayOneShot(sonCoeur, 2f); //on joue le son du coeur
            
            Invoke("ActiveCoeur", 1f);

            pointageTexte.text = "Pointage: " + pointage.ToString(); //on affiche le pointage
        }
    }

    void RelancerJeu()
    {
        SceneManager.LoadScene(1); //on relance la premi�re sc�ne d'introduction
    }
    void ActiveCoeur()
    {
        objetCoeur.SetActive(true); //on r�active le coeur
    }

}
