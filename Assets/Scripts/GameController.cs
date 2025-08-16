using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float spawntMax = 3f;
    [SerializeField] private float spawntMin = 1f;

    [SerializeField] private float timer = 1f;

    [SerializeField] private GameObject obstacle;
    [SerializeField] private Vector3 posicao;

    [SerializeField] private float posMin = -0.3f;
    [SerializeField] private float posMax = 2.4f;
    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = Random.Range(spawntMin, spawntMax);

            posicao.y = Random.Range(posMin,posMax);

            Instantiate(obstacle,posicao, Quaternion.identity);
        }
        
    }
}
