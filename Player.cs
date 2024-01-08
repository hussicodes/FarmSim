using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SpilProjekt
{
    internal class Player : GameObject
    {
        protected Texture2D[] spritesBack;
        protected Texture2D[] spritesForward;
        protected Texture2D[] spritesLeft;
        protected Texture2D[] spritesRight;
        protected Texture2D[] spritesWaterLeft;
        protected Texture2D[] spritesReap;

        private SoundEffect soundEffectWater;

        protected float fps;
        private float timeElapsed;
        private int currentIndex;
        protected float speed;
        protected Vector2 velocity;

        protected Texture2D[] sprites;

        private int playerWidth;
        private int playerHeight;

        public Player()
        {
            speed = 500;
            fps = 10;
            playerWidth = 30;
            playerHeight = 40;
        }

        public override void LoadContent(ContentManager content)
        {
            spritesBack = new Texture2D[3];
            spritesForward = new Texture2D[3];
            spritesLeft = new Texture2D[3];
            spritesRight = new Texture2D[3];
            spritesWaterLeft = new Texture2D[3];
            spritesReap = new Texture2D[3];

            for (int i = 0; i < spritesBack.Length; i++)
            {

                spritesBack[i] = content.Load<Texture2D>($"Sprite_Back/Player{i + 1}");
                spritesForward[i] = content.Load<Texture2D>($"Sprite_Forward/Forward{i + 1}");
                spritesLeft[i] = content.Load<Texture2D>($"Sprite_Left/Left{i + 1}");
                spritesRight[i] = content.Load<Texture2D>($"Sprite_Right/Right{i + 1}");
                spritesReap[i] = content.Load<Texture2D>($"Sprite_Reap/Reap{i + 1}");
                spritesWaterLeft[i] = content.Load<Texture2D>($"Sprite_Water/Water{i + 1}");
            }

            sprites = spritesReap;
            sprites = spritesWaterLeft;
            sprites = spritesBack;
            sprites = spritesForward;
            sprites = spritesLeft;
            sprites = spritesRight;

            sprite = sprites[0];
          //  soundEffectWater = content.Load<SoundEffect>("Vand1");
            position = new Vector2(350, 300);
        }

        public override void Update(GameTime gameTime)
        {
            HandleInput();
            Move(gameTime);
            Animate(gameTime);
        }

        private void HandleInput()
        {
            velocity = Vector2.Zero;

            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.E))
            {
                sprites = spritesReap;
            }
            if (keyState.IsKeyDown(Keys.Q))
            {
                //soundEffectWater.Play();
                sprites = spritesWaterLeft;
            }

            if (keyState.IsKeyDown(Keys.W))
            {
                velocity += new Vector2(0, -1);
                sprites = spritesForward;
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                velocity += new Vector2(-1, 0);
                sprites = spritesLeft;
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                velocity += new Vector2(0, 1);
                sprites = spritesBack;
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                velocity += new Vector2(1, 0);
                sprites = spritesRight;
            }

            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
        }

        private void Animate(GameTime gameTime)
        {
            bool keyPressed = Keyboard.GetState().GetPressedKeys().Length > 0;
            if (keyPressed)
            {
                timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

                currentIndex = (int)(timeElapsed * fps);

                sprite = sprites[currentIndex];

                if (currentIndex >= sprites.Length - 1)
                {
                    timeElapsed = 0;
                    currentIndex = 0;
                }
            }
            else
            {
                timeElapsed = 0;
                currentIndex = 0;
                sprite = sprites[0];
            }
        }

        private void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 newPosition = position + ((velocity * speed) * deltaTime);
            position = newPosition; // Update the player's position
        }
    }
}

