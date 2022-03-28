using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("First") || other.CompareTag("Second"))
        {
            for (int i = other.gameObject.GetComponent<SmoothDamp>().number; i <= TriggerEffects.instance.newSpawns.Count-1; i++)
            {
                TriggerEffects.counter--;

                Destroy(TriggerEffects.instance.newSpawns[TriggerEffects.instance.newSpawns.Count - 1]);
                TriggerEffects.instance.newSpawns.RemoveAt(TriggerEffects.instance.newSpawns.Count - 1);
                

                TriggerEffects.instance.spawnPoint.transform.Translate(0f, 0f, -.75f);
            }

        }
        if (TriggerEffects.counter<=0)
        {
            TriggerEffects.instance.failScreen.SetActive(true);
            InputController.isMoving = false;
        }
    }

}