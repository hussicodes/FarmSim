using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpilProjekt
{
    internal class Inventory : GameObject
    {
        private bool isOpen;
        private Texture2D frameTexture;
        private Rectangle frameRectangle;

        public Inventory(Texture2D frameTexture, Rectangle frameRectangle)
        {
            isOpen = false;
            this.frameTexture = frameTexture;
            this.frameRectangle = frameRectangle;
        }

        public void OpenCloseInventory()
        {
            isOpen = !isOpen;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // tegner kun inventory hvis åben
            if (isOpen)
            {
                spriteBatch.Draw(frameTexture, frameRectangle, Color.White);
            }
        }

        public override void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
