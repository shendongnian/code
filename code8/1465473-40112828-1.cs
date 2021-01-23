    using System.Linq;
    using System.Windows;
    
    namespace WpfStackOverflow
    {
        /// <summary>
        /// Interaction logic for Window6.xaml
        /// </summary>
        public partial class Window6 : Window
        {
            public Window6()
            {
                InitializeComponent();
    
                this.DataContext = new[] { new { Age = 32, Name = "Name1", Height = 6 }, new { Age = 34, Name = "Name1", Height = 6 }, new { Age = 34, Name = "Name1", Height = 6 }, new { Age = 32, Name = "Name1", Height = 6 }, new { Age = 32, Name = "Name1", Height = 6 }, new { Age = 39, Name = "Name1", Height = 6 }, new { Age = 40, Name = "Name1", Height = 6 } }.ToList();
            }
        }
    }
