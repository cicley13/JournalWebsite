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
using JournalLibrary;

namespace JournalWebsite
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        //Do not worry about this. This is just initialize your page. In another words, starting your page.
        public Register()
        {
            InitializeComponent();
        }

        //Register button click event. The codes will execute when the register button is clicked.
        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            //Assigning the reg with an int by calling the register method using Ubox and Pbox in the xaml page as arguements. 
            int reg = Access.register(Ubox.Text.Trim(), Pbox.Text.Trim());

            //If the reg is 0. The opacity for the "Taken Username" will be 100. It will show up.
            if (reg == 0)
            {
                //Statement to make the textblock opacity to 100.
                TAKEN.Foreground.Opacity = 100;
            }

            //If the reg is 1. The opacity for the "No password or sername" will be 100. It will show up.
            else if (reg == 1)
            {
                //Statement to make the textblock opacity to 100.
                NoPass.Foreground.Opacity = 100;
            }
            //If reg is 3. The program will navigate to the other page.
            else if (reg == 2)
            {
                //"Nav" is the navigation service. We GetNavigationService from "this". "This" is Register.xaml
                NavigationService nav = NavigationService.GetNavigationService(this);

                /*So nav, which is the navigation service from Register.xaml, will navigate through a new URI, Uniformed Resource Identifier aka our next page. 
                 Then we put our page name. Then we put urikind which means the different kinds of URI. The URI we are using is a relative to our main source. 
                 Well from what I know.*/
                nav.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
            }
        }
    }
}
