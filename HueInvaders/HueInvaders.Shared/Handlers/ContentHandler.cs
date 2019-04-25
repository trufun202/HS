using System;
using System.Collections.Generic;
using System.Text;
using HueInvaders.Shared.Models;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace HueInvaders.Shared.Handlers
{
    public static class ContentHandler
    {
        public static Dictionary<string, Texture2D> Images;
        public static Dictionary<string, ControlledSoundEffect> Sounds;

        public static void PreInit(ContentManager content)
        {
            Images = new Dictionary<string, Texture2D>();

            ///////////////////////////////////////////
            //LOADING SCREEN
            ///////////////////////////////////////////
            //Images.Add("Loading_Frame", content.Load<Texture2D>("Loading_Frame"));
        }

        public static void Init(ContentManager content)
        {
            Sounds = new Dictionary<string, ControlledSoundEffect>();

            //////////////////////////
            // SHIPS
            //////////////////////////
            Images.Add("Player_1", content.Load<Texture2D>("Player_1"));
            Images.Add("Enemy_1", content.Load<Texture2D>("Enemy_1"));

            //////////////////////////
            // LASERS
            //////////////////////////
            Images.Add("Laser_1", content.Load<Texture2D>("Laser_1"));

            //////////////////////////
            // UI
            //////////////////////////
            Images.Add("ColorButton_Off", content.Load<Texture2D>("ColorButton_Off"));
            Images.Add("ColorButton_On", content.Load<Texture2D>("ColorButton_On"));

            //////////////////////////
            // PARTICLES
            //////////////////////////
            Images.Add("Particle_1", content.Load<Texture2D>("Particle_1"));
            Images.Add("Particle_2", content.Load<Texture2D>("Particle_2"));
            Images.Add("Particle_3", content.Load<Texture2D>("Particle_3"));
            Images.Add("Particle_4", content.Load<Texture2D>("Particle_4"));

            //////////////////////////
            // EXPLOSIONS
            //////////////////////////
            Images.Add("ToonExplosion4_0000", content.Load<Texture2D>("ToonExplosion4_0000"));
            Images.Add("ToonExplosion4_0001", content.Load<Texture2D>("ToonExplosion4_0001"));
            Images.Add("ToonExplosion4_0002", content.Load<Texture2D>("ToonExplosion4_0002"));
            Images.Add("ToonExplosion4_0003", content.Load<Texture2D>("ToonExplosion4_0003"));
            Images.Add("ToonExplosion4_0004", content.Load<Texture2D>("ToonExplosion4_0004"));
            Images.Add("ToonExplosion4_0005", content.Load<Texture2D>("ToonExplosion4_0005"));
            Images.Add("ToonExplosion4_0006", content.Load<Texture2D>("ToonExplosion4_0006"));
            Images.Add("ToonExplosion4_0007", content.Load<Texture2D>("ToonExplosion4_0007"));
            Images.Add("ToonExplosion4_0008", content.Load<Texture2D>("ToonExplosion4_0008"));
            Images.Add("ToonExplosion4_0009", content.Load<Texture2D>("ToonExplosion4_0009"));
            Images.Add("ToonExplosion4_0010", content.Load<Texture2D>("ToonExplosion4_0010"));
            Images.Add("ToonExplosion4_0011", content.Load<Texture2D>("ToonExplosion4_0011"));
            Images.Add("ToonExplosion4_0012", content.Load<Texture2D>("ToonExplosion4_0012"));
            Images.Add("ToonExplosion4_0013", content.Load<Texture2D>("ToonExplosion4_0013"));
            Images.Add("ToonExplosion4_0014", content.Load<Texture2D>("ToonExplosion4_0014"));
            Images.Add("ToonExplosion4_0015", content.Load<Texture2D>("ToonExplosion4_0015"));
            Images.Add("ToonExplosion4_0016", content.Load<Texture2D>("ToonExplosion4_0016"));

            //////////////////////////
            // MISC
            //////////////////////////
            Images.Add("WhiteDot", content.Load<Texture2D>("WhiteDot"));
            Images.Add("debugbox", content.Load<Texture2D>("debugbox"));

            ///////////////////////////////////////////
            //SOUNDS
            ///////////////////////////////////////////
            Sounds.Add("Picker_Up", new ControlledSoundEffect(content.Load<SoundEffect>("Picker_Up").CreateInstance()));
            Sounds.Add("Picker_Down", new ControlledSoundEffect(content.Load<SoundEffect>("Picker_Down").CreateInstance()));
        }
    }
}
