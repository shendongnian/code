    using System.Windows;
    using System.Xml;
    using System.Linq;
    using System.Collections.Generic;
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public List<IncidentsIncident> ItemCollection { get; set; }
            public MainWindow()
            {
                InitializeComponent();
                XmlDocument doc = new XmlDocument();
                doc.Load("..\\..\\Incidents.xml");
                ItemCollection = new List<IncidentsIncident>();
                foreach (XmlElement item in doc.ChildNodes.OfType<XmlElement>().FirstOrDefault().ChildNodes)
                {
                    ItemCollection.Add(new IncidentsIncident()
                    {
                        IncidentNumber = byte.Parse(item.ChildNodes[0].InnerText),
                        Summary = byte.Parse(item.ChildNodes[1].InnerText),
                        Reason1 = byte.Parse(item.ChildNodes[2].InnerText),
                        Reason2 = byte.Parse(item.ChildNodes[3].InnerText),
                        Reason3 = byte.Parse(item.ChildNodes[4].InnerText)
                    });
                }
                lst_data.ItemsSource = ItemCollection;
            }
        }
    }
