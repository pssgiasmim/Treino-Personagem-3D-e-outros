using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform personagem; //Arrastar o personagem para cá.
    public Vector3 offset = new Vector3 (0, 0.95f, -2.9f); //Ajustar a posição da câmera.

    void LateUpdate()
    {
        if (personagem != null)
        {
            transform.position = personagem.position + offset;
        }
    }
}
