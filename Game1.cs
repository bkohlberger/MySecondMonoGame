using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MySecondMonoGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //External Content

        private Texture2D ship_Sprite;
        private Texture2D asteroid_Sprite;
        private Texture2D space_Sprite;

        private SpriteFont gameFont;
        private SpriteFont timerFont;

        Ship player = new Ship();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ship_Sprite = Content.Load<Texture2D>("ship");
            asteroid_Sprite = Content.Load<Texture2D>("asteroid");
            space_Sprite = Content.Load<Texture2D>("space");

            gameFont = Content.Load<SpriteFont>("spaceFont");
            timerFont = Content.Load<SpriteFont>("timerFont");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.shipUpdate(gameTime);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(space_Sprite, new Vector2(0,0), Color.White);
            spriteBatch.Draw(ship_Sprite, new Vector2(player.position.X - 34, player.position.Y - 50), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
