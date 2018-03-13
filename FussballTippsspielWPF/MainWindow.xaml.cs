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
            var spielTag = SpielTag.FromJson(uebergabeJson);
            
            foreach (var item in spielTag)
	        {
                string team_1 = item.Team1.ShortName;
                string team_2 = item.Team2.ShortName;
                long tore_1 = item.MatchResults[1].PointsTeam1;
                long tore_2 = item.MatchResults[1].PointsTeam2;

    
                if (tore_1 > tore_2)
	            {
                    // team 1 +3 punkte und + 1 sieg in der Datenbank 
	            }else if (tore_1 < tore_2)
	            {
                    // team 2 +3 punkte und +1 sieg in der Datenbank
            	}
                else
	            {
                // beide teams bekommen +1 punkt und ein unenshciden
	            }
	        }
            MessageBox.Show("");
        }


           



    }

}
