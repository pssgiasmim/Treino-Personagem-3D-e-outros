using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoedaSpawner : MonoBehaviour
{
    public GameObject moedaPrefab; // Referencia o prefab da moeda.
    public Transform[] spawnPoints; //é um array de pontos onde as moedas podem ser intanciadas

    public void SpawnMoeda()
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("Nenhum ponto de psawn configurado no Inspector");
            return;
        }
        int randomIndex = Random.Range(0, spawnPoints.Length); //Escolhe um ponto aleatório
        Instantiate(moedaPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }

    private void Start()
    {
        Debug.Log("Moeda Instanciada");
        SpawnMoeda();
    }
}
