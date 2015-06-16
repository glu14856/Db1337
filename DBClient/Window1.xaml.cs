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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private String pname;
        private Entities1 db;
        private int id;
        public Window1()
        {
            InitializeComponent();

        }
        public Window1(String pname,int id1)
        {
            InitializeComponent();
            Entities1 db = new Entities1();
            TitelBox.Text = pname;
            this.id = id1;
            this.pname = pname;

            var erg = from a in db.InfoDiplomprojektes
                      where a.Di_Titel == pname
                      select a;

            var erg2 = from b in db.InfoDiplomschrittes
                       where b.Di_Titel == pname
                       orderby b.Dis_Ablaufschritt
                       select new { Schritt = b.Dis_Ablaufschritt, Start = b.Dis_Start, Benutzer = b.Dis_Ben_ID};

            //List<InfoDiplomprojekte> ddetails = new List<InfoDiplomprojekte>();
            //ddetails = erg.ToList();
            grid.ItemsSource = erg2.ToList();


        }

        private void schrittHoch(String kommentar)
        {
           /** var id = from a in db.InfoDiplomprojektes
                     where a.Di_Titel.Equals(pname)
                     select a.Di_ID;
            * */
           // feg.Text = id.ToString();


            try {
                if (db.Diplschritthoch(id, kommentar).First().Contains("null"))
                {
                    feg.Text="hat funktioniert";
                }
            }
            catch (NullReferenceException e) { feg.Text = "FALSCH"; }
              
          
           
        }
        private void schrittRunter(String kommentar,int runter)
        {
           
            db.Diplschrittrunter(id, kommentar, runter);
            
            
        }

        private void addb_Click(object sender, RoutedEventArgs e)
        {
            
            schrittHoch("aaaa");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            schrittRunter("test", 2);
        }
    }
}