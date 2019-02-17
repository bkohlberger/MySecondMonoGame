using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace MySecondMonoGame
{
    class Ship
    {
        public int Speed = 200;
        static public Vector2 DefaultPosition = new Vector2(640, 360);
        public Vector2 Position = DefaultPosition;

        public void ShipUpdate(GameTime gameTime, Controller gamController)
        {
            KeyboardState kState = Keyboard.GetState();

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (gamController.InGame)
            {
                if (kState.IsKeyDown(Keys.D) && Position.X < 1280 - 40)
                {
                    Position.X += Speed * dt;
                }

                if (kState.IsKeyDown(Keys.A) && Position.X > 30)
                {
                    ;
                    Position.X -= Speed * dt;
                }

                if (kState.IsKeyDown(Keys.S) && Position.Y < 720 - 40)
                {
                    Position.Y += Speed * dt;
                }

                if (kState.IsKeyDown(Keys.W) && Position.Y > 40)
                {
                    Position.Y -= Speed * dt;
                }
            }
        }
    }
}
