using System.Windows;
using System.Timers;
using System;
using System.Windows.Media.Animation;

namespace AnimationExample
{
    /// <summary> Interaction logic for MainWindow.xaml </summary>
    public partial class MainWindow : Window
    {
        Timer timer = new Timer(5000) { AutoReset = true };
        Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
            
            setupEasingFunctions();

            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void setupEasingFunctions()
        {
            // experiment with easing functions:

            // using System.Windows.Media.Animation;
            graphBack.RectHeightAnimation.EasingFunction = new BackEase { EasingMode = EasingMode.EaseInOut, Amplitude = 1 };
            graphBounce.RectHeightAnimation.EasingFunction = new BounceEase { Bounces = 2, Bounciness = 10, EasingMode = EasingMode.EaseInOut };
            graphCircle.RectHeightAnimation.EasingFunction = new CircleEase { EasingMode = EasingMode.EaseInOut };
            graphCubic.RectHeightAnimation.EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut };
            graphElastic.RectHeightAnimation.EasingFunction = new ElasticEase { Oscillations = 1, Springiness = 5, EasingMode = EasingMode.EaseInOut };
            graphExponential.RectHeightAnimation.EasingFunction = new ExponentialEase { EasingMode = EasingMode.EaseInOut, Exponent = 2 };
            graphPower.RectHeightAnimation.EasingFunction = new PowerEase { EasingMode = EasingMode.EaseInOut, Power = 2 };
            graphQuadratic.RectHeightAnimation.EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut };
            graphQuartic.RectHeightAnimation.EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut };
            graphQuintic.RectHeightAnimation.EasingFunction = new QuinticEase { EasingMode = EasingMode.EaseInOut };
            graphSine.RectHeightAnimation.EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut };
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // make random changes to the graphs
            Dispatcher.Invoke(() =>
            {
                graphBack.Fill = rand.Next(0, graphBack.MaxFill + 1);
                graphBounce.Fill = rand.Next(0, graphBounce.MaxFill + 1);
                graphCircle.Fill = rand.Next(0, graphCircle.MaxFill + 1);
                graphCubic.Fill = rand.Next(0, graphCubic.MaxFill + 1);
                graphElastic.Fill = rand.Next(0, graphElastic.MaxFill + 1);
                graphExponential.Fill = rand.Next(0, graphExponential.MaxFill + 1);
                graphPower.Fill = rand.Next(0, graphPower.MaxFill + 1);
                graphQuadratic.Fill = rand.Next(0, graphQuadratic.MaxFill + 1);
                graphQuartic.Fill = rand.Next(0, graphQuartic.MaxFill + 1);
                graphQuintic.Fill = rand.Next(0, graphQuintic.MaxFill + 1);
                graphSine.Fill = rand.Next(0, graphSine.MaxFill + 1);
            });
        }
    }
}
