using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContactHM : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private HardModeGameController HardModegameController;

    void Start()
    {
        GameObject HardModegameControllerObject = GameObject.FindWithTag("HardModeGameController");
        if (HardModegameControllerObject != null)
        {
            HardModegameController = HardModegameControllerObject.GetComponent<HardModeGameController>();
        }
        if (HardModegameController == null)
        {
            Debug.Log("Cannot find 'HardModeGameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Boundary" || other.tag == "Enemy")
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            HardModegameController.GameOver();
        }
        HardModegameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

