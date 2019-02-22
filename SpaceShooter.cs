using System;
using System.Globalization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MySecondMonoGame
{

    public static class MySounds
    {
        public static SoundEffect ProjectileSound;
    }

    public class SpaceShooter : Game
    {
        public SpriteBatch SpriteBatch;

        //External Content
        private Texture2D _shipSprite;
        private Texture2D _asteroidSprite;
        private Texture2D _spaceSprite;
        private Texture2D _bulletSprite;

        private SpriteFont _gameFont;
        private SpriteFont _timerFont;

        

        private int asteroidsShot = 0;

        //Player Objects
        readonly Ship _player = new Ship(false);
        readonly Controller _gameController = new Controller();

        public SpaceShooter()
        {
            var graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            //Load Game Graphics
            _shipSprite = Content.Load<Texture2D>("ship");
            _asteroidSprite = Content.Load<Texture2D>("asteroid");
            _spaceSprite = Content.Load<Texture2D>("space");
            _bulletSprite = Content.Load<Texture2D>("bullet");

            _gameFont = Content.Load<SpriteFont>("spaceFont");
            _timerFont = Content.Load<SpriteFont>("timerFont");

            MySounds.ProjectileSound = Content.Load<SoundEffect>("blip");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Player Updates
            foreach (Projectile proj in Projectile.Projectiles)
            {
                proj.Update(gameTime);
            }
            
            foreach (Projectile projectile in Projectile.Projectiles)
            {
                foreach (Asteroid asteroid in _gameController.Asteroids)
                {
                    int sum = projectile.Radius + asteroid.Radius;

                    if (Vector2.Distance(projectile.Position, asteroid.Position) < sum)
                    {
                        projectile.Collided = true;
                        asteroid.Health--;
                    }
                }
            }

            Projectile.Projectiles.RemoveAll(p => p.Collided);
            
            _player.ShipUpdate(gameTime, _gameController);
            _gameController.ControllerUpdate(gameTime);

            for (int i = 0; i < _gameController.Asteroids.Count; i++)
            {
                _gameController.Asteroids[i].AsteroidUpdate(gameTime);

                if (_gameController.Asteroids[i].Position.X < (0 - _gameController.Asteroids[i].Radius))
                {
                    _gameController.Asteroids[i].OffScreen = true;
                }

                if (_gameController.Asteroids[i].Health <= 0)
                {
                    _gameController.Asteroids[i].OffScreen = true;
                    asteroidsShot++;
                }

                int sum = _gameController.Asteroids[i].Radius + 30;
                
                if (Vector2.Distance(_gameController.Asteroids[i].Position, _player.Position) < sum)
                {
                    _gameController.InGame = false;
                    _player.Position = Ship.DefaultPosition;
                    i = _gameController.Asteroids.Count;
                    _gameController.Asteroids.Clear();
                    asteroidsShot = 0;
                }
            }

            _gameController.Asteroids.RemoveAll(a => a.OffScreen);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin();

            SpriteBatch.Draw(_spaceSprite, new Vector2(0,0), Color.White);
            SpriteBatch.Draw(_shipSprite, new Vector2(_player.Position.X - 34, _player.Position.Y - 50), Color.White);

            for (int i = 0; i < _gameController.Asteroids.Count; i++)
            {
                Vector2 tempPos = _gameController.Asteroids[i].Position;
                int tempRadius = _gameController.Asteroids[i].Radius;

                SpriteBatch.Draw(_asteroidSprite, new Vector2(tempPos.X - tempRadius, tempPos.Y - tempRadius), Color.White);
            }

            if (_gameController.InGame == false)
            {
                string menuMessage = "Press Enter to Begin!" +
                                     "\n\nUse WSAD keys to move your ship" +
                                     "\n\nShoot with SPACE" +
                                     "\n\nPress ESC to Exit!";
                Vector2 sizeOfText = _gameFont.MeasureString(menuMessage);
                SpriteBatch.DrawString(_gameFont, menuMessage, new Vector2(640 - sizeOfText.X/2, 200), Color.Yellow);
            }

            SpriteBatch.DrawString(_timerFont, $"Time: {Math.Floor(_gameController.TotalTime).ToString(CultureInfo.CurrentCulture)}", new Vector2(3,3),Color.White );
            SpriteBatch.DrawString(_timerFont, $"Asteroids Shot: {asteroidsShot.ToString()}", new Vector2(400,3),Color.White );

            foreach (Projectile proj in Projectile.Projectiles)
            {
                SpriteBatch.Draw(_bulletSprite, new Vector2(proj.Position.X - proj.Radius, proj.Position.Y - proj.Radius), Color.White);
            }

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
