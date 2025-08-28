using log4net.Core;
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

        if(game == null)
        {
            game = FindObjectOfType<GameController>();

        }
        
    }
    void Update()
    {
        transform.position += Time.deltaTime * velocity * Vector3.left;

        velocity = 4f + game.GetLevel();
    }

    public void InjectGameController(GameController g) => game = g;
    public float GetVelocity() => velocity;

    
}
