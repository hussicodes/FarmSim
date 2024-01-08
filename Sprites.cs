using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpilProjekt
{
    public class Sprites
    {
        private readonly Texture2D playerSprite;
        public Vector2 Position { get; protected set; }
        public Vector2 origin { get; protected set; }

        public Sprites(Texture2D texture2D, Vector2 position)
        {
            playerSprite = texture2D;
            Position = position;
            origin = new(playerSprite.Width / 2, playerSprite.Height / 2);
        }

        public void Draw()
        {
            Global.SpriteBatch.Draw(playerSprite, Position, null, Color.White, 0f, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
