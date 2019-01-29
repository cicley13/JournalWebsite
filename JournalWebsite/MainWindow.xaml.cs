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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace JournalWebsite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            Access log = new Access();
            bool validation;

            validation = log.login(Ubox.Text.Trim(), Pbox.Text.Trim());

            if (validation == true)
            {
                MessageBox.Show("Next Step");

            }
            else
            {
                Invalid.Foreground.Opacity = 100;
            }

        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            Access log = new Access();

            log.register(Ubox.Text.Trim(), Pbox.Text.Trim());

        }
    }
}

