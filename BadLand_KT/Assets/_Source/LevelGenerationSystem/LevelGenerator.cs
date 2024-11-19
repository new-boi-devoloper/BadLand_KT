using System.Collections.Generic;
using UnityEngine;
using static Utils.ObjectPooler;

namespace LevelGenerationSystem
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject[] chunksTypes; // префабы чанков для генерации уровня
        [SerializeField] private int poolSize = 10;
        [SerializeField] private int levelSize = 10;

        private Dictionary<GameObject, ObjectPool<LevelChunk>> _chunksPools;

        private void Start()
        {
            CreatePools();
            GenerateLevel();
        }

        private void CreatePools()
        {
            _chunksPools = new Dictionary<GameObject, ObjectPool<LevelChunk>>();

            foreach (var chunkType in chunksTypes)
            {
                var pool = new ObjectPool<LevelChunk>(chunkType.GetComponent<LevelChunk>(), poolSize);
                _chunksPools.Add(chunkType, pool);
            }
        }

        private void GenerateLevel()
        {
            Vector3 currentPosition = Vector3.zero;

            for (int i = 0; i < levelSize; i++)
            {
                // случайный кусок уровня
                GameObject randomChunkType = chunksTypes[Random.Range(0, chunksTypes.Length)];

                if (_chunksPools[randomChunkType].TryGetFromPool(out var chunk))
                {
                    // устанавливаем позицию куска так, чтобы его левая точка совпадала с текущей позицией
                    chunk.transform.position = currentPosition - chunk.LeftConnectionPoint.localPosition;

                    // обновляем текущую позицию для следующего куска
                    currentPosition = chunk.RightConnectionPoint.position;
                }
            }
        }
    }
}