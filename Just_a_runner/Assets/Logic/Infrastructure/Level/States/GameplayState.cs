﻿using StateMachines;
using Ecs;

namespace Infrastructure
{
    public class GameplayState : IState
    {
        private GameLoop _gameLoop;
        private Systems _systems;

        public GameplayState(GameLoop gameLoop, LevelData data)
        {
            _gameLoop = gameLoop;
            _systems = data.Systems;
        }

        public void Enter()
        {
            _gameLoop.OnFixedTick += _systems.FixedTick;
            _gameLoop.OnTick += _systems.Tick;
        }

        public void Exit()
        {
            _gameLoop.OnFixedTick -= _systems.FixedTick;
            _gameLoop.OnTick -= _systems.Tick;
        }
    }
}