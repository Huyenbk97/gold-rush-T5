using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffects : MonoBehaviour
{
    public static TriggerEffects instance;

    public GameObject winEffect;
    public GameObject winScreen;
    public GameObject failScreen;
    public GameObject spawnPoint;
    public GameObject spawnObject;
    public GameObject spawnParent;
    
    public List<GameObject> newSpawns;

    public static int counter;

    private void Start()
    {
        counter = 0;
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Spawn();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Finish"))
        {
            if (counter>0)
            {
                winEffect.SetActive(true);
                winScreen.SetActive(true);
            }
            else if (counter <= 0)
            {
                InputController.isMoving = false;
                failScreen.SetActive(true);
            }
        }
        if (other.CompareTag("RealFinish"))
        {
            InputController.isMoving = false;
        }
    }
    public void Spawn()
    {
        GameObject cloned = Instantiate(spawnObject, spawnPoint.transform.position, spawnPoint.transform.rotation, spawnParent.transform);
        newSpawns.Add(cloned);

        if (counter == 0)
        {
            newSpawns[counter].GetComponent<SmoothDamp>().currentLeadTransform = this.transform;
        }
        else
        {
            newSpawns[counter].GetComponent<SmoothDamp>().currentLeadTransform = newSpawns[counter - 1].transform;
        }
        spawnPoint.transform.Translate(0f, 0f, .75f);
        counter++;
    }
}

    

