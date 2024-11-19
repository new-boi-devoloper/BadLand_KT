using Player;
using UnityEngine;

namespace Managers
{
    public class Boostrapper : MonoBehaviour
    {
        [field: SerializeField] public Player.Player Player { get; private set; }
        [field: SerializeField] public InputListener InputListener { get; private set; }

        private PlayerInvoker _playerInvoker;
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerMovement = new PlayerMovement();
            _playerInvoker = new PlayerInvoker(Player, InputListener, _playerMovement);
        }
    }
}