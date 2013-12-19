using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfGame
{
    public static class ContentManager
    {
        private static Dictionary<string, Sprite> sprites;

        static ContentManager()
        {
            sprites = new Dictionary<string, Sprite>();
        }

        public static Sprite GetSprite(string path)
        {
            Sprite sprite;
            if (!sprites.TryGetValue(path, out sprite))
            {
                var image = new BitmapImage(new Uri(path, UriKind.Relative));
                sprite = new Sprite(image);
                sprites[path] = sprite;

            }
            return sprite;
        }

        public static void UpdateContent()
        {
        }
    }
}
