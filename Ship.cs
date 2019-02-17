using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MySecondMonoGame
{
    class Ship
    {
        public int speed = 180;
        static public Vector2 defauldPosition = new Vector2(640, 360);
        public Vector2 position = defauldPosition;

        public void shipUpdate(GameTime gameTime, Controller gamController)
        {
            KeyboardState kState = Keyboard.GetState();

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (gamController.inGame)
            {
                if (kState.IsKeyDown(Keys.D))
                {
                    position.X += speed * dt;
                }

                if (kState.IsKeyDown(Keys.A))
                {
                    ;
                    position.X -= speed * dt;
                }

                if (kState.IsKeyDown(Keys.S))
                {
                    position.Y += speed * dt;
                }

                if (kState.IsKeyDown(Keys.W))
                {
                    position.Y -= speed * dt;
                }
            }
        }
    }
}
