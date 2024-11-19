using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour , IRotatable
    {
        [field: SerializeField] public float PlayerSpeed { get; private set; }
        [field: SerializeField] public float JumpPower { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public float MaxRotationAngle { get; private set; }
        public Rigidbody2D PlayerRb { get; private set; }

        public static Vector3 PlayerPos { get; private set; }

        private void Start()
        {
            PlayerRb = GetComponent<Rigidbody2D>();
            InitialRotation = 0f;
            CurrentRotation = 0f;
        }

        private void Update()
        {
            PlayerPos = transform.position;
            
            Rotate();
        }

        #region Rotation

        public float InitialRotation { get; set; }
        public float CurrentRotation { get; set; }
        
        public void Rotate()
        {
            PlayerRb.velocity = new Vector2(0 , PlayerRb.velocity.y);
            float fallSpeed = PlayerRb.velocity.y;
            float targetRotation = Mathf.Clamp(fallSpeed * RotationSpeed, -MaxRotationAngle, 0f);
            CurrentRotation = Mathf.Lerp(CurrentRotation, targetRotation, Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, CurrentRotation);
        }

        public void ResetRotation()
        {
            transform.DORotate(Vector3.zero, 0.5f);
        }

        #endregion
    }

    public interface IRotatable
    {
        public float InitialRotation { get; set; }
        public float CurrentRotation { get; set; }

        public void Rotate();
        public void ResetRotation();
    }
}