using System;
using UnityEngine;

namespace Player
{
    public class PlayerInvoker : IDisposable
    {
        private InputListener _inputListener;
        private PlayerMovement _playerMovement;
        private Player _player;

        public PlayerInvoker(Player player, InputListener inputListener, PlayerMovement playerMovement)
        {
            _player = player;
            _inputListener = inputListener;
            _playerMovement = playerMovement;
        
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            _inputListener.OnMove += InvokeMove;
            _inputListener.OnJump += InvokeJump;
            _inputListener.OnJump += InvokeRotation;
        }
    
        public void Dispose()
        {
            _inputListener.OnMove -= InvokeMove;
            _inputListener.OnJump -= InvokeJump;
            _inputListener.OnJump -= InvokeRotation;
        }

        private void InvokeMove(Vector2 moveDirection)
        {
            _playerMovement.Move(moveDirection, _player.transform, _player.PlayerSpeed);
        }

        private void InvokeJump()
        {
            _playerMovement.Jump(_player.PlayerRb, _player.JumpPower);
        }

        private void InvokeRotation()
        {
            _player.ResetRotation();
        }
    }
}