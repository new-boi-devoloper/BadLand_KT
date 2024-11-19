using System;
using LevelGenerationSystem;
using UnityEngine;
using static Utils.ObjectPooler;

namespace LevelGenerationSystem
{
    public class LevelChunk : MonoBehaviour, IPooledObject
    {
        [field: SerializeField] public Transform LeftConnectionPoint { get; private set; }
        [field: SerializeField] public Transform RightConnectionPoint { get; private set; }

        public event Action<IPooledObject> OnPooledObjectReturn;

        public void OnReturnToPool()
        {
            OnPooledObjectReturn?.Invoke(this);
        }

        public void SetActive(bool state)
        {
            gameObject.SetActive(state);
        }

    }
}