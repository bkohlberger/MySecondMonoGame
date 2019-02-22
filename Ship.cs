using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MySecondMonoGame
{
    class Ship : Controller
    {
        GraphicsDeviceManager _graphics;
        public int Speed = 200;
        public int Radius = 50;
        public static Vector2 DefaultPosition = new Vector2(640, 360);
        public Vector2 Position = DefaultPosition;
        private Direction _direction = Direction.Right;
        private bool _isGameStarted = false;
        public bool IsMoving = false;
        KeyboardState _keyboardStateOld;

        public Ship(bool isGameStarted)
        {
            _isGameStarted = isGameStarted;
            _keyboardStateOld = Keyboard.GetState();
        }

        public void ShipUpdate(GameTime gameTime, Controller gameController)
        {
            KeyboardState kState = Keyboard.GetState();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            IsMoving = false;

            if (kState.IsKeyDown(Keys.A))
            {
                _direction = Direction.Left;
                IsMoving = true;
            }

            if (kState.IsKeyDown(Keys.D))
            {
                _direction = Direction.Right;
                IsMoving = true;
            }

            if (kState.IsKeyDown(Keys.W))
            {
                _direction = Direction.Up;
                IsMoving = true;
            }

            if (kState.IsKeyDown(Keys.S))
            {
                _direction = Direction.Down;
                IsMoving = true;
            }

            if (IsMoving)
            {
                Vector2 tempPosition = Position;
                
                switch (_direction)
                {
                    case Direction.Left:
                        tempPosition.X -= Speed * deltaTime;
                        if (tempPosition.X > 30)
                        {
                            Position.X -= Speed * deltaTime;
                        }
                        break;

                    case Direction.Right:
                        if (tempPosition.X < 1280 - 40)
                        {
                            Position.X += Speed * deltaTime;
                        }
                        break;


                    case Direction.Up:
                        tempPosition.Y -= Speed * deltaTime;
                        if (tempPosition.Y > 40)
                        {
                            Position.Y -= Speed * deltaTime;
                        }
                        break;

                    case Direction.Down:
                        if (tempPosition.Y < 720 - 40)
                        {
                            Position.Y += Speed * deltaTime;
                        }
                        break;
                    
                }
            }
            
            if (kState.IsKeyDown(Keys.Space) && _keyboardStateOld.IsKeyUp(Keys.Space))
            {
                MySounds.ProjectileSound.Play(1, -1, 0);
                Projectile.Projectiles.Add(new Projectile(Position, _direction));
            }

            _keyboardStateOld = kState;
        }
    }
}
