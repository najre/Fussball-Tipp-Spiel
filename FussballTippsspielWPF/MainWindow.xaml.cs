using System.Collections.Generic;
using System.Windows;
using Newtonsoft.Json;
using System.Web.Script.Serialization;


namespace FussballTippsspielWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Json json = new Json();
            string uebergabeJson = json.JsonRunterladen("26");
            List<Spiele> lp = k(uebergabeJson);
            string p = ""; 



        }


        public List<Spiele> k(string json)
        {
            List<Spiele> example2Model = (List<Spiele>)new JavaScriptSerializer().Deserialize(json,typeof( List<Spiele>));
            return example2Model;
        }




    }

}
