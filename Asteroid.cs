using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MySecondMonoGame
{
    class Asteroid
    {
        public Vector2 Position;
        public int Speed;
        public int Radius = 59;
        public bool OffScreen = false;
        public int Healths;

        public static readonly Random Rand = new Random();

        public static List<Asteroid> Asteroids = new List<Asteroid>();

        public int Health
        {
            get => Healths;
            set => Healths = value;
        }

        public Asteroid(int newSpeed)
        {
            Healths = 5;
            Speed = newSpeed;
            Position = new Vector2(1280 + Radius, Rand.Next(0, 721));
        }

        public void AsteroidUpdate(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position.X -= Speed * dt;
        }
    }
}
