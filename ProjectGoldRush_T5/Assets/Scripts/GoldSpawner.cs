using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    public GameObject moneySpawnPoint;
    public GameObject moneyParent;
    public GameObject goldEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("First") || other.CompareTag("Second"))
        {


            GameObject goldObject = Instantiate(TriggerEffects.instance.newSpawns[TriggerEffects.instance.newSpawns.Count-1], moneySpawnPoint.transform.position, moneySpawnPoint.transform.rotation, moneyParent.transform);
            goldEffect.GetComponent<ParticleSystem>().Play();
            goldObject.GetComponent<SmoothDamp>().enabled = false;
            goldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
            goldObject.GetComponent<Rigidbody>().freezeRotation = true;
            
            Destroy(other.gameObject);
            TriggerEffects.instance.newSpawns.RemoveAt(TriggerEffects.instance.newSpawns.Count-1);
            moneyParent.transform.Translate(0f, .35f, 0f);
            
        }
    }

}
