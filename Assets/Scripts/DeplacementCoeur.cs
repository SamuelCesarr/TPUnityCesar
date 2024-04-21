using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementCoeur : MonoBehaviour
{
    public float positionDebut;
    public float deplacementAleatoire;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Deplacement aleatoire lorsque le coeur entre en contact avec le personnage
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Personnage")
        {
            transform.position = new Vector2(Random.Range(-deplacementAleatoire, deplacementAleatoire), positionDebut);
        }
    }
}
