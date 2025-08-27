using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameControllerTest
{
    private GameServices gameServ;

    [SetUp]
    public void Setup()
    {
        gameServ = new GameServices();

    }

    [Test]
    public void CheckLevelUp_ScoreMaiorQueNextLevel_SubiuDeNível()
    {
        var score = 11;
        var nextlevel = 10;
        var level = 1;

        var result = gameServ.CheckLevelUp(score, level, nextlevel);

        Assert.True(result.LevelUp);
        Assert.AreEqual(2, result.NewLevel);
        Assert.AreEqual(20, result.NewNextLevel);

    }

}
