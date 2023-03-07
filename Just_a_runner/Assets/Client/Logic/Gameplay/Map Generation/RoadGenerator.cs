﻿using System.Collections.Generic;
using UnityEngine;
using Ecs;

namespace RoadGeneration
{
    public class RoadGenerator : ITickable
    {
        private Transform _character;
        private RoadData _data;

        public RoadGenerator(CharacterMarker characterMarker, RoadData roadData)
        {
            _character = characterMarker.transform;
            _data = roadData;
        }

        public void Tick(float deltaTime)
        {
            if ((_data.LastChunk.transform.position - _character.position)
                .magnitude < _data.DistanceToGenerateNewChunk)
                Generate(_data, _character.position);
        }

        private void Generate(RoadData data, Vector3 characterPosition)
        {
            GenerateChunkAhead(data);

            if ((characterPosition - data.FirstChunkPosition.transform.position)
                .magnitude > data.DistanceToRemoveOldChunk)
                RemoveFirstChunk(data.ActiveChunks);
        }

        private void GenerateChunkAhead(RoadData data)
        {
            if (data.PresetChunks.Length < 1)
                return;

            var chunk = GetRandomChunk(data.PresetChunks);

            var chunkPosition = data.LastChunk == null ? Vector3.zero
                : data.LastChunk.transform.position + data.LastChunk.Length * Vector3.forward;

            data.ActiveChunks.Add(Object.Instantiate(chunk, chunkPosition, Quaternion.identity));
        }

        private void RemoveFirstChunk(List<Chunk> activeChunks)
        {
            if (activeChunks.Count < 1)
                return;

            var firstChunk = activeChunks[0];

            activeChunks.Remove(firstChunk);
            firstChunk.Entity.Destroy();
        }

        private Chunk GetRandomChunk(Chunk[] chunks)
            => chunks[Random.Range(0, chunks.Length)];
    }
}