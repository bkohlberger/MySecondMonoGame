using System;

using Microsoft.Xna.Framework;

namespace MySecondMonoGame
{
    class Asteroid
    {
        public Vector2 Position;
        public int Speed;
        public int Radius = 59;
        public bool OffScreen = false;

        public static readonly Random Rand = new Random();

        public Asteroid(int newSpeed)
        {
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
