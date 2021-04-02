using System.Windows;

namespace AnimationExample
{
    /// <summary> Interaction logic for MainWindow.xaml </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
            => InitializeComponent();

        private void OpenDialog_Click(object sender, RoutedEventArgs e)
            => PopupDialog.ShowDialog(this);
    }
}
