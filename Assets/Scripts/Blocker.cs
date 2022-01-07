using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    public float movementSpeed = 20f;
    private void OnEnable()
    {
        Color color = Random.ColorHSV();
        foreach (Renderer rend in GetComponentsInChildren<MeshRenderer>())
        {
            rend.material.color = color;
        }
    }
}
