using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpilProjekt
{
    public class Hero {

        private const float speed = 500;
        private Vector2 minPos, maxPos;
        private readonly Texture2D playerSprite;
        public Vector2 Position { get; protected set; }
        public Vector2 Origin { get; protected set; }

        public void SetBounds(Point mapSize, Point tileSize)
        {
            minPos = new((-tileSize.X / 2) + Origin.X, (-tileSize.Y / 2) - Origin.Y);
            maxPos = new(mapSize.X - (tileSize.X / 2) - Origin.X, mapSize.Y - (tileSize.X / 2) - Origin.Y);
        }

        public Hero(Texture2D texture2D, Vector2 position)
        {
            playerSprite = texture2D;
            Position = position;
            Origin = new(playerSprite.Width / 2, playerSprite.Height / 2);
        }

        public void Draw()
        {
            Global.SpriteBatch.Draw(playerSprite, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
        }

        public void Update()
        {
            //Position += InputManager.direction2 * Global.Time * speed;
            Position = Vector2.Clamp(Position, minPos, maxPos);
        }
    }
}
