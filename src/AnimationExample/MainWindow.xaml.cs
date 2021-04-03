using System.Windows;
using System.Timers;
using System;

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
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                var rand1 = rand.Next(0, 100);
                var rand2 = rand.Next(0, 100);
                System.Diagnostics.Debug.WriteLine($"Timer - Random 1:{rand1}");
                System.Diagnostics.Debug.WriteLine($"Timer - Random 2:{rand2}");
                graph1.Fill = rand1;
                graph2.Fill = rand2;
            });
        }

        private void OpenDialog_Click(object sender, RoutedEventArgs e)
            => PopupDialog.ShowDialog(this);
    }
}
