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
using JournalLibrary;

namespace JournalWebsite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Do not worry about this. This is just initialize your page. In another words, starting your page.
        public MainWindow()
        {
            InitializeComponent();
        }

        //Log in button click event. The codes will execute when the log in button is clicked.
        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            //Assigning the logIn with a bool by calling the login method using Ubox and Pbox in the xaml page as arguements. 
            bool LogIn = Access.login(Ubox.Text.Trim(), Pbox.Text.Trim());

            //If the login is true. Execute the following code.
            if (LogIn == true)
            {
                /*"windownav" is the name of the frame from MainWindow.xaml. Source basically means that this frame is the main source to navigate through.
                 We are navigating through a new URI, Uniformed Resource Identifier aka our next page. Then we put our page name. Then we put urikind 
                 which means the different kinds of URI. The URI we are using is a relative to our main source. Well from what I know.*/
                windownav.Source = new Uri("MainPage.xaml", UriKind.Relative);
            }
            else
            {
                //If the login is false, then make the textblock opacity to 100.
                Invalid.Foreground.Opacity = 100;
            }
    
        }
        //Register button click event. The codes will execute when the register button is clicked.
        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            /*"windownav" is the name of the frame from MainWindow.xaml. Source basically means that this frame is the main source to navigate through.
                We are navigating through a new URI, Uniformed Resource Identifier aka our next page. Then we put our page name. Then we put urikind 
                which means the different kinds of URI. The URI we are using is a relative to our main source. Well from what I know.*/
            windownav.Source = new Uri("Register.xaml", UriKind.Relative);
        }
    }
}

