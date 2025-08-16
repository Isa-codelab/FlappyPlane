using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField ]private float velocity = 4f;
    [SerializeField] private GameObject me;
    [SerializeField] private GameController game;

    void Start()
    {
        Destroy(me, 5f);

        game = FindObjectOfType<GameController>();
        
    }
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * velocity;

        velocity = 4f + game.GetLevel();
    }
}
