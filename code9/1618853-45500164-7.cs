    using System;
    using System.Collections.Generic;
    using System.Windows;
    
    namespace WpfApplication2
    {
    public partial class MainWindow : Window
    {
        public IEnumerable<Control> List { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            var l = new List<Control>();
            l.Add(new ControlText() { Text = "Michael", Label = "Name" });
            l.Add(new ControlBool() { Value = true, Label = "C#" });
            l.Add(new ControlBool() { Value = false, Label = "WPF" });
            l.Add(new ControlText() { Text = "Martinez", Label= "Surname" });
            List = l;
        }
    }
    public abstract class Control
    {
        public String Label { get; set; }
    }
    public class ControlText : Control
    {
        public String Text { get; set; }
    }
    public class ControlBool : Control
    {
        public Boolean Value { get; set; }
    }
    }
