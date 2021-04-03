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
                int getRand() => rand.Next(15, 86);

                graphBack.Fill = getRand();
                graphBounce.Fill = getRand();
                graphCircle.Fill = getRand();
                graphCubic.Fill = getRand();
                graphElastic.Fill = getRand();
                graphExponential.Fill = getRand();
                graphPower.Fill = getRand();
                graphQuadratic.Fill = getRand();
                graphQuartic.Fill = getRand();
                graphQuintic.Fill = getRand();
                graphSine.Fill = getRand();
            });
        }
    }
}
