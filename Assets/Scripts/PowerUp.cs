using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float multiplier = .75f;

    private float duriation = 3f;

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine (PickUp(other));
        }
    }

    IEnumerator PickUp(Collider player)
    {


        PlayerController delayWait = player.GetComponent<PlayerController>();
        delayWait.fireRate *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duriation);

        delayWait.fireRate /= multiplier;

        Destroy(gameObject);
        
    }
}
