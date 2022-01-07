using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour
{
    [SerializeField] Material envMat;

    public float movementSpeed;
    void Update()
    {
        Vector2 offset = envMat.mainTextureOffset;
        offset.y -= Time.deltaTime * movementSpeed;
        envMat.mainTextureOffset = offset;
    }
}
