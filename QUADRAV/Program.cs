using System;
using System.IO;
//Import SFML
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace QUADRAV
{
    class Program
    {
        public static RenderWindow window;
        public static char[] Data;
        public static Sprite pixelSprite;
        public static float CurrentX, CurrentY;
        public static float Space = 8f;
        static void Main(string[] args)
        {
            Load();
            while(window.IsOpen())
            {
                window.DispatchEvents();
            }
        }

        static void Load()
        {
            window = new RenderWindow(new VideoMode(800,600),"QUADRAV 0.3.5");
            pixelSprite = new Sprite(new Texture(new Image("Content/Pixel.png"),new IntRect(0,0,(int)Space,(int)Space)));
            pixelSprite.Color = new Color(128, 128, 128);
            using (StreamReader l = new StreamReader("Content/DNA.txt",true)){
                Console.WriteLine("Reading DNA...");
                string DNA = l.ReadLine();
                Data = DNA.ToCharArray();
                Console.WriteLine("Completed Reading DNA...");
                CurrentX = 400;
                CurrentY = 300;
                foreach (char c in Data)
                {
                    setPoint(c);
                    window.Draw(pixelSprite);
                    window.DispatchEvents();
                }
                window.Display();
        }
        }

        static void setPoint(char a)
        {
            byte r = pixelSprite.Color.R;
            byte g = pixelSprite.Color.G;
            string c = a.ToString();
            switch(c)
            {
                case "A":
                    r += 1;
                    CurrentX += Space;
                    break;
                case "T":
                    g -= 1;
                    CurrentX -= Space;
                    break;
                case "C":
                    r -= 1;
                    CurrentY += Space;
                    break;
                case "G":
                    g += 1;
                    CurrentY -= Space;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            pixelSprite.Color = new Color(r, g, 0);
            pixelSprite.Position = new Vector2f(CurrentX, CurrentY);
        }
    }
}
