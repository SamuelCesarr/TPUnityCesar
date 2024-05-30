using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenererMeteorites : MonoBehaviour
{
    public GameObject meteoriteOriginale;
    public int numMeteorites;
    public int maxMeteorites;
    public GameObject Personnage;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("clonage", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void clonage()
    {
        
        if (numMeteorites < maxMeteorites) //quand il y a moins de m�t�orites que la limite permise
        {
        numMeteorites++; //on ajoute le nombre de m�t�orites par 1
        GameObject cloneMeteorite = Instantiate(meteoriteOriginale); //on clone l'objet m�t�orite
        cloneMeteorite.SetActive(true); //on active le clone seulement
        cloneMeteorite.transform.position = new Vector2(Random.Range(Personnage.transform.position.x-5, Personnage.transform.position.x+5), Personnage.transform.position.y + 9); //on lui donne une position al�atoire par rapport � la position du personnage
        }
    }
}
