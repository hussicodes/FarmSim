using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpilProjekt.Content.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpilProjekt.Manager
{
    //public class GameManager
    //{
    //    private readonly Map map;
    //    private Matrix translation;

    //    public GameManager()
    //    {
    //        map = new();
    //      //  hero.SetBounds(map.MapSize, map.TileSize);
    //    }

    //    private void CalculateTranslation()
    //    {
    //      var dx = (Global.WindowSize.X / 2) - hero.Position.X;
    //      dx = MathHelper.Clamp(dx, -map.MapSize.X + Global.WindowSize.X + (map.TileSize.X / 2), map.TileSize.X / 2);
    //      var dy = (Global.WindowSize.Y / 2) - hero.Position.Y;
    //      dy = MathHelper.Clamp(dy, -map.MapSize.Y + Global.WindowSize.Y + (map.TileSize.Y / 2), map.TileSize.Y / 2);
    //      translation = Matrix.CreateTranslation(dx, dy, 0f);
    //    }
    //    public void Update()
    //    {
    //      //  hero.Update();
    //        CalculateTranslation();
    //    }

    //    public void Draw()
    //    {
    //        Global.SpriteBatch.Begin(transformMatrix: translation);
    //        map.Draw();
    //        hero.Draw();
    //        Global.SpriteBatch.End();
    //    }
    //}
}
