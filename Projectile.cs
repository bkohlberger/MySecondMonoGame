using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MySecondMonoGame
{
    class Projectile
    {
        private Vector2 _position;
        private int speed = 800;
        private readonly Direction _direction;

        public static List<Projectile> Projectiles = new List<Projectile>();

        public Projectile(Vector2 newPos, Direction newDir)
        {
            _position = newPos;
            _direction = newDir;
        }
        
        public bool Collided { get; set; } = false;

        public Vector2 Position => _position;

        public int Radius { get; } = 15;

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;

            switch (_direction)
            {
                case Direction.Left:
                    _position.X += speed * deltaTime;
                    break;

                case Direction.Right:
                    _position.X += speed * deltaTime;
                    break;

                case Direction.Up:
                    _position.X += speed * deltaTime;
                    break;

                case Direction.Down:
                    _position.X += speed * deltaTime;
                    break;
            }
        }
    }
}
