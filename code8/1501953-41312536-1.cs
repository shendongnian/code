    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Xml;
    using System.Xml.Linq;
    namespace TreeView_Test
    {
        class Program
        {
            static AutoResetEvent autoEvent = new AutoResetEvent(false);
            [STAThread]
            static void Main(string[] args)
            {
                MainWindow window = new MainWindow();
                window.ShowDialog();
                autoEvent.WaitOne();
            }
        }
        public partial class MainWindow : Window
        {
            private TreeViewItem tree; // TreeViewItem reference
            private TreeView xmlTreeView = new TreeView();
            const string FILENAME1 = @"c:\temp\test1.xml";
            const string FILENAME2 = @"c:\temp\test2.xml";
            public MainWindow()
            {
                InitializeComponent();
                this.Loaded +=new RoutedEventHandler(Window_Loaded);
            }
            private void InitializeComponent()
            {
                this.AddChild(xmlTreeView);
                this.Activate();
            }
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
               
                tree = new TreeViewItem(); // instantiate TreeViewItem
                tree.Header = "Projekt"; // assign name to TreeViewItem  
                xmlTreeView.Items.Add(tree); // add TreeViewItem to TreeView  
                XDocument doc = XDocument.Load(FILENAME1);
                XElement element = (XElement)doc.FirstNode;
                BuildTree(element, tree); // build node and tree hierarchy
                doc = XDocument.Load(FILENAME2);
                element = (XElement)doc.FirstNode;
                BuildTree(element, tree); // build node and tree hierarchy
            }
            private void BuildTree(XElement element, TreeViewItem treeViewItem)
            {
                // TreeViewItem to add to existing tree
                TreeViewItem newNode = new TreeViewItem();
                treeViewItem.Items.Add(newNode);
                newNode.Header = element.Name.LocalName;
                if (!element.HasElements)
                {
                    TreeViewItem newText = new TreeViewItem();
                    newNode.Items.Add(newText);
                    newText.Header = element.Value;
                }
                else
                {
                    foreach (XElement child in element.Elements())
                    {
                        BuildTree(child, newNode);
                    }
                }
            }
        }
    }
