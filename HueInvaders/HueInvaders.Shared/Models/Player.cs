using System;
using System.IO.IsolatedStorage;
using HueInvaders.Shared.Models.Interfaces;
using HueInvaders.Shared.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace HueInvaders.Shared.Models
{
    public static class Player
    {
        public static int FuelCount { get; set; }
        public static bool MusicEnabled { get; set; }
        public static bool SoundEnabled { get; set; }
        public static bool RedOn { get; set; }
        public static bool BlueOn { get; set; }
        public static bool YellowOn { get; set; }
        public static Color CurrentColor
        {
            get
            {
                if (RedOn && !BlueOn && !YellowOn)
                    return Defaults.Red;
                else if (!RedOn && BlueOn && !YellowOn)
                    return Defaults.Blue;
                else if (!RedOn && !BlueOn && YellowOn)
                    return Defaults.Yellow;
                else if (RedOn && BlueOn && !YellowOn)
                    return Defaults.Purple;
                else if (RedOn && !BlueOn && YellowOn)
                    return Defaults.Orange;
                else if (!RedOn && BlueOn && YellowOn)
                    return Defaults.Green;
                else
                    return Defaults.White;
            }
        }

        public static void Reset()
        {
            RedOn = false;
            BlueOn = false;
            YellowOn = false;
            SoundEnabled = true;
            MusicEnabled = true;
        }

        public static GameData ToGameData()
        {
            return new GameData()
            {
                FuelCount = FuelCount
            };
        }

        public static void FromGameData(GameData gameData)
        {
            FuelCount = gameData.FuelCount;
        }

        public static void AddFuel(int count)
        {
            FuelCount += count;
        }
    }
}
