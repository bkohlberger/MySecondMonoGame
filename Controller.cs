using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MySecondMonoGame
{
    class Controller
    {
        public List<Asteroid> Asteroids = new List<Asteroid>();
        public double Timer = 2D;
        public double MaxTime = 2D;
        public int NextSpeed = 240;
        public float TotalTime = 0f;

        public bool InGame = false;

        public void ConUpdate(GameTime gameTime)
        {
            if (InGame)
            {
                Timer -= gameTime.ElapsedGameTime.TotalSeconds;
                TotalTime += (float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                KeyboardState kState = Keyboard.GetState();
                if (kState.IsKeyDown(Keys.Enter))
                {
                    InGame = true;
                    TotalTime = 0f;
                    Timer = 2D;
                    MaxTime = 2D;
                    NextSpeed = 240;
                }
            }

            if (Timer <= 0)
            {
                Asteroids.Add(new Asteroid(NextSpeed));
                Timer = MaxTime;
                if (MaxTime > 0.5)
                {
                    MaxTime -= 0.1D;
                }

                if (NextSpeed < 720)
                {
                    NextSpeed += 4;
                }
            }
        }
    }
}
