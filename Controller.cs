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
    class Controller
    {
        public List<Asteroid> asteroids = new List<Asteroid>();
        public double timer = 2D;
        public double maxTime = 2D;
        public int nextSpeed = 240;

        public void conUpdate(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;

            if (timer <= 0)
            {
                asteroids.Add(new Asteroid(nextSpeed));
                timer = maxTime;
                if (maxTime > 0.5)
                {
                    maxTime -= 0.1D;
                }

                if (nextSpeed < 720)
                {
                    nextSpeed += 4;
                }
            }
        }
    }
}
