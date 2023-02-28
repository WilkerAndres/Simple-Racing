﻿using System.Collections.Generic;
using UnityEngine;

namespace RoadGeneration
{
    public class RoadData : MonoBehaviour
    {
        [SerializeField] private List<Chunk> _activeChunks;
        [SerializeField] private Chunk[] _presetChunks;

        [SerializeField] private float _distanceToGenerateNewChunk; //= 100
        [SerializeField] private float _distanceToRemoveOldChunk; //= 25

        public Vector3 FirstChunkPosition
                => (ActiveChunks.Count < 1) ? Vector3.zero
            : ActiveChunks[0].transform.position;

        public Vector3 LastChunkPosition
                => (ActiveChunks.Count < 1) ? Vector3.zero
            : ActiveChunks[ActiveChunks.Count - 1].transform.position;

        public Chunk[] PresetChunks
            => _presetChunks;

        public List<Chunk> ActiveChunks
            => _activeChunks;

        public float DistanceToGenerateNewChunk
            => _distanceToGenerateNewChunk;

        public float DistanceToRemoveOldChunk
            => _distanceToRemoveOldChunk;
    }
}