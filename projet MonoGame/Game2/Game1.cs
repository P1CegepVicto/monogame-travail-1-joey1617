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
        GameObject2 background1;
        GameObject2 background2;
        GameObject2 boss;
        GameObject2[] enemy = new GameObject2[4];
        GameObject2[] bullet = new GameObject2[2];       
        GameObject2 enemyb;
        SpriteFont Text;
        Texture2D victoire;
        Texture2D defeat;
        GameObject2 bulletBoss;
        GameObject2 mario;
        GameObject2 peach;
        GameObject2 Victoire;
        GameObject2 defaite;
        GameObject2 backg;
        GameObject2 Menu;
        bool Gamestate;
        bool MenuOver = false;
        bool MenuWin = false;
        Texture2D defaiteb;

        Random rng = new Random();
        int kills = 0;
        int vies = 3;
        int bossv = 100;

        SpriteFont score;
        SpriteFont vie;
        SpriteFont bossvie;
        SpriteFont text;

        protected Song song;
        SoundEffect son;
        SoundEffectInstance dieded;

        SoundEffect sonn;
        SoundEffectInstance win;

        SoundEffect soon;
        SoundEffectInstance fail;

        SoundEffect sn;
        SoundEffectInstance canon;




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

            Menu = new GameObject2();
            Menu.sprite = Content.Load<Texture2D>("Play.png");
            Menu.estVivant = true;
            Menu.position.X = 825;
            Menu.position.Y = 400;

            son = Content.Load<SoundEffect>("Sounds\\smack12");
            dieded = son.CreateInstance();

            sonn = Content.Load<SoundEffect>("Sounds\\win1");
            win = sonn.CreateInstance();

            soon = Content.Load<SoundEffect>("Sounds\\fail");
            fail = soon.CreateInstance();

            sn = Content.Load<SoundEffect>("Sounds\\bowser");
            canon = sn.CreateInstance();

            Song song = Content.Load<Song>("Sounds\\background");
            
            MediaPlayer.Play(song);


            mario = new GameObject2();
            mario.estVivant = false;
            mario.sprite = Content.Load<Texture2D>("Mario.png");
            mario.position.X = 900;
            mario.position.Y = 350;

            peach = new GameObject2();
            peach.estVivant = false;
            peach.sprite = Content.Load<Texture2D>("peach.png");
            peach.position.X = 500;
            peach.position.Y = 350;

            Victoire = new GameObject2();
            Victoire.estVivant = false;
            Victoire.sprite = Content.Load<Texture2D>("Victoire.png");
            Victoire.position.X = 660;
            Victoire.position.Y = 200;

            defaite = new GameObject2();
            defaite.estVivant = false;
            defaite.sprite = Content.Load<Texture2D>("defaite.png");
            defaite.position.X = 1100;
            defaite.position.Y = 700;

            backg = new GameObject2();
            backg.estVivant = false;
            backg.sprite = Content.Load<Texture2D>("backg.jpg");
            backg.position.X = 0;
            backg.position.Y = 0;

            

            background1 = new GameObject2();
            background1.estVivant = true;
            background1.sprite = Content.Load<Texture2D>("back.jpg");
            background1.position.X = 0;
            background1.position.Y = 0;
            background1.vitesse.X = -10;

            background2 = new GameObject2();
            background2.estVivant = true;
            background2.sprite = Content.Load<Texture2D>("back2.jpg");
            background2.position.X = 1920;
            background2.position.Y = 0;
            background2.vitesse.X = -10;

            boss = new GameObject2();
            boss.estVivant = false;
            boss.vitesse.Y = 12;
            boss.position.X = 1250;
            boss.position.Y = 500;
            boss.sprite = Content.Load<Texture2D>("boss.png");

            defaiteb = Content.Load<Texture2D>("bowser.png");
            
            victoire = Content.Load<Texture2D>("victory.jpg");

            hero = new GameObject2();
            hero.estVivant = false;
            hero.position.X = 300;
            hero.position.Y = 300;
            hero.sprite = Content.Load<Texture2D>("hero1.png");

            for (int l = bullet.Length - 1; l >= 0; l--)
            {
                bullet[l] = new GameObject2();
                bullet[l].estVivant = false;
                
                if (bullet[l] == bullet[0])
                {
                    bullet[0].sprite = Content.Load<Texture2D>("bullet1.png");
                }

                if (bullet[l] == bullet[1])
                {
                    bullet[1].sprite = Content.Load<Texture2D>("bullet2.png");
                }
         
            }


            bulletBoss = new GameObject2();
            bulletBoss.estVivant = false;
            bulletBoss.sprite = Content.Load<Texture2D>("bulletb");
            

            enemyb = new GameObject2();
            enemyb.estVivant = false;
            enemyb.sprite = Content.Load<Texture2D>("Bomb.png");

            Gamestate = false;

            text = Content.Load<SpriteFont>("Font1");
            Text = Content.Load<SpriteFont>("Font1");
            score = Content.Load<SpriteFont>("Fontscore");
            vie = Content.Load<SpriteFont>("Font1");
            bossvie = Content.Load<SpriteFont>("Font1");
           


            for (int i = enemy.Length - 1; i >= 0; i--)
            {
                enemy[i] = new GameObject2();
                enemy[i].estVivant = true;
                                          
                if (enemy[i] == enemy[1])
                {
                    enemy[1].sprite = Content.Load<Texture2D>("en1.png");
                }

                if (enemy[i] == enemy[2])
                {
                    enemy[2].sprite = Content.Load<Texture2D>("wing.png");
                }

                if (enemy[i] == enemy[3])
                {
                    enemy[3].sprite = Content.Load<Texture2D>("hammer.png");
                }

                if (enemy[i] == enemy[0])
                {
                    enemy[0].sprite = Content.Load<Texture2D>("green2.png");
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

            if (Gamestate == false && Menu.estVivant == true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    fail.Stop();
                    win.Stop();
                    MediaPlayer.Resume();
                    Gamestate = true;
                    Menu.estVivant = false;
                    hero.estVivant = true;
                    MenuOver = false;
                    kills = 0;
                    vies = 3;
                    bossv = 100;

                    background1.position.X = 0;
                    background1.position.Y = 0;
                    background1.vitesse.X = -10;                                        
                    background2.position.X = 1920;
                    background2.position.Y = 0;
                    background2.vitesse.X = -10;
                    


                    for (int i = enemy.Length - 1; i >= 0; i--)
                    {
                        enemy[i].estVivant = true;
                        enemy[i].position.X = 1980;
                        enemy[i].position.Y = rng.Next(0, 1080);
                        enemy[i].vitesse.X = rng.Next(3, 6);
                        enemy[i].vitesse.Y = rng.Next(3, 6);
                    }

                }
            

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

        }
            if (Gamestate == true)
            {
               

                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    Gamestate = false;
                    Menu.estVivant = true;
                }

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






                if (rng.Next(0, 2) == 1)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Space) && bullet[0].estVivant == false && hero.estVivant == true)
                    {
                        bullet[0].estVivant = true;
                        bullet[0].position.X = hero.position.X + 60;
                        bullet[0].position.Y = hero.position.Y + 30;
                        bullet[0].vitesse.X = 50;
                    }
                }


                else
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Space) && bullet[1].estVivant == false && hero.estVivant == true)
                    {
                        bullet[1].estVivant = true;
                        bullet[1].position.X = hero.position.X + 60;
                        bullet[1].position.Y = hero.position.Y + 30;
                        bullet[1].vitesse.X = 50;
                    }
                }


                if (background2.position.X == fenetre.Left)
                {
                    background1.position.X = background2.position.X + background2.sprite.Width;
                }
                if (background1.position.X == fenetre.Left)
                {
                    background2.position.X = background1.position.X + background1.sprite.Width;
                }




            }



            if (Gamestate == false && MenuOver == true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    this.Exit();
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    Gamestate = true;
                    Menu.estVivant = false;
                    MenuOver = false;
                }
            }

            // TODO: Add your update logic here
            Updatebossb();
            Updatehero();
            Updateboss();
            Updatebullet();
            Updateenemy();
            Updateenemyb();
            Updatebackground1();
            Updatebackground2();
            base.Update(gameTime);



        }
        
         
        public void Updateboss()
        {
            if (Gamestate == true)
            {

                if (boss.estVivant == true)
                {
                    boss.position += boss.vitesse;



                    if (boss.position.Y < fenetre.Top)
                    {
                        boss.position.Y = fenetre.Top;
                        boss.vitesse.Y = 12;
                    }



                    if (boss.position.Y + boss.sprite.Bounds.Height > fenetre.Bottom)
                    {
                        boss.position.Y = fenetre.Bottom - boss.sprite.Bounds.Height;
                        boss.vitesse.Y = -12;
                    }




                    for (int l = bullet.Length - 1; l >= 0; l--)
                    {
                        if (this.bulletBoss.GetRect().Intersects(this.bullet[l].GetRect()))
                        {
                            bullet[l].estVivant = false;
                        }
                    }


                    if (this.bulletBoss.GetRect().Intersects(this.hero.GetRect()))
                    {
                        bulletBoss.estVivant = false;
                        hero.estVivant = false;
                        vies--;
                    }


                    for (int l = bullet.Length - 1; l >= 0; l--)
                    {
                        if (this.bullet[l].GetRect().Intersects(this.boss.GetRect()))
                        {
                            bossv--;
                            bullet[l].estVivant = false;

                        }
                    }


                    if (this.hero.GetRect().Intersects(this.boss.GetRect()) && bulletBoss.estVivant == true)
                    {
                        hero.estVivant = false;
                        vies--;
                    }
                }
            }
        }


        public void Updatebackground1()
        {
            if (Gamestate == true)
            {
                background1.position += background1.vitesse;
            }
        }

        public void Updatebackground2()
        {
            if (Gamestate == true)
            {
                background2.position += background2.vitesse;
            }
        }


        public void Updatehero()
        {
            if (Gamestate == true)
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

                if (hero.position.X > fenetre.Right)
                {
                    hero.position.X = fenetre.Right;
                }

                if (this.hero.GetRect().Intersects(this.enemy[1].GetRect()))
                {
                    hero.estVivant = false;
                    enemy[0].estVivant = false;
                    enemy[1].estVivant = false;
                    enemy[2].estVivant = false;
                    enemy[3].estVivant = false;
                    enemyb.estVivant = false;
                    vies--;
                }

                if (this.hero.GetRect().Intersects(this.enemy[0].GetRect()))
                {
                    hero.estVivant = false;
                    enemy[0].estVivant = false;
                    enemy[1].estVivant = false;
                    enemy[2].estVivant = false;
                    enemy[3].estVivant = false;
                    enemyb.estVivant = false;
                    vies--;
                }

                if (this.hero.GetRect().Intersects(this.enemy[2].GetRect()))
                {
                    hero.estVivant = false;
                    enemy[0].estVivant = false;
                    enemy[1].estVivant = false;
                    enemy[2].estVivant = false;
                    enemy[3].estVivant = false;
                    enemyb.estVivant = false;
                    vies--;
                }

                if (this.hero.GetRect().Intersects(this.enemy[3].GetRect()))
                {
                    hero.estVivant = false;
                    enemy[0].estVivant = false;
                    enemy[1].estVivant = false;
                    enemy[2].estVivant = false;
                    enemy[3].estVivant = false;
                    enemyb.estVivant = false;
                    vies--;

                }

                if (this.enemyb.GetRect().Intersects(this.hero.GetRect()))
                {
                    hero.estVivant = false;
                    enemy[0].estVivant = false;
                    enemy[1].estVivant = false;
                    enemy[2].estVivant = false;
                    enemy[3].estVivant = false;
                    enemyb.position.X = enemy[1].position.X;
                    enemyb.position.Y = enemy[1].position.Y;
                    vies--;
                }

            }

        }

            public void Updatebullet()
        {
            if (Gamestate == true)
            {

                for (int l = bullet.Length - 1; l >= 0; l--)
                {
                    bullet[l].position += bullet[l].vitesse;

                    if (bullet[l].position.X < fenetre.Left)
                    {
                        bullet[l].position.X = fenetre.Left;
                        bullet[l].estVivant = false;
                    }

                    if (bullet[l].position.Y < fenetre.Top)
                    {
                        bullet[l].position.Y = fenetre.Top;
                        bullet[l].estVivant = false;
                    }

                    if (bullet[l].position.X + bullet[l].sprite.Bounds.Width > fenetre.Right)
                    {
                        bullet[l].position.X = fenetre.Right - bullet[l].sprite.Bounds.Width;
                        bullet[l].estVivant = false;
                    }

                    if (bullet[l].position.Y + bullet[l].sprite.Bounds.Height > fenetre.Bottom)
                    {
                        bullet[l].position.Y = fenetre.Bottom - bullet[l].sprite.Bounds.Height;
                        bullet[l].estVivant = false;
                    }

                    if (bullet[l].position.X > fenetre.Right)
                    {
                        bullet[l].position.X = fenetre.Right;
                        bullet[l].estVivant = false;
                    }


                }
            }

        }

        public void Updatebossb()
        {
            if (Gamestate == true)
            {
                bulletBoss.position += bulletBoss.vitesse;


                if (bulletBoss.position.X < fenetre.Left)
                {
                    bulletBoss.position.X = fenetre.Left;
                    bulletBoss.estVivant = false;
                }

                if (bulletBoss.position.X + bulletBoss.sprite.Bounds.Width > fenetre.Right)
                {
                    bulletBoss.position.X = fenetre.Right - bulletBoss.sprite.Bounds.Width;
                    bulletBoss.estVivant = false;
                }

                if (bulletBoss.position.X > fenetre.Right)
                {
                    bulletBoss.position.X = fenetre.Right;
                    bulletBoss.estVivant = false;
                }

                bulletBoss.vitesse.X = -25;

            }
        }

        public void Updateenemy()
        {
            if (Gamestate == true)
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

                    for (int l = bullet.Length - 1; l >= 0; l--)
                    {
                        if (this.bullet[l].GetRect().Intersects(this.enemy[i].GetRect()))
                        {
                            enemy[i].estVivant = false;
                            bullet[l].estVivant = false;
                            dieded.Play();
                            kills++;
                        }

                    }

                }
            }
        }


            public void Updateenemyb()
        {
            if (Gamestate == true)
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
                        enemyb.position.X = enemy[rng.Next(0, 4)].position.X;
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


                        enemyb.vitesse.X = -6;
                    }
                }
            }
        }


    
        

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            if (Gamestate == false)
            {
                spriteBatch.Draw(Menu.sprite, Menu.position);
            }

            if (MenuWin == true)
            {
                spriteBatch.DrawString(text, "Good job, you won! :P", new Vector2(fenetre.Center.X - 200, fenetre.Bottom - 250), Color.White);
            }

            if (MenuOver == true)
            {
                spriteBatch.DrawString(Text, "Play again ?", new Vector2(fenetre.Center.X - 100, fenetre.Bottom - 250), Color.White);
            }

            if (Gamestate == true)
            {

                if (background1.estVivant == true)
                {
                    spriteBatch.Draw(background1.sprite, background1.position);
                }

                if (background2.estVivant == true)
                {
                    spriteBatch.Draw(background2.sprite, background2.position, effects: SpriteEffects.FlipHorizontally);

                }


                spriteBatch.DrawString(score, " Score: " + kills.ToString(), new Vector2(1700, 0), Color.Black);

                spriteBatch.DrawString(vie, " Vie: " + vies.ToString(), new Vector2(0, 100), Color.Black);

                if (hero.estVivant == true)
                {
                    spriteBatch.Draw(hero.sprite, hero.position, Color.White);
                }

                for (int l = bullet.Length - 1; l >= 0; l--)
                {
                    if (bullet[l].estVivant == true)
                    {
                        spriteBatch.Draw(bullet[l].sprite, bullet[l].position, Color.White);

                    }
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

                if (hero.estVivant == false)
                {

                    hero.estVivant = true;
                    hero.position.X = 0;
                    hero.position.Y = rng.Next(0, 1000);

                }



                for (int l = bullet.Length - 1; l >= 0; l--)
                {
                    if (bullet[l].estVivant == false)
                    {
                        bullet[l].position.Y = 1800;
                        bullet[l].position.X = 0;

                    }
                }




                if (enemyb.estVivant == true)
                {

                    spriteBatch.Draw(enemyb.sprite, enemyb.position, Color.White);

                }

                if (bulletBoss.estVivant == false && boss.estVivant == true)
                {
                    bulletBoss.estVivant = true;
                    canon.Play();
                    bulletBoss.position.X = 1600;
                    bulletBoss.position.Y = rng.Next(50, 1000);

                }


                if (bulletBoss.estVivant == true)
                {

                    spriteBatch.Draw(bulletBoss.sprite, bulletBoss.position, Color.White);
                }


                if (kills >= 100)
                {
                    enemyb.estVivant = true;
                    enemyb.position.X = 1800;
                    enemyb.position.Y = 1060;

                    dieded.Stop();
                    fail.Stop();

                    boss.estVivant = true;
                    spriteBatch.Draw(boss.sprite, boss.position, Color.White);
                    spriteBatch.DrawString(bossvie, " Boss Life: " + bossv.ToString(), new Vector2(1650, 200), Color.Black);
                    for (int i = enemy.Length - 1; i >= 0; i--)
                    {
                        enemy[i].estVivant = false;
                        enemy[i].position.X = 1800;
                        enemy[i].position.Y = 1060;

                    }

                    if (bossv <= 0)
                    {
                        win.Play();
                        MediaPlayer.Stop();

                        for (int i = enemy.Length - 1; i >= 0; i--)
                        {
                            enemy[i].estVivant = false;
                        }

                        boss.estVivant = false;
                        hero.estVivant = false;                       
                        Menu.estVivant = true;
                        Gamestate = false;
                        MenuWin = true;
                    }

                }

               

                if (vies <= 0)
                {
                    MediaPlayer.Pause();
                    dieded.Stop();
                    fail.Play();
                    boss.estVivant = false;
                    hero.estVivant = false;
                    for (int i = enemy.Length - 1; i >= 0; i--)
                    {
                        enemy[i].estVivant = false;
                    }
                    Gamestate = false;
                    Menu.estVivant = true;
                    MenuOver = true;      
                      

                }

            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
