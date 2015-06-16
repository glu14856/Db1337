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

namespace DBClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities1 db = new Entities1();
        Window1 w1=new Window1();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string benutzer = Benutzer.Text;
            string password = Passwd.Password;


            if (db.benutzeraccverify(benutzer, password).ToArray().First().Contains("ERROR") == false)
            {
                Status.Text = "eingeloggt";
                string sessionid = db.benutzerlogin(benutzer, null).ToArray().First();
                Window3 w3 = new Window3(sessionid);
                w3.Show();
                Close();
              //  Status.Text = "eingeloggt" + " SessionID=" + sessionid;
            }
            else
            {
                Status.Text = "falsche Daten!";
            }
           
        }


    }
}
