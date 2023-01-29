﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs.Systems;
using MovementSystem;
using InputSystem;


namespace MovementSystem
{
    public struct MoveDirection
    {
        public CurveReader AccelerationReader;
        public AnimationCurve Acceleration;
        public float Velocity;
    }
}
