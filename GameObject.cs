using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpilProjekt
{

    internal abstract class GameObject
    {

        protected Texture2D sprite;
        protected Vector2 position;


        public abstract void LoadContent(ContentManager content);
        public abstract void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }
    

    }
}
