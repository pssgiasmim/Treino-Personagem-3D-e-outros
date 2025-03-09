using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform personagem; //Arrastar o personagem para c�.
    public Vector3 offset = new Vector3 (0, 0.95f, -2.9f); //Ajustar a posi��o da c�mera.

    void LateUpdate()
    {
        if (personagem != null)
        {
            transform.position = personagem.position + offset;
        }
    }
}
