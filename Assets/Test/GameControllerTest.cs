using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameControllerTest
{
    private GameServices gameServ;
    private PlayerServices service;

    [SetUp]
    public void Setup()
    {
        gameServ = new GameServices();
        service = new PlayerServices(5f);

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

    [Test]
    public void CheckLevelUp_ScoreMenorQueNextLevel_NaoSobedeNivel()
    {
        var score = 8;
        var nextlevel = 10;
        var level = 1;

        var result = gameServ.CheckLevelUp(score, level, nextlevel);

        Assert.False(result.LevelUp);
        Assert.AreEqual(1, result.NewLevel);
        Assert.AreEqual(10, result.NewNextLevel);

    }

    [Test]
    public void GetJumpVelocity_ShouldReturnUpVectorTimesMoveSpeed()
    {
        Vector2 velocity = service.GetJumpVelocity();
        Assert.AreEqual(Vector2.up * 5f, velocity);
    }

    [Test]
    public void LimitVelocity_ShouldClampDownwardVelocity()
    {
        Vector2 vel = Vector2.down * 10f;
        Vector2 clamped = service.LimitVelocity(vel);
        Assert.AreEqual(Vector2.down * 5f, clamped);
    }

    [Test]
    public void IsPlayerOutOfBounds_ShouldReturnTrue_WhenOutsideLimits()
    {

        // Fora do limite superior
        Assert.IsTrue(service.IsPlayerOutOfBounds(6f, 5.5f));

        // Fora do limite inferior
        Assert.IsTrue(service.IsPlayerOutOfBounds(-6f, 5.5f));

        // Dentro do limite
        Assert.IsFalse(service.IsPlayerOutOfBounds(0f, 5.5f));
    }

}
