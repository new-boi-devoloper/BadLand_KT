using UnityEngine;

namespace Player
{
    public class PlayerMovement
    {
        public void Move(Vector2 moveDirection, Transform playerPos, float playerSpeed)
        {
            playerPos.position += (Vector3)(moveDirection * (playerSpeed * Time.deltaTime));
        }

        public void Jump(Rigidbody2D playerRb, float jumpPower)
        {
            playerRb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
}