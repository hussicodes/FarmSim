using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using SpilProjekt.Content.Map;

using SpilProjekt.Manager;


namespace SpilProjekt
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<GameObject> gameObjects;
        private Map map;

        private Texture2D earlyAppleTreeTexture;
        private Texture2D midAppleTreeTexture;
        private Texture2D readyAppleTreeTexture;
        private Texture2D appleTreeTexture;

        private Texture2D earlyOrangeTreeTexture;
        private Texture2D midOrangeTreeTexture;
        private Texture2D readyOrangeTreeTexture;
        private Texture2D orangeTreeTexture;

        private Texture2D earlyBananaTreeTexture;
        private Texture2D midBananaTreeTexture;
        private Texture2D readyBananaTreeTexture;
        private Texture2D bananaTreeTexture;

        private FruitTree appleTree;
        private FruitTree bananaTree;
        private FruitTree orangeTree;


        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            gameObjects = new List<GameObject>();
            Player player = new Player();
            gameObjects.Add(player);

            Global.WindowSize = new Point(1024, 768);
            _graphics.PreferredBackBufferWidth = (int)Global.WindowSize.X;
            _graphics.PreferredBackBufferHeight = (int)Global.WindowSize.Y;
            _graphics.ApplyChanges();


            base.Initialize();
        }
        public List<Vector2> GetTreePositions()
        {
            List<Vector2> treePositions = new List<Vector2>();

            // Add positions of the trees in your game world
            treePositions.Add(new Vector2(100, 100)); // Example position of apple tree
            treePositions.Add(new Vector2(500, 50));  // Example position of orange tree
            treePositions.Add(new Vector2(200, 500)); // Example position of banana tree

            return treePositions;
        }

        // Expose tree collision boxes for more accurate collision detection
        public List<Rectangle> GetTreeCollisionBoxes()
        {
            List<Rectangle> treeCollisionBoxes = new List<Rectangle>();

            // Add collision boxes for the trees
            treeCollisionBoxes.Add(new Rectangle(/* Define collision box for apple tree */));
            treeCollisionBoxes.Add(new Rectangle(/* Define collision box for orange tree */));
            treeCollisionBoxes.Add(new Rectangle(/* Define collision box for banana tree */));

            return treeCollisionBoxes;

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            // Load textures for apple tree stages
            earlyAppleTreeTexture = Content.Load<Texture2D>("Fruits/EarlyStageApple");
            midAppleTreeTexture = Content.Load<Texture2D>("Fruits/MidStageApple");
            readyAppleTreeTexture = Content.Load<Texture2D>("Fruits/ReadyApple");

            // Initialize apple tree with textures
            appleTree = new FruitTree(earlyAppleTreeTexture, midAppleTreeTexture, readyAppleTreeTexture);
            appleTreeTexture = earlyAppleTreeTexture; // Start with the early stage texture


            // Load textures for Banana tree stages
            earlyBananaTreeTexture = Content.Load<Texture2D>("Fruits/EarlyStageBanana");
            midBananaTreeTexture = Content.Load<Texture2D>("Fruits/MidStageBanana");
            readyBananaTreeTexture = Content.Load<Texture2D>("Fruits/ReadyBanana");

            // Initialize Banana tree with textures
            bananaTree = new FruitTree(earlyBananaTreeTexture, midBananaTreeTexture, readyBananaTreeTexture);
            bananaTreeTexture = earlyBananaTreeTexture; // Start with the early stage texture


            // Load textures for Orange tree stages
            earlyOrangeTreeTexture = Content.Load<Texture2D>("Fruits/EarlyStageOrange");
            midOrangeTreeTexture = Content.Load<Texture2D>("Fruits/MidStageOrange");
            readyOrangeTreeTexture = Content.Load<Texture2D>("Fruits/ReadyOrange");

            // Initialize Orange tree with textures
            orangeTree = new FruitTree(earlyOrangeTreeTexture, midOrangeTreeTexture, readyOrangeTreeTexture);
            orangeTreeTexture = earlyOrangeTreeTexture; // Start with the early stage texture

            // Load content for game objects

            foreach (GameObject obj in gameObjects)
            {
                obj.LoadContent(Content);
            }

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Check for specific input to water the tree (for example, when "Q" key is pressed)
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                // Water the tree here
                appleTree.WaterTree();

                // Update the tree texture based on the new growth stage
                switch (appleTree.GetCurrentStage())
                {
                    case GrowthStage.Early:
                        appleTreeTexture = earlyAppleTreeTexture;
                        bananaTreeTexture = earlyBananaTreeTexture;
                        orangeTreeTexture = earlyOrangeTreeTexture;
                        break;
                    case GrowthStage.Mid:
                        appleTreeTexture = midAppleTreeTexture;
                        bananaTreeTexture = midBananaTreeTexture;
                        orangeTreeTexture = midOrangeTreeTexture;
                        break;
                    case GrowthStage.Ready:
                        appleTreeTexture = readyAppleTreeTexture;
                        bananaTreeTexture = readyBananaTreeTexture;
                        orangeTreeTexture = readyOrangeTreeTexture;
                        break;
                }
            }

            // Update game objects
            foreach (GameObject obj in gameObjects)
            {
                obj.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            map.Draw();


            // Draw the apple, orange and banana tree texture at a specific position
            _spriteBatch.Draw(appleTreeTexture, new Vector2(100, 100), Color.White);
            _spriteBatch.Draw(orangeTreeTexture, new Vector2(500, 50), Color.White);
            _spriteBatch.Draw(bananaTreeTexture, new Vector2(200, 500), Color.White);

            // Draw game objects


            foreach (GameObject obj in gameObjects)
            {
                obj.Draw(_spriteBatch);
            }


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
