using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HueInvaders.Shared.Utils
{
    public static class Defaults
    {
        public static bool DebugMode = false;

        public static Color SpaceBlue = Color.FromNonPremultiplied(0, 31, 75, 255);

        public static Color White = Color.White;
        public static Color Red = Color.Red;
        public static Color Blue = Color.Blue;
        public static Color Yellow = Color.Yellow;
        public static Color Green = Color.Green;
        public static Color Purple = Color.Purple;
        public static Color Orange = Color.Orange;

        public static int GraphicsWidth = 1536;
        public static int GraphicsHeight = 2732;
        public static SpriteFont Font;
        public const string ListenConnectionString = "Endpoint=sb://chrosgames.servicebus.windows.net/;SharedAccessKeyName=SnowConeTycoonDefaultPolicy;SharedAccessKey=QOOEZ1UbIsiR6kLlZYlN3DsRXdYMBAvvyHGEfDjK1xs=";
        public const string NotificationHubName = "SnowConeTycoon";
        public const string VersionNumber = "v1.0.0.0";
    }
}
