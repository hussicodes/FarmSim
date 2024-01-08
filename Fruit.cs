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
    public enum GrowthStage
    {
        Early,
        Mid,
        Ready
    }

    // Fruit class
    public abstract class Fruit
    {
        protected GrowthStage currentStage;

        public Fruit()
        {
            currentStage = GrowthStage.Early;
        }

        // Method to simulate the fruit's growth
        public void Grow()
        {
            // Logic to advance the fruit's growth stage
            switch (currentStage)
            {
                case GrowthStage.Early:
                    currentStage = GrowthStage.Mid;
                    break;
                case GrowthStage.Mid:
                    currentStage = GrowthStage.Ready;
                    break;
                case GrowthStage.Ready:
                    // Fruit is already at the highest growth stage
                    break;
            }
        }

        // Method to get the current growth stage of the fruit
        public GrowthStage GetCurrentStage()
        {
            return currentStage;
        }
    }
}

