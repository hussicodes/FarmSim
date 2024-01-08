using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpilProjekt
{
    public static class Global
    {
        // definere en static property der indeholder tid i sekunder
        public static float Time { get; set; }

        // definere en static property der indeholder ContentManager instancen
        public static ContentManager Content { get; set; }

        // definere en static property der indeholder SpriteBatch instancen
        public static SpriteBatch SpriteBatch { get; set; }

        // definere en static property der indeholder WindowSize som en Point
        public static Point WindowSize { get; set; }

        // definere en static metode der opdaterer Time property baseret på GameTime
        public static void Update(GameTime gameTime)
        {
            // beregner den tid der gået i sekunder og opdatere det i Time property
            Time = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
