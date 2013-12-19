using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfGame
{
    public class Sprite
    {
        private BitmapImage bitmap;

        public Image Image { get; private set; }

        public Sprite(BitmapImage bitmap)
        {
            this.bitmap = bitmap;
            this.Image = new Image();
            Image.Source = bitmap;
        }

        public void UpdatePosition(Point point)
        {
            Image.Margin = new Thickness(point.X, point.Y, 0, 0);
        }
    }
}
