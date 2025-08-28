using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerServices
{
        private float moveSpeed;

        public bool IsPlayerOutOfBounds(float playerY, float limitY)
        {
            return playerY < -limitY || playerY > limitY;
        }

        public PlayerServices(float moveSpeed)
        {
            this.moveSpeed = moveSpeed;
        }

        // Retorna a velocidade de pulo para o player
        public Vector2 GetJumpVelocity()
        {
            return Vector2.up * moveSpeed;
        }

        // Limita a velocidade mínima do player
        public Vector2 LimitVelocity(Vector2 currentVelocity)
        {
            if (currentVelocity.y < -moveSpeed)
                return Vector2.down * moveSpeed;
            return currentVelocity;
        }

     
}
