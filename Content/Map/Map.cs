using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpilProjekt.Content.Map
{
    public class Map
    {
        // FIELDS
        // definerer størelsen på map i tiltes
        private readonly Point mapTileSize = new(6, 5);

        // 2D array til at indeholde Sprites der repræsentere hver tiles
        private readonly Sprites[,] tiles;

        //PROPERTIES
        // Properties der fremviser map og tile størrelsen
        public Point TileSize { get; private set; }
        public Point MapSize { get; private set; }

        // Constructor for map klassen
        public Map()
        {
            // initialisere tiles array baseret på den specifikke tile størrelse
            tiles = new Sprites[mapTileSize.X, mapTileSize.Y];

            // opretter en list der indeholder textures for tiles
            List<Texture2D> textures = new(5);

            // loader textures ind i en loop og køre det igennem 5 gange som er tilsvarende til de 5 tiles der gemt 
            for (int i = 1; i < 6; i++)
            {
                // tile1, tile2, osv op til tile5
                textures.Add(Global.Content.Load<Texture2D>($"tile{i}"));
            }

            // Sætter størrelsen på hver af de tile baseret på den første texture
            TileSize = new Point(textures[0].Width, textures[0].Height);

            // beregner størrelsen på selve map
            MapSize = new Point(TileSize.X * mapTileSize.X, TileSize.Y * mapTileSize.Y);

            // opretter en random number generator som vælger en tilfældig texture 
            Random random = new();

            // fylder tiles array ud med tilfældige tiles og positioner
            for (int y = 0; y < mapTileSize.Y; y++)
            {
                for (int x = 0; x < mapTileSize.X; x++)
                {
                    // generere en random (r) fra textures
                    int r = random.Next(0, textures.Count);

                    // opretter en ny sprite objekt med en valgte texture
                    // og positionere det baseret på tiles nuværende position
                    tiles[x, y] = new(textures[r], new(x * TileSize.X, y * TileSize.Y));
                }
            }
        }

        // En metode til at draw kortet ved at kklade på draw metoden for hver tile
        public void Draw()
        {
            for (int y = 0; y < mapTileSize.Y; y++)
            {
                for (int x = 0; x < mapTileSize.X; x++) 
                    tiles[x, y].Draw(); // kalder på draw metoden for hver tiles i tiles array
            }
        }
    }
}

