using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int level = 1;
    private float score = 0f;

    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private float spawntMax = 3f;
    [SerializeField] private float spawntMin = 1f;

    [SerializeField] private float timer = 1f;

    [SerializeField] private GameObject obstacle;
    [SerializeField] private Vector3 posicao;

    [SerializeField] private float posMin = -0.5f;
    [SerializeField] private float posMax = 3f;

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private float proximoLevel = 10f;

    void Start()
    {

    }

    void Update()
    {
        Scores();

        SpawnObstacle();

        LevelUp();

    }


    private void LevelUp()
    {

        if (score >= proximoLevel)
        {

            level++;
            levelText.text = "Level: " + level.ToString();
            proximoLevel *= 2f;

            Debug.Log("Level Up! Level: " + level);
        }

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
            timer = Random.Range(spawntMin/level, spawntMax);

            posicao.y = Random.Range(posMin, posMax);

            Instantiate(obstacle, posicao, Quaternion.identity);
        }
    }

    public int GetLevel()
    {
        return level;
    }
}
