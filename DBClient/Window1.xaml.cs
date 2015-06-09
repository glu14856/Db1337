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
        String pname;
        public Window1()
        {
            InitializeComponent();

        }
        public Window1(String pname)
        {
            InitializeComponent();
            this.pname = pname;
            Entities2 db = new Entities2();

            var erg = from a in db.InfoDiplomprojektes
                      where a.Di_Titel == pname
                      select a;

            var erg2 = from b in db.InfoDiplomschrittes
                       where b.Di_Titel == pname
                       orderby b.Dis_Ablaufschritt
                       select new {Schritt=b.Dis_Ablaufschritt,Start=b.Dis_Start,Benutzer=b.Dis_Ben_ID,Order=b.As_Order};

            List<InfoDiplomprojekte> ddetails= new List<InfoDiplomprojekte>();
            ddetails= erg.ToList();

            grid = new DataGrid();
            grid.DataContext = grid;

            
            
        }

        private void addb_Click(object sender, RoutedEventArgs e)
        {

        }

        private void schrittHoch(Entities2 e,String kommentar)
        {
            var id= from a in e.InfoDiplomprojektes
                    where a.Di_Titel==pname
                    select a.Di_ID;
            e.Diplschritthoch(id.First(), kommentar);
        }
    }
}
