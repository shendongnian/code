    using System.Collections.Generic;
    using System.Linq;
    
    namespace FilterExampleWPF
    {
        public partial class MainWindow : System.Windows.Window
        {
            List<Animal> _animals;
    
            public MainWindow()
            {
                InitializeComponent();
                _animals = new List<Animal>();
                _animals.Add(new Animal { Type = "cat", Name = "Snowy" });
                _animals.Add(new Animal { Type = "cat", Name = "Toto" });
                _animals.Add(new Animal { Type = "dog", Name = "Oscar" });
                dataGrid1.ItemsSource = _animals;
            }
    
            private void textBox1_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
            {
                var filtered = _animals.Where(animal => animal.Type.StartsWith(textBox1.Text));
    
                dataGrid1.ItemsSource = filtered;            
            }
        }
    
        public class Animal
        {
            public string Type { get; set; }
            public string Name { get; set; }
        }
    }
