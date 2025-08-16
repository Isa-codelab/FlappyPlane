using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float score = 0f;
    [SerializeField] private float spawntMax = 3f;
    [SerializeField] private float spawntMin = 1f;

    [SerializeField] private float timer = 1f;

    [SerializeField] private GameObject obstacle;
    [SerializeField] private Vector3 posicao;

    [SerializeField] private float posMin = -0.5f;
    [SerializeField] private float posMax = 3f;

    [SerializeField] private TextMeshProUGUI scoreText;
    void Start()
    {
        
    }

    void Update()
    {
        Scores();

        SpawnObstacle();

    }

    private void Scores()
    {
        
        score += Time.deltaTime;

        scoreText.text = "Score: " + Mathf.RoundToInt(score).ToString();

    }

    private void SpawnObstacle()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = Random.Range(spawntMin, spawntMax);

            posicao.y = Random.Range(posMin, posMax);

            Instantiate(obstacle, posicao, Quaternion.identity);
        }
    }
}
