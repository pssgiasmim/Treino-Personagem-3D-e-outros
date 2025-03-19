using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Moeda : MonoBehaviour
{
    public GameObject particula;
    public AudioClip somMoeda; //Som que vai soltar quando a moeda for coletada.
    private AudioSource audioSource;
    private MoedaSpawner moedaSpawner; //referencia o spawner
    private int randomIndex;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        moedaSpawner = FindObjectOfType<MoedaSpawner>(); //Encontra o spawner na cena
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Toca o som da moeda
            audioSource.PlayOneShot(somMoeda);

            //Esconde a moeda antes de destruir (para dar tempo de tocar o sonzinho)
            GetComponent<MeshRenderer>().enabled = true;
            //GetComponent<CameraFollow>().enabled = false;

            if (moedaSpawner != null)
            {
                moedaSpawner.SpawnMoeda();

            }


            //Destroi a moeda após o som tocar
           Destroy(gameObject, somMoeda.length);
           Instantiate(particula, this.transform.position, Quaternion.identity);
        }
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
