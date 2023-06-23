using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfGame
{
    public partial class MainWindow : Window
    {
        public const double UpdatesPerSecond = 60.0;

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
            dispatcherTimer = new DispatcherTimer(TimeSpan.FromSeconds(1.0 / UpdatesPerSecond), DispatcherPriority.Send, Update, Dispatcher);
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
            text.Text = (1.0f / dt).ToString("F4");

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
