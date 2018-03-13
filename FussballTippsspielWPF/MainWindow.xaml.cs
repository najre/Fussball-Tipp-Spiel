using System.Collections.Generic;
using System.Windows;
using Newtonsoft.Json;

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
            List<Spiele> spiele = DeserializeAccount(uebergabeJson);
            //MessageBox.Show(spiele[1].Property1.Team1.TeamName.ToString);
            MessageBox.Show("");
        }

        public List<Spiele> DeserializeAccount(string json)
        {
            return JsonConvert.DeserializeObject<List<Spiele>>(json);

        }



    }

}
