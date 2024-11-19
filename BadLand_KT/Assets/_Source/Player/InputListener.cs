using System;
using UnityEngine;

namespace Player
{
    public class InputListener : MonoBehaviour
    {
        public event Action<Vector2> OnMove;
        public event Action OnJump;
        // public Vector2 MoveDirection { get; private set; }
    
        private void Update()
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");

            Vector2 moveDirection = new Vector2(moveHorizontal, 0).normalized;

            if (moveDirection.magnitude > 0)
            {
                // MoveDirection = moveDirection;
                OnMove?.Invoke(moveDirection);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJump?.Invoke();
            }
        }
    }
}
