using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float nextLevel = 10f;
    private int level = 1;

    private float score = 0f;

    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private float spawntMax = 3f;
    [SerializeField] private float spawntMin = 1f;


    [SerializeField] private float posMin = -0.5f;
    [SerializeField] private float posMax = 3f;

    [SerializeField] private float timer = 1f;

    [SerializeField] private GameObject obstacle;
    [SerializeField] private Vector3 posicao;
    [SerializeField] private AudioClip soundLevelUp;

    private Vector3 cameraposition;
    private GameServices gameService;
    

    void Start()
    {
        if (Camera.main != null)
            cameraposition = Camera.main.transform.position;
        else
            cameraposition = Vector3.zero;

        //atribuindo a posicao da camera
        //cameraposition = Camera.main.transform.position;
        gameService = new GameServices();
    }

    void Update()
    {
        float v = gameService.ScoreCalculate(score);
        score = v;
        UpdateScoreUI();

        var result = gameService.CheckLevelUp(score, level, nextLevel);

        if (result.LevelUp)
        {
            level = result.NewLevel;
            nextLevel = result.NewNextLevel;

            UpdateLevelUI();
            if (soundLevelUp != null)
            {
                AudioSource.PlayClipAtPoint(soundLevelUp, cameraposition);
            }
        }

        SpawnObstacle();

        

    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Mathf.RoundToInt(score).ToString();
        }
    }

    private void UpdateLevelUI()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + level.ToString();
        }
    }

    //private void LevelUp()
    //{

    //    if (score >= proximoLevel)
    //    {
    //        AudioSource.PlayClipAtPoint(soundLevelUp, cameraposicao);

    //        level++;
    //        levelText.text = "Level: " + level.ToString();
    //        proximoLevel *= 2f;

    //    }

    //}
    //private void Scores()
    //{

    //    score = score + Time.deltaTime;

    //    if (scoreText != null)
    //    {
    //        scoreText.text = "Score: " + Mathf.RoundToInt(score).ToString();

    //    }

    //}
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

    public void SetLevel(int l) => level = l;   
}
