using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Tarea1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Color fondo = new Color(51, 134, 255);
        private SpriteFont _font;
        Texture2D pez;//aqui esta la clave
        Texture2D fondoPantalla;
        Vector2 posicion;
        Song song;
        float vel;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            posicion = new Vector2((_graphics.PreferredBackBufferWidth / 2)-30, (_graphics.PreferredBackBufferHeight / 2)-30);
            vel = 10f;
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            pez = Content.Load<Texture2D>("pez1");
            fondoPantalla = Content.Load<Texture2D>("fondo");
            song = Content.Load<Song>("flowergarden");
            
            MediaPlayer.Volume = 0.20F;
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true; 
            _font = Content.Load<SpriteFont>("fuente1");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (gameTime.TotalGameTime.Milliseconds % 120 == 0)
            {
                pez = Content.Load<Texture2D>("pez2");
            }
            if (gameTime.TotalGameTime.Milliseconds % 170 == 0)
            {
                pez = Content.Load<Texture2D>("pez3");
            }
            if (gameTime.TotalGameTime.Milliseconds %220 == 0)
            {
                pez = Content.Load<Texture2D>("pez1");
            }
            if (gameTime.TotalGameTime.Milliseconds % 270 == 0)
            {
                pez = Content.Load<Texture2D>("pez4");
            }

            var teclaestado = Keyboard.GetState();

            if (teclaestado.IsKeyDown(Keys.Up) && posicion.Y>=3)
            {
                posicion.Y -= vel;
            }
            if (teclaestado.IsKeyDown(Keys.Down) && posicion.Y <= _graphics.GraphicsDevice.Viewport.Height - 135)
            {
                posicion.Y += vel;
            }
            if (teclaestado.IsKeyDown(Keys.Left) && posicion.X >= 3)
            {
                posicion.X -= vel;
            }
            if (teclaestado.IsKeyDown(Keys.Right) && posicion.X <= _graphics.GraphicsDevice.Viewport.Width - 130)
            {
                posicion.X += vel;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(fondo);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
                _spriteBatch.Draw(fondoPantalla, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
                _spriteBatch.DrawString(_font, "Josue Isaac Herrera Campos", new Vector2(1, 1), Color.White);
                _spriteBatch.DrawString(_font, "120 FPS", new Vector2(_graphics.PreferredBackBufferWidth / 2, 1), Color.White);
                _spriteBatch.DrawString(_font, "HC21018", new Vector2(_graphics.PreferredBackBufferWidth - 76, 1), Color.White);

            _spriteBatch.Draw(pez, posicion, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}