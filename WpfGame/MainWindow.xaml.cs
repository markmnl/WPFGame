using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfGame
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer;
        private Stopwatch stopwatch;
        private long ticksAtLastUpdate;
        private Sprite dudeSprite;
        
        public MainWindow()
        {
            InitializeComponent();
            Init();
            stopwatch = new Stopwatch();
            stopwatch.Start();
            dispatcherTimer = new DispatcherTimer(TimeSpan.FromMilliseconds(32), DispatcherPriority.Normal, Update, Dispatcher);
            dispatcherTimer.Start();
        }

        public void Init()
        {
            dudeSprite = ContentManager.GetSprite("Content\\Dude.PNG");
            ShowSprite(dudeSprite);
        }

        private void Update(object sender, EventArgs e)
        {
            float dt = (stopwatch.ElapsedTicks - ticksAtLastUpdate) / (float)Stopwatch.Frequency;
            ticksAtLastUpdate = stopwatch.ElapsedTicks;
            text.Text = dt.ToString();

            var point = Mouse.GetPosition(canvas);
            dudeSprite.UpdatePosition(point);
        }

        public void ShowSprite(Sprite sprite)
        {
            canvas.Children.Add(sprite.Image);
        }

        public void HideSprite(Sprite sprite)
        {
            canvas.Children.Remove(sprite.Image);
        }
    }
}
