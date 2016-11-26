using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Game2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameObject2 hero;
        Rectangle fenetre;
        Texture2D back;
        GameObject2[] enemy = new GameObject2[4];     
        GameObject2 bullet;
        GameObject2 enemyb;
        SpriteFont Text;
        Texture2D victoire;
        Texture2D defeat;
        GameObject2 vict;
        Random rng = new Random();
        int kills = 0;        
        SpriteFont score;
        protected Song song;
        SoundEffect son;
        SoundEffectInstance dieded;

        SoundEffect sonn;
        SoundEffectInstance win;

        SoundEffect soon;
        SoundEffectInstance fail;




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

            son = Content.Load<SoundEffect>("Sounds\\smack12");
            dieded = son.CreateInstance();

            sonn = Content.Load<SoundEffect>("Sounds\\win1");
            win = sonn.CreateInstance();

            soon = Content.Load<SoundEffect>("Sounds\\fail");
            fail = soon.CreateInstance();

            Song song = Content.Load<Song>("Sounds\\background");
            
            MediaPlayer.Play(song);


            back = Content.Load<Texture2D>("back.png");
            defeat = Content.Load<Texture2D>("defeat.png");
            victoire = Content.Load<Texture2D>("victory.jpg");

            hero = new GameObject2();
            hero.estVivant = true;
            hero.position.X = 300;
            hero.position.Y = 300;
            hero.sprite = Content.Load<Texture2D>("pacman.png");

            bullet = new GameObject2();
            bullet.estVivant = false;
            bullet.sprite = Content.Load<Texture2D>("bullet.png");


            enemyb = new GameObject2();
            enemyb.estVivant = true;
            enemyb.sprite = Content.Load<Texture2D>("enemyb.png");
            enemyb.position.X = 1600;
            enemyb.position.Y = 0;
            enemyb.vitesse.X = -1000;


            Text = Content.Load<SpriteFont>("Font1");
            score = Content.Load<SpriteFont>("Fontscore");
           



            for (int i = enemy.Length - 1; i >= 0; i--)
            {
                enemy[i] = new GameObject2();
                enemy[i].estVivant = true;
                enemy[i].position.X = 1600;
                enemy[i].position.Y = 300;
                enemy[i].vitesse.X = rng.Next(3, 9);
                enemy[i].vitesse.Y = rng.Next(3, 9);
                
             
                    

                if (enemy[i] == enemy[1])
                {
                    enemy[1].sprite = Content.Load<Texture2D>("rose.png");
                }

                if (enemy[i] == enemy[2])
                {
                    enemy[2].sprite = Content.Load<Texture2D>("blue.png");
                }

                if (enemy[i] == enemy[3])
                {
                    enemy[3].sprite = Content.Load<Texture2D>("purple.png");
                }

                if (enemy[i] == enemy[0])
                {
                    enemy[0].sprite = Content.Load<Texture2D>("green.png");
                }           
            }


            
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
                hero.position.Y += -15;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                hero.position.Y += 15;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                hero.position.X += 15;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                hero.position.X += -15;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Space) && bullet.estVivant == false)
            {
                bullet.estVivant = true;
                bullet.vitesse.X = 50;
                bullet.position.Y = hero.position.Y + 60;
                bullet.position.X = hero.position.X + 30;
                bullet.position.X += 50;
            }


           



            // TODO: Add your update logic here
            Updatehero();
            Updatebullet();
            Updateenemy();
            Updateenemyb();
            base.Update(gameTime);
            
            

        }


        

        public void Updatehero()
        {
            if (hero.estVivant == false)
            {
                
                Thread.Sleep(4000);
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

            if (hero.position.X > fenetre.Right)
            {
                hero.position.X = fenetre.Right;
            }

            if (this.hero.GetRect().Intersects(this.enemy[1].GetRect()))
            {
                hero.estVivant = false;
                enemyb.estVivant = false;
            }

            if (this.hero.GetRect().Intersects(this.enemy[0].GetRect()))
            {
                hero.estVivant = false;
                enemyb.estVivant = false;
            }

            if (this.hero.GetRect().Intersects(this.enemy[2].GetRect()))
            {
                hero.estVivant = false;
                enemyb.estVivant = false;
            }

            if (this.hero.GetRect().Intersects(this.enemy[3].GetRect()))
            {
                hero.estVivant = false;
                enemyb.estVivant = false;

            }

            if (this.enemyb.GetRect().Intersects(this.hero.GetRect()))
            {
                hero.estVivant = false;
                enemyb.estVivant = false;
            }


            if (this.enemyb.GetRect().Intersects(this.bullet.GetRect()))
            {
                bullet.estVivant = false;
                enemyb.estVivant = false;
            }

        }

            public void Updatebullet()
        {
            bullet.position += bullet.vitesse;

            if (bullet.position.X < fenetre.Left)
            {
                bullet.position.X = fenetre.Left;
                bullet.estVivant = false;
            }

            if (bullet.position.Y < fenetre.Top)
            {
                bullet.position.Y = fenetre.Top;
                bullet.estVivant = false;
            }

            if (bullet.position.X + bullet.sprite.Bounds.Width > fenetre.Right)
            {
                bullet.position.X = fenetre.Right - bullet.sprite.Bounds.Width;
                bullet.estVivant = false;
            }

            if (bullet.position.Y + bullet.sprite.Bounds.Height > fenetre.Bottom)
            {
                bullet.position.Y = fenetre.Bottom - bullet.sprite.Bounds.Height;
                bullet.estVivant = false;
            }

            if (bullet.position.X > fenetre.Right)
            {
                bullet.position.X = fenetre.Right;
                bullet.estVivant = false;
            }





        }


        public void Updateenemy()
        {



            for (int i = enemy.Length - 1; i >= 0; i--)
            {


                enemy[i].position += enemy[i].vitesse;

                if (enemy[i].position.X < fenetre.Left)
                {
                    enemy[i].position.X = fenetre.Left;
                    

                }

                if (enemy[i].position.Y < fenetre.Top)
                {
                    enemy[i].position.Y = fenetre.Top;
                    ;

                }

                if (enemy[i].position.X + enemy[i].sprite.Bounds.Width > fenetre.Right)
                {
                    enemy[i].position.X = fenetre.Right - enemy[i].sprite.Bounds.Width;
                    

                }

                if (enemy[i].position.Y + enemy[i].sprite.Bounds.Height > fenetre.Bottom)
                {
                    enemy[i].position.Y = fenetre.Bottom - enemy[i].sprite.Bounds.Height;
                    

                }

                if (enemy[i].position.X > fenetre.Right)
                {
                    enemy[i].position.X = fenetre.Right;
                    

                }


                if (enemy[i].position.Y == fenetre.Top)
                {
                    enemy[i].vitesse.Y = rng.Next(3, 12);
                }

                if (enemy[i].position.Y + enemy[i].sprite.Bounds.Height == fenetre.Bottom)
                {
                    enemy[i].vitesse.Y = rng.Next(-12, -3);
                }

                if (enemy[i].position.X + enemy[i].sprite.Bounds.Width == fenetre.Right)
                {
                    enemy[i].vitesse.X = rng.Next(-12, -3);
                }

                if (enemy[i].position.X <= fenetre.Left)
                {
                    enemy[i].vitesse.X = rng.Next(3, 12);
                }

                if (this.bullet.GetRect().Intersects(this.enemy[i].GetRect()))
                {

                    enemy[i].estVivant = false;
                    bullet.estVivant = false;
                    dieded.Play();
                    kills++;

                }



            }
        }


            public void Updateenemyb()
        {
            for (int i = enemy.Length - 1; i >= 0; i--)
            {
                enemyb.position += enemyb.vitesse;

                if (enemyb.position.X + enemyb.sprite.Bounds.Width > fenetre.Right)
                {
                    enemyb.position.X = fenetre.Right - enemy[i].sprite.Bounds.Width;
                    enemyb.estVivant = false;

                }

                if (enemyb.position.X < fenetre.Left)
                {
                    enemyb.position.X = fenetre.Left;
                    enemyb.estVivant = false;
                }


                if (enemyb.position.X > fenetre.Right)
                {
                    enemyb.position.X = fenetre.Right;
                    enemyb.estVivant = false;

                }



                if (enemyb.estVivant == false)
                {
                    enemyb.estVivant = true;
                    enemyb.position.X = enemy[rng.Next(0,4)].position.X;
                    if (enemyb.position.X == enemy[0].position.X)
                    {
                        enemyb.position.Y = enemy[0].position.Y;
                    }

                    if (enemyb.position.X == enemy[1].position.X)
                    {
                        enemyb.position.Y = enemy[1].position.Y;
                    }

                    if (enemyb.position.X == enemy[3].position.X)
                    {
                        enemyb.position.Y = enemy[3].position.Y;
                    }

                    if (enemyb.position.X == enemy[2].position.X)
                    {
                        enemyb.position.Y = enemy[2].position.Y;
                    }


                    enemyb.vitesse.X = -3;
                }
            }
        }


    
        

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

          

            spriteBatch.Draw(back, new Rectangle(0, 0, graphics.GraphicsDevice.DisplayMode.Width, graphics.GraphicsDevice.DisplayMode.Height), Color.White);

            spriteBatch.DrawString(Text, gameTime.TotalGameTime.TotalSeconds.ToString(), new Vector2(0, 0), Color.Black);

            

            spriteBatch.DrawString(score, " Score: " + kills.ToString(), new Vector2(1700, 0), Color.Black);

            if (hero.estVivant == true)
            {
                spriteBatch.Draw(hero.sprite, hero.position, Color.White);               
            }

            if (bullet.estVivant == true)
            {
                spriteBatch.Draw(bullet.sprite, bullet.position, Color.White);

            }

            for (int i = enemy.Length - 1; i >= 0; i--)
            {
                if (enemy[i].estVivant == true)
                {
                    spriteBatch.Draw(enemy[i].sprite, enemy[i].position, Color.White);
                }
            }


            for (int i = enemy.Length - 1; i >= 0; i--)
            {           
                if (enemy[i].estVivant == false)
                {
                        
                        enemy[i].estVivant = true;
                        enemy[i].position.X = 1980;
                        enemy[i].position.Y = rng.Next(0, 1080);
                        enemy[i].vitesse.X = rng.Next(3, 6);
                        enemy[i].vitesse.Y = rng.Next(3, 6);
                    

                }
            }


          
            if (bullet.estVivant == false)
            {
                bullet.position.Y = hero.position.Y + 60;
                bullet.position.X = hero.position.X + 30;
                bullet.position.X += 50;
            }

            if (hero.estVivant == false)
            {
                MediaPlayer.Stop();
                dieded.Stop();
                fail.Play();
                
                spriteBatch.Draw(defeat, new Rectangle(0, 0, graphics.GraphicsDevice.DisplayMode.Width, graphics.GraphicsDevice.DisplayMode.Height), Color.White);
                
            }



            if (enemyb.estVivant == true)
            {              
                    spriteBatch.Draw(enemyb.sprite, enemyb.position, Color.White);
             
            }

            if (kills >= 35)
            {
               spriteBatch.Draw(victoire, new Rectangle(0, 0, graphics.GraphicsDevice.DisplayMode.Width, graphics.GraphicsDevice.DisplayMode.Height), Color.White);
                win.Play();
                dieded.Stop();
                fail.Stop();
                MediaPlayer.Stop();
            }
           

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
