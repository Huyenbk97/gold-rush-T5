using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawAnim : MonoBehaviour
{
    Animator sawAnimator;
    void Start()
    {
        sawAnimator = GetComponent<Animator>();
    }
}
