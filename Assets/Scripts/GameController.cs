using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float timer = 1f;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private Vector3 posicao;
    void Start()
    {
        
    }

    void Update()
    {
        timer -= timer - Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 1f;

            Instantiate(obstacle,posicao, Quaternion.identity);
        }
        
    }
}
