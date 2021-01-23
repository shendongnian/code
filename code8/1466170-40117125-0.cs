    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace CanvasDragDrop
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private ListBoxItem draggedItem;
    
            private void ListBoxItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                draggedItem = sender as ListBoxItem;
    
                if (draggedItem != null)
                {
                    DragDrop.DoDragDrop(draggedItem, draggedItem.Content, DragDropEffects.Copy);
                }
                
            }
           
    
            private void CvsSurface_OnDragEnter(object sender, DragEventArgs e)
            {
                if (e.Data.GetDataPresent(DataFormats.Text))
                {
                    e.Effects = DragDropEffects.Copy;
                }
                else
                {
                    e.Effects = DragDropEffects.None;
                }
    
            }
    
            private void CvsSurface_OnDrop(object sender, DragEventArgs e)
            {
                Object droppedData = e.Data; //This part is not important
    
            /*Translate Drop Point in reference to Stack Panel*/
                Point dropPoint = e.GetPosition(this.cvsSurface);
                
                Console.WriteLine(dropPoint); ;
                Label lbl = new Label();
                lbl.Content = draggedItem.Content;
                cvsSurface.Children.Add(lbl);
    
                Canvas.SetLeft(lbl, dropPoint.X);
                Canvas.SetTop(lbl, dropPoint.Y);
    
            }
    
    
            
        }
    }
