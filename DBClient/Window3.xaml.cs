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
        Entities1 db = new Entities1();
      // List<String> p = new List<String>();
       private String sessid;
       private Window w1;
       private String titel;
       private AddProject addpro;

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
           var erg = from a in db.InfoDiplomschrittes
                     group a by a.Di_Titel into grps
                     select new { Titel = grps.Key };

           var erg2 = from a in db.InfoDiplomschrittes
                     group a by a.Di_ID into grps
                     select new { ID = grps.Key };

           //var erg2=erg.Where(b=>b.Dis_Ablaufschritt==erg.Max(x=>x.Dis_Ablaufschritt)).SingleOrDefault();
           
           List<String> liste=new List<String>();
            liste=erg.Select(a=>a.Titel).ToList();

           List<int> listeid=new List<int>();
           listeid = erg2.Select(a => a.ID).ToList();

           for(int i=0;i<liste.Count();i++){
               Button nBtn = new Button();
               nBtn.Content = liste[i].ToString();
               String ab = liste[i].ToString();

               var id = from a in db.InfoDiplomschrittes
                        where a.Di_Titel.Equals(ab)
                        select new { Id=a.Di_ID};
                        
               
               //nBtn.Name = liste[i].ToString();
               nBtn.Name = "a"+listeid[i].ToString();
               nBtn.FontStyle = FontStyles.Italic;
               

               sp.Children.Add(nBtn);

               

               //titel = titel1.ToString();
               
            
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

                if (source.Name.Equals("add"))
                {
                    addpro = new AddProject();
                    addpro.ShowDialog();
                }

                if (source.Name.Equals("add_2"))
                {
                   
                    var erg = from a in db.InfoDiplomschrittes
                              group a by a.Di_Titel into grps
                              select new { Titel = grps.Key };

                    var erg2 = from a in db.InfoDiplomschrittes
                               group a by a.Di_ID into grps
                               select new { ID = grps.Key };

                    //var erg2=erg.Where(b=>b.Dis_Ablaufschritt==erg.Max(x=>x.Dis_Ablaufschritt)).SingleOrDefault();

                    List<String> liste = new List<String>();
                    liste = erg.Select(a => a.Titel).ToList();

                    List<int> listeid = new List<int>();
                    listeid = erg2.Select(a => a.ID).ToList();

                    for (int i = liste.Count() - 1; i < liste.Count(); i++)
                    {
                        Button nBtn = new Button();
                        nBtn.Content = liste[i].ToString();
                        String ab = liste[i].ToString();

                        var id = from a in db.InfoDiplomschrittes
                                 where a.Di_Titel.Equals(ab)
                                 select new { Id = a.Di_ID };


                        //nBtn.Name = liste[i].ToString();
                        nBtn.Name = "a" + listeid[i].ToString();
                        nBtn.FontStyle = FontStyles.Italic;


                        sp.Children.Add(nBtn);

                    }
                     

                }

                else if (source == null) { return; }
                else
                {
                    String nameButton = source.Name;
                    string[] arr = nameButton.Split(new string[] { "a" }, StringSplitOptions.None);
                    // string[] parts = nameButton.Split('.');
                    // int buttonName = Convert.ToInt32(parts[1]);
                    int buttonName = Convert.ToInt32(arr[1]);
                    var titel1 = from a in db.InfoDiplomschrittes
                                 where a.Di_ID.Equals(buttonName)
                                 select a.Di_Titel;

                    w1 = new Window1(titel1.First().ToString(), Convert.ToInt32(arr[1]));
                    w1.ShowDialog();
                }
                    
                

                
            }

           

           
}
}

    
