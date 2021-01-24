         using System;
        using System.Collections.Generic;
        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Input;
        
        namespace WpfApp4
        {
            public class MyItems
            {
                public int Col1 { get; set; }
                public int Col2 { get; set; }
                public int Col3 { get; set; }
                public int Col4 { get; set; }
            }
        
            public partial class MainWindow : Window
            {
                // create a source for the datagrid
                public List<MyItems> DataList { get; set; }
        
                // somewhere to hold the selected cells
                IList<DataGridCellInfo> DataGridSelectedCells { get; set; }
        
                public MainWindow()
                {
                    InitializeComponent();
                    DataContext = this;
        
                    DataList = new List<MyItems>()
                    {
                        new MyItems() { Col1=1, Col2=2, Col3=3, Col4=4},
                        new MyItems() { Col1=5, Col2=6, Col3=7, Col4=8},
                        new MyItems() { Col1=9, Col2=10, Col3=11, Col4=12},
                        new MyItems() { Col1=13, Col2=14, Col3=15, Col4=16},
                    };
        
                    MyGrid.ItemsSource = DataList;
        
                }
        
                private void SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
                {
                    DataGridSelectedCells = MyGrid.SelectedCells;
                }
        
                private void MyGrid_PreviewKeyUp(object sender, KeyEventArgs e)
                {
                    // Check your key here (Ctrl D, Ctrl R etc)
        
                   
                    // then loop around your data looking at what is selected
                    // chosing the direction based on what key was pressed
        
        
                    foreach (DataGridCellInfo d in DataGridSelectedCells)
                    {   // get the content of the cell           
                        var cellContent = d.Column.GetCellContent(d.Item);
                        if (cellContent != null)
                        {  // if it's not null try to get the content
                            DataGridCell dc = (DataGridCell)cellContent.Parent;
                            TextBlock tb = (TextBlock)dc.Content;
        
                            // Change the contents of tb.Content here
        
                            // or dump for debugging
                            Console.WriteLine(tb.Text);
                        }
                    }
                }
            }
    }
