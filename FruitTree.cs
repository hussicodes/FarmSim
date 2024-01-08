using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpilProjekt
{
    public class FruitTree
    {
        private Texture2D earlyStageTexture;
        private Texture2D midStageTexture;
        private Texture2D readyStageTexture;

        private GrowthStage currentStage;

        public Vector2 Position { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public FruitTree(Texture2D earlyTexture, Texture2D midTexture, Texture2D readyTexture)
        {
            earlyStageTexture = earlyTexture;
            midStageTexture = midTexture;
            readyStageTexture = readyTexture;

            currentStage = GrowthStage.Early; // Start at the early growth stage
        }

        public void WaterTree()
        {
            // Logic to water the tree and advance the growth stage
            switch (currentStage)
            {
                case GrowthStage.Early:
                    currentStage = GrowthStage.Mid;
                    break;
                case GrowthStage.Mid:
                    currentStage = GrowthStage.Ready;
                    break;
                case GrowthStage.Ready:
                    // Tree is already at the highest growth stage
                    break;
            }
        }

        public Texture2D GetCurrentTexture()
        {
            switch (currentStage)
            {
                case GrowthStage.Early:
                    return earlyStageTexture;
                case GrowthStage.Mid:
                    return midStageTexture;
                case GrowthStage.Ready:
                    return readyStageTexture;
                default:
                    return null; // Handle any other cases or errors
            }
        }

        public GrowthStage GetCurrentStage()
        {
            return currentStage;
        }
    }
}

