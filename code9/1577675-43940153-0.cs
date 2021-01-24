    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            List<Player> data = new List<Player>();
            public MainWindow()
            {
                InitializeComponent();
                data.Add(new Player());
                data.Add(new Player());
            }
            private void ComboBox_Loaded(object sender, RoutedEventArgs e)
            {
                cB_addEquipaJogador1.ItemsSource = data;
                cB_addEquipaJogador1.SelectedIndex = 0;
            } 
            private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                Player value = cB_addEquipaJogador1.SelectedItem as Player;
                List<Player> data2 = new List<Player>(data.Count);
                data.ForEach(item =>
                {
                    data2.Add(item);
                });
                data2.Remove(value);
                cB_addEquipaJogador2.ItemsSource = data2;
                cB_addEquipaJogador2.SelectedIndex = 0;
            }
        }
        public class Player
        {
        }
    }
