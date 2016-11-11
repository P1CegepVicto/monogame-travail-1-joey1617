using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Projet01
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameObject hero;
        Rectangle fenetre;
        Texture2D back;
        GameObject enemy;
        GameObject bullet;
        


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.graphics.PreferredBackBufferWidth = graphics.GraphicsDevice.DisplayMode.Width;
            this.graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.DisplayMode.Height;
            this.graphics.ToggleFullScreen();
            fenetre = new Rectangle(0, 0, graphics.GraphicsDevice.DisplayMode.Width, graphics.GraphicsDevice.DisplayMode.Height);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            back = Content.Load<Texture2D>("back.jpeg");
            hero = new GameObject();
            hero.estVivant = true;
            hero.position.X = 300;
            hero.position.Y = 300;            
            enemy = new GameObject();
            enemy.estVivant = true;
            enemy.sprite = Content.Load<Texture2D>("joey.png");
            enemy.position.X = 1500;
            enemy.position.Y = 300;
            enemy.vitesse.Y = 30;
            enemy.vitesse.X = 50;
            bullet = new GameObject();
            bullet.estVivant = false;        
            bullet.sprite = Content.Load<Texture2D>("bullet.png");
            hero.sprite = Content.Load<Texture2D>("hero.png");
            

            // TODO: use this.Content to load your game content here
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
                      

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            { 

            hero.position.Y -= 20;

            }


            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                hero.position.Y += 20;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {               
                bullet.estVivant = true;
                bullet.vitesse.X = 50;
                bullet.position.Y = hero.position.Y;
                bullet.position.X = hero.position.X;
                bullet.position.X += 20;
                
            }



            // TODO: Add your update logic here
            Updatehero();
            Updateenemy();
            Updatebullet();
           
            base.Update(gameTime);
        }


        public void Updatehero()
        {        

            hero.position += hero.vitesse;

            if (hero.position.X < fenetre.Left)
            {
                hero.position.X = fenetre.Left;
            }

            if (hero.position.Y < fenetre.Top)
            {
                hero.position.Y = fenetre.Top;
            }

            if (hero.position.X + hero.sprite.Bounds.Width > fenetre.Right)
            {
                hero.position.X = fenetre.Right - hero.sprite.Bounds.Width;
            }

            if (hero.position.Y + hero.sprite.Bounds.Height > fenetre.Bottom)
            {
                hero.position.Y = fenetre.Bottom - hero.sprite.Bounds.Height;
            }

            if (hero.position.X > fenetre.Center.X)
            {
                hero.position.X = fenetre.Center.X;
            }
        }

        protected void Updateenemy()
        {
            if (enemy.position.Y == fenetre.Top)
            {
                enemy.vitesse.Y = 10;
            }

            if(enemy.position.Y + enemy.sprite.Bounds.Height == fenetre.Bottom)
            {
                enemy.vitesse.Y = -10;
            }

            if (enemy.position.X + enemy.sprite.Bounds.Width == fenetre.Right)
            {
                enemy.vitesse.X = -10;
            }

            if (enemy.position.X <= fenetre.Center.X)
            {
                enemy.vitesse.X = 10;
            }

            enemy.position += enemy.vitesse;

            if (enemy.position.X < fenetre.Left)
                {
                    enemy.position.X = fenetre.Left;
                }

                if (enemy.position.Y < fenetre.Top)
                {
                    enemy.position.Y = fenetre.Top;
                }

                if (enemy.position.X + enemy.sprite.Bounds.Width > fenetre.Right)
                {
                    enemy.position.X = fenetre.Right - enemy.sprite.Bounds.Width;
                }

                if (enemy.position.Y + enemy.sprite.Bounds.Height > fenetre.Bottom)
                {
                    enemy.position.Y = fenetre.Bottom - enemy.sprite.Bounds.Height;
                }
            }



        public void Updatebullet()
        {
            bullet.position += bullet.vitesse;
        }












        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);         
            spriteBatch.Begin();

            spriteBatch.Draw(back, new Rectangle(0, 0, graphics.GraphicsDevice.DisplayMode.Width, graphics.GraphicsDevice.DisplayMode.Height), Color.White);

            spriteBatch.Draw(enemy.sprite, enemy.position, Color.White);

            spriteBatch.Draw(hero.sprite, hero.position, Color.White);

            if (bullet.estVivant == true)
            {
                spriteBatch.Draw(bullet.sprite, bullet.position, Color.White);

            }

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
