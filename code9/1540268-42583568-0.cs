    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace ListBox_42581647
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                Doit();
            }
    
            private void Doit()
            {
                ListBox lb = new ListBox();//create a listbox
                lb.Items.Add(new aPlace { placename = "TheBar", placeCoolFactor = "booze" });//add something to the listbox
                lb.Items.Add(new aPlace { placename = "TheHouse", placeCoolFactor = "bowl"});//add something to the listbox
                lb.Items.Add(new aPlace { placename = "ThePark", placeCoolFactor = "dogs" });//add something to the listbox
    
                lb.SelectedItem = lb.Items[1];//lets fake a selection
    
                var theSelectedPlace = lb.SelectedItem;//the actual item selected
                var theSelectedPlaceName = ((aPlace)lb.SelectedItem).placename;//the selected item place name
                var theSelectedPlaceCoolFactor = ((aPlace)lb.SelectedItem).placeCoolFactor;//the selected item place cool factor
    
    
                //now I'll create your (lets call it A)
                List<aPlace> parallelList = new List<aPlace>();//lets call it A
                parallelList.Add((aPlace)lb.Items[0]);//This list contains the same items your ListBox contains
                parallelList.Add((aPlace)lb.Items[1]);//This list contains the same items your ListBox contains
                parallelList.Add((aPlace)lb.Items[2]);//This list contains the same items your ListBox contains
    
                //find the selected by matching the selected Placename
                aPlace theChosenPlace = parallelList.Where(p => p.placename == theSelectedPlaceName).FirstOrDefault();
                //find the selected by matching the actual item
                aPlace theChosenPlace2 = parallelList.Where(p => p == theSelectedPlace).FirstOrDefault();
            }
    
        }
    
        public class aPlace
        {
            public string placename { get; set; }
            public string placeCoolFactor { get; set; }
        }
    
    
    }
