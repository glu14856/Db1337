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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        Entities2 db = new Entities2();
      // List<String> p = new List<String>();
       private String sessid;

       private DetailsWindow dw;
       private String titel="";

       public Window3(String sessionid)
       {
           InitializeComponent();
           // p.Add("Test"
           
           
           sessid = sessionid;
          // Grid.IsReadOnly = true;
           /**
           var erg = from a in db.InfoDiplomschrittes
                     where a.Akb_Session.Equals(sessid)
                     group a by a.Dis_Ablaufschritt into key
                     select key;
           */
           

           var erg = from a in db.InfoDiplomprojektes
                     group a by a.Di_Titel into grps
                     select new { Titel = grps.Key };

           //var erg2=erg.Where(b=>b.Dis_Ablaufschritt==erg.Max(x=>x.Dis_Ablaufschritt)).SingleOrDefault();
           
           List<String> liste=new List<String>();
            liste=erg.Select(a=>a.Titel).ToList();

           for(int i=0;i<liste.Count();i++){
               Button nBtn = new Button();
               nBtn.Content = liste[i].ToString();
               String ab = liste[i].ToString();
              /** var id = (from a in db.InfoDiplomschrittes
                        where a.Di_Titel.Equals(ab)
                        select a.Di_ID).Single;
                       */ 

               //nBtn.Name = liste[i].ToString();
               nBtn.Name = "";
               nBtn.FontStyle = FontStyles.Oblique;
               

               sp.Children.Add(nBtn);
/**
               var titel1 = from a in db.InfoDiplomschrittes
                           where a.Di_Titel.Equals(id.ToString())
                           select a.Di_Titel;

               titel = titel1.ToString();
               */
           }


        
          // Grid.ItemsSource = erg.ToList();
           


           // LinkedList<String> = erg.ToList(); 

       // var results = from p in persons
            //          group p.car by p.PersonId into g
              //        select new { PersonID = g.Key, Cars = g.ToList() };
    

    }
        
            private void anyButtonClicked(object sender, RoutedEventArgs e)
            {
                var source = e.OriginalSource as FrameworkElement;

                if (source == null)
                    return;
                Button b= (Button)sender;
                Window1 win1 = new Window1(b.Content.ToString());


                /*dw = new DetailsWindow(b.Content.ToString());
                dw.ShowDialog();*/
            }
}
}

  