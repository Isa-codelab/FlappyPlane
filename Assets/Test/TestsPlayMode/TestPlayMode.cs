using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayMode
{
    private GameController controller;

    private GameObject playerGO;
    private PlayerController player;
    private Rigidbody2D rb;

    [SetUp]
    public void Setup()
    {
        playerGO = new GameObject();
        rb = playerGO.AddComponent<Rigidbody2D>();
        player = playerGO.AddComponent<PlayerController>();

        // Criar puff simples
        player.puff = new GameObject("Puff");
    }

    [UnityTest]
    public IEnumerator Obstacle_DeveMoverParaEsquerda_EAumentarVelocidadeComLevel()
    {
        // Arrange
        var gameObj = new GameObject("Obstacle");
        var obstacle = gameObj.AddComponent<ObstacleController>();

        var gameControllerObj = new GameObject("GameController");
        var gameController = gameControllerObj.AddComponent<GameController>();

        // Aqui você precisa ter um método público no GameController para setar o level
        // (se não tiver, é só criar tipo: public void SetLevel(int l) => level = l;)
        gameController.SetLevel(2); // Ajusta o level para 2

        // injeta a referência do game manualmente
        obstacle.InjectGameController(gameController);

        Vector3 posInicial = obstacle.transform.position;

        // Act → roda 0.5 segundos (meio segundo de jogo)
        yield return new WaitForSeconds(0.5f);
        // Assert → verifica se moveu para a esquerda
        Assert.Less(obstacle.transform.position.x, posInicial.x, "O obstáculo não andou para a esquerda!");

        // Assert → verifica se a velocidade ajustou (4 base + 2 do level = 6)
        Assert.AreEqual(6f, obstacle.GetVelocity(), "A velocidade não foi ajustada pelo level corretamente!");
    }

    [UnityTest]
    public IEnumerator Jump_ShouldApplyVelocityAndInstantiatePuff()
    {
        // Chamar Jump e capturar o puff
        GameObject puffObj = player.Jump();

        // Verificar se a velocidade foi aplicada corretamente
        Assert.AreEqual(Vector2.up * 5f, rb.velocity);

        // Verificar se o puff foi instanciado
        Assert.IsNotNull(puffObj);

        // Esperar mais que o tempo de Destroy
        yield return new WaitForSeconds(0.5f);

        // Verificar se o puff foi destruído
        Assert.IsTrue(puffObj == null || !puffObj);
    }









}
