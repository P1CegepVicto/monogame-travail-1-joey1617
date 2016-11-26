using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;

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
        GameObject karen;
        Texture2D victoire;
        Texture2D defeat;
        GameObject vict;

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
            back = Content.Load<Texture2D>("images.jpg");
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

            karen = new GameObject();
            karen.estVivant = false;
            karen.sprite = Content.Load<Texture2D>("karen.png");

            victoire = Content.Load<Texture2D>("Victory.png"); 

            defeat = Content.Load<Texture2D>("defeat.png"); 

            vict = new GameObject();
            vict.estVivant = false;

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

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                hero.position.X += 20;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                hero.position.X += -20;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {               
                bullet.estVivant = true;
                bullet.vitesse.X = 70;
                bullet.position.Y = hero.position.Y;
                bullet.position.X = hero.position.X;
                bullet.position.X += 50;
                
            }

           



            // TODO: Add your update logic here
            Updatehero();
            Updateenemy();
            Updatebullet();
            Updatekaren();
           
            base.Update(gameTime);
        }


        public void Updatehero()
        {

            if (hero.estVivant == false || enemy.estVivant == false)
            {
                Thread.Sleep(1000);
                this.Exit();
            }

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
                enemy.vitesse.Y = 20;
                karen.estVivant = true;
                karen.vitesse.X = -70;
                karen.position.Y = enemy.position.Y;
                karen.position.X = enemy.position.X;
                karen.position.X -= 50;
            }

            if(enemy.position.Y + enemy.sprite.Bounds.Height == fenetre.Bottom)
            {
                enemy.vitesse.Y = -15;
                karen.estVivant = true;
                karen.vitesse.X = -70;
                karen.position.Y = enemy.position.Y;
                karen.position.X = enemy.position.X;
                karen.position.X -= 50;
            }

            if (enemy.position.X + enemy.sprite.Bounds.Width == fenetre.Right)
            {
                enemy.vitesse.X = -15;
                karen.estVivant = true;
                karen.vitesse.X = -70;
                karen.position.Y = enemy.position.Y;
                karen.position.X = enemy.position.X;
                karen.position.X -= 50;
            }

            if (enemy.position.X <= fenetre.Center.X)
            {
                enemy.vitesse.X = 20;
                karen.estVivant = true;
                karen.vitesse.X = -70;
                karen.position.Y = enemy.position.Y;
                karen.position.X = enemy.position.X;
                karen.position.X -= 50;
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


            if (this.bullet.GetRect().Intersects(this.enemy.GetRect()))
            {
                
                enemy.estVivant = false;
                bullet.estVivant = false;
                
                
            }

            if (this.karen.GetRect().Intersects(this.hero.GetRect()))
            {

                karen.estVivant = false;
                hero.estVivant = false;
                            
            }
        }


        public void Updatebullet()
        {
            bullet.position += bullet.vitesse;
           
        } 

        public void Updatekaren()
        {
            karen.position += karen.vitesse;
           
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


            if (enemy.estVivant == true)
            {
                spriteBatch.Draw(enemy.sprite, enemy.position, Color.White);

            }

            if (hero.estVivant == true)
            {
                spriteBatch.Draw(hero.sprite, hero.position, Color.White);

            }

            if (bullet.estVivant == true)
            {
                spriteBatch.Draw(bullet.sprite, bullet.position, Color.White);

            }

            if (karen.estVivant == true)
            {
                spriteBatch.Draw(karen.sprite, karen.position, Color.White);

            }


            if (hero.estVivant == true && enemy.estVivant == false)
            {
                spriteBatch.Draw(victoire, new Rectangle(0, 0, graphics.GraphicsDevice.DisplayMode.Width, graphics.GraphicsDevice.DisplayMode.Height), Color.White);
            }
            if (hero.estVivant == false && enemy.estVivant == true)
            {
                spriteBatch.Draw(defeat, new Rectangle(0, 0, graphics.GraphicsDevice.DisplayMode.Width, graphics.GraphicsDevice.DisplayMode.Height), Color.White);

            }




            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
