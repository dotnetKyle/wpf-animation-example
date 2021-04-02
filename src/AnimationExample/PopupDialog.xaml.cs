using System.Windows;

namespace AnimationExample
{
    /// <summary> Interaction logic for PopupDialog.xaml </summary>
    public partial class PopupDialog : Window
    {
        public PopupDialog()
            => InitializeComponent();
        
        private void Ok_Click(object sender, RoutedEventArgs e) 
            => Close();

        public static PopupDialog ShowDialog(Window owner)
        {
            var dlg = new PopupDialog();
            dlg.Owner = owner;
            dlg.ShowDialog();
            return dlg;
        }
    }
}
