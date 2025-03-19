using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animação : MonoBehaviour
{
    public float velociMovimento = 5f; //Velocidade de movimento do personnagem.
    public float forcaPulo = 5f; //froça  do pulo.
    public Transform cameraTransform; //Referência a câmera que deve seguir o personagem.
    private Rigidbody rigidbody; //Armazena o Rigidbody do personagem para aplicar física.
    private bool isGrounded; //Verifica se o personagem está no chão.
    private Animator anim;
    private AudioSource audioSource;
    public AudioClip somPulo; //Som do pulo
    public AudioClip somCorrer; //Som correr personagem

    //No inicio do jogo vai ser pego o Rigidbody anexado no inspector.
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Chama os métodos de movimentação (Move()), pulo (Jump()) e para manter a câmera seguindo o jogador (FollowCamera()).
    void Update()
    {
        Mover();
        Pular();

      
    }

    void Mover()
    {
        float MoverX = 0f;
        float MoverZ = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoverX = -1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoverX = 1f;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            MoverZ = 1f;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            MoverZ = -1f;
        }
        else 
        {
            MoverX = 0;
            MoverZ = 0;
        }

        Vector3 direcaoMovimento = new Vector3(MoverX, 0f, MoverZ).normalized;
        transform.Translate(direcaoMovimento * velociMovimento * Time.deltaTime, Space.World);
        //Move o personagem usando Translate(), multiplicando pela moveSpeed e Time.deltaTime para suavizar o movimento.

        
        anim.SetFloat("Velocidade", direcaoMovimento.magnitude);
       
        //Toca o som da voz quando ele correr
        if (direcaoMovimento.magnitude > 0 && !audioSource.isPlaying)
        {
            audioSource.clip = somCorrer;
            audioSource.Play();
        }
        else if (direcaoMovimento.magnitude == 0)
        {
            //audioSource.Stop();
        }



    }

    void Pular()
    {
       if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
       {
           // rigidbody.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            isGrounded = false;

            anim.SetTrigger("Muda");

            if (isGrounded == false)
            {
                audioSource.clip = somPulo;
                audioSource.Play();
            }
            
        }
        
       //Verifica se o jogador pressionou a tecla espaço e se está no chão.
       //Aplica força para cima (Vector3.up * forcaPulo).
       //Define isGrounded como falso para evitar múltipos pulos no ar.
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // Detecta colisões do personagem. Se colidir  com algum objeto que a tag ground, permite que o jogador pule novamente.

        /*if (collision.gameObject.CompareTag("Moeda"))
        {
            //Toca o som da moeda e destroi ela
            collision.gameObject.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject, 0.2f);
        }*/
    }




}
