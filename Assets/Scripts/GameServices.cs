using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameServices 
{
    // para calcular score 
    public float ScoreCalculate(float score)
    {
        
        return score + Time.deltaTime;
    }

    // estrutura para devolver v�rias informa��es sobre o level
    public struct LevelUpResult
    {
        public bool LevelUp;
        public int NewLevel;
        public float NewNextLevel;
    }

    // M�todo que verifica se houve level up
    public LevelUpResult CheckLevelUp(float score, int level, float nextLevel)
    {
        LevelUpResult result = new LevelUpResult
        {
            LevelUp = false,
            NewLevel = level,
            NewNextLevel = nextLevel
        };

        // Se j� atingiu ou passou do limite
        if (score >= nextLevel)
        {
            result.LevelUp = true;
            result.NewLevel = level + 1;
            result.NewNextLevel = nextLevel * 2f; // dobra a meta
        }

        return result;
    }

}
