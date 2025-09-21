using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wirtualna_lonka
{
    /// <summary>
    /// Interaction logic for StartMenu.xaml
    /// </summary>
    public partial class StartMenu : Window
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int worldSize = Int32.Parse(_worldSize.Text);
            GameWindow gameWindow = new GameWindow(worldSize);
            gameWindow.Show();
            Close();
            return;
        }

        private void _worldSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_worldSize.Text.Length > 0 && _worldSize.Text.All(char.IsNumber))
            {
                _submit.IsEnabled = true;
            }
            else
            {
                _submit.IsEnabled = false;
            }
        }
    }
}
