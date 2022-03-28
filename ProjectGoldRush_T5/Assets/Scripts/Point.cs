using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    public static Point instance;

    public GameObject pointScreen;

    public int totalScore;

    public Text pointText;

    private void Start()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("First"))
        {
            totalScore += 5;
        }
        else if (other.CompareTag("Second"))
        {
            totalScore += 10;

        }
        if (other.CompareTag("First") || other.CompareTag("Second"))
        {
            pointScreen.SetActive(true);
        }
    }

    private void Update()
    {
        pointText.text = totalScore.ToString();
    }


}
