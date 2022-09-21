﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace Tarea1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        GameTime tiempo;

        Texture2D fondoPantalla;
        Texture2D pared;

        Color fondo = new Color(51, 134, 255);
        private SpriteFont _font;
        Texture2D pez;//aqui esta la clave
        Vector2 posicionpez;

        Texture2D gusano;
        Vector2 posiciongusano;
        string puntaje;
        int pezDireccion = 0; //1=izquierda 0=derecha

        Texture2D tiburon;
        Vector2 posiciontiburon;
        //int puntaje1 = 0;
        int tiburonDireccion = 0; //1=izquierda 0=derecha

        Song song;
        float vel;
        bool iniciojuego = false;
        Rectangle[] rects;//arreglo maneja las coordenadas de las intercepciones de sprite

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this._graphics.PreferredBackBufferWidth = 1366;//ancho pantalla
            this._graphics.PreferredBackBufferHeight = 700;//alto
            
        }

        void crearrectangulos()
        {
            rects = new Rectangle[3];
            rects[0] = new Rectangle();
            rects[0] = new Rectangle((int)posicionpez.X+10,(int)posicionpez.Y,pez.Width-20,pez.Height);
            rects[1] = new Rectangle((int)posiciongusano.X, (int)posiciongusano.Y, gusano.Width, gusano.Height);
            rects[2] = new Rectangle((int)posiciontiburon.X, (int)posiciontiburon.Y+53, tiburon.Width, tiburon.Height-60);

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            posicionpez = new Vector2((_graphics.PreferredBackBufferWidth / 2) - 30, (_graphics.PreferredBackBufferHeight / 2) - 30);
            vel = 5f;
            Random rnd = new Random();
            posiciongusano = new Vector2(rnd.Next(25, 1290), rnd.Next(105, 650));//105,650 Y  // x 25,1290

            Random rand = new Random();
            posiciontiburon = new Vector2(-200, rand.Next(25, 570));//105,650 Y  // x 25,1290
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            pez = Content.Load<Texture2D>("pez/pezderecha1");
            gusano = Content.Load<Texture2D>("gusano/gusano1");
            tiburon = Content.Load<Texture2D>("tiburon/tiburonderecha1");

            fondoPantalla = Content.Load<Texture2D>("fondo");
            song = Content.Load<Song>("flowergarden");
            pared = Content.Load<Texture2D>("rect");

            
            MediaPlayer.Volume = 0.7F;
            MediaPlayer.Play(song, TimeSpan.Parse("00:02:30"));
            //MediaPlayer.IsRepeating = true;
            _font = Content.Load<SpriteFont>("fuente1");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            tiempo = gameTime;
            // TODO: Add your update logic here

            if (gameTime.TotalGameTime.Milliseconds % 120 == 0)
            {
                gusano = Content.Load<Texture2D>("gusano/gusano2");
            }
            if (gameTime.TotalGameTime.Milliseconds % 270 == 0)
            {
                gusano = Content.Load<Texture2D>("gusano/gusano3");
            }
            if (gameTime.TotalGameTime.Milliseconds % 390 == 0)
            {
                gusano = Content.Load<Texture2D>("gusano/gusano4");
            }
            if (gameTime.TotalGameTime.Milliseconds % 490 == 0)
            {
                gusano = Content.Load<Texture2D>("gusano/gusano1");
            }

            if (pezDireccion == 0)
            {
                if (gameTime.TotalGameTime.Milliseconds % 70 == 0)
                {
                    pez = Content.Load<Texture2D>("pez/pezderecha2");
                }
                if (gameTime.TotalGameTime.Milliseconds % 200 == 0)
                {
                    pez = Content.Load<Texture2D>("pez/pezderecha3");
                }
                if (gameTime.TotalGameTime.Milliseconds % 320 == 0)
                {
                    pez = Content.Load<Texture2D>("pez/pezderecha4");
                }
                /*if (gameTime.TotalGameTime.Milliseconds % 450 == 0)
                {
                    pez = Content.Load<Texture2D>("pez1");
                }*/
            }
            else if (pezDireccion == 1)
            {
                if (gameTime.TotalGameTime.Milliseconds % 70 == 0)
                {
                    pez = Content.Load<Texture2D>("pez/pezizquierda2");
                }
                if (gameTime.TotalGameTime.Milliseconds % 200 == 0)
                {
                    pez = Content.Load<Texture2D>("pez/pezizquierda3");
                }
                if (gameTime.TotalGameTime.Milliseconds % 320 == 0)
                {
                    pez = Content.Load<Texture2D>("pez/pezizquierda4");
                }
                /*if (gameTime.TotalGameTime.Milliseconds % 450 == 0)
                {
                    pez = Content.Load<Texture2D>("pez1");
                }*/
            }
            
            if (gameTime.TotalGameTime.Seconds > 1.5)
            {
                puntaje = MediaPlayer.PlayPosition.ToString();
                if (tiburonDireccion == 0 && posiciontiburon.X <= 1406)
                {
                    if (gameTime.TotalGameTime.Milliseconds % 70 == 0)
                    {
                        tiburon = Content.Load<Texture2D>("tiburon/tiburonderecha2");
                    }
                    if (gameTime.TotalGameTime.Milliseconds % 200 == 0)
                    {
                        tiburon = Content.Load<Texture2D>("tiburon/tiburonderecha3");
                    }
                    if (gameTime.TotalGameTime.Milliseconds % 320 == 0)
                    {
                        tiburon = Content.Load<Texture2D>("tiburon/tiburonderecha4");
                    }
                    /*if (gameTime.TotalGameTime.Milliseconds % 450 == 0)
                    {
                        tiburon = Content.Load<Texture2D>("tiburon/tiburonderecha5");
                    }
                    /*if (gameTime.TotalGameTime.Milliseconds % 400 == 0)
                    {
                        tiburon = Content.Load<Texture2D>("tiburon/tiburonderecha6");
                    }
                    /*if (gameTime.TotalGameTime.Milliseconds % 480 == 0)
                    {
                        tiburon = Content.Load<Texture2D>("tiburon/tiburonderecha7");
                    }
                    if (gameTime.TotalGameTime.Milliseconds % 560 == 0)
                    {
                        tiburon = Content.Load<Texture2D>("tiburon/tiburonderecha8");
                    }
                    if (gameTime.TotalGameTime.Milliseconds % 640 == 0)
                    {
                        tiburon = Content.Load<Texture2D>("tiburon/tiburonderecha9");
                    }
                    if (gameTime.TotalGameTime.Milliseconds % 720 == 0)
                    {
                        tiburon = Content.Load<Texture2D>("tiburon/tiburonderecha10");
                    }
                    if (gameTime.TotalGameTime.Milliseconds % 800 == 0)
                    {
                        tiburon = Content.Load<Texture2D>("tiburon/tiburonderecha11");
                    }
                    /*if (gameTime.TotalGameTime.Milliseconds % 320 == 0)
                    {
                        tiburon = Content.Load<Texture2D>("tiburon/tiburonderecha4");
                    }
                    if (gameTime.TotalGameTime.Milliseconds % 320 == 0)
                    {
                        tiburon = Content.Load<Texture2D>("tiburon/tiburonderecha4");
                    }*/
                    posiciontiburon.X += 8;

                }

                if (tiburonDireccion == 0 && posiciontiburon.X >= 1406)
                {
                    tiburonDireccion = 1;
                    tiburon = Content.Load<Texture2D>("tiburon/tiburonizquierda1");
                    Random random = new Random();
                    posiciontiburon.Y = random.Next(25, 570);
                }

                if (tiburonDireccion == 1 && posiciontiburon.X >= -200)
                {
                    if (gameTime.TotalGameTime.Milliseconds % 70 == 0)
                    {
                        tiburon = Content.Load<Texture2D>("tiburon/tiburonizquierda2");
                    }
                    if (gameTime.TotalGameTime.Milliseconds % 200 == 0)
                    {
                        tiburon = Content.Load<Texture2D>("tiburon/tiburonizquierda3");
                    }
                    if (gameTime.TotalGameTime.Milliseconds % 320 == 0)
                    {
                        tiburon = Content.Load<Texture2D>("tiburon/tiburonizquierda4");
                    }
                    posiciontiburon.X -= 8;
                }

                if (tiburonDireccion == 1 && posiciontiburon.X <= -200)
                {

                    tiburonDireccion = 0;
                    tiburon = Content.Load<Texture2D>("tiburon/tiburonderecha1");
                    Random random = new Random();
                    posiciontiburon.Y = random.Next(25, 570);
                }
            }
            
            var teclaestado = Keyboard.GetState();

            if (teclaestado.IsKeyDown(Keys.Up) && posicionpez.Y >= 40)
            {
                posicionpez.Y -= vel;
            }
            if (teclaestado.IsKeyDown(Keys.Down) && posicionpez.Y <= _graphics.GraphicsDevice.Viewport.Height - 135)
            {
                posicionpez.Y += vel;
            }
            if (teclaestado.IsKeyDown(Keys.Left) && posicionpez.X >= 3)
            {

                pezDireccion = 1;

                posicionpez.X -= vel;
            }
            if (teclaestado.IsKeyDown(Keys.Right) && posicionpez.X <= _graphics.GraphicsDevice.Viewport.Width - 130)
            {

                pezDireccion = 0;
                posicionpez.X += vel;
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
            _spriteBatch.DrawString(_font, "Score " + puntaje, new Vector2(_graphics.PreferredBackBufferWidth / 2, 1), Color.White);
            //_spriteBatch.DrawString(_font, "HC21018", new Vector2(_graphics.PreferredBackBufferWidth - 76, 1), Color.White);

            
            crearrectangulos();
            for (int i = 0; i < rects.Length; i++)
            {
                _spriteBatch.Draw(pared, rects[i], Color.White);
            }
            _spriteBatch.Draw(gusano, posiciongusano, Color.LightGreen);
            _spriteBatch.Draw(pez, posicionpez, Color.White);
            _spriteBatch.Draw(tiburon, posiciontiburon, Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}