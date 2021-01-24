    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            List<Player> jogadores = new List<Player>();
            public MainWindow()
            {
                InitializeComponent();
                jogadores.Add(new Player());
                jogadores.Add(new Player());
            }
            private void ComboBox_Loaded(object sender, RoutedEventArgs e)
            {
                cB_addEquipaJogador1.ItemsSource = jogadores;
                cB_addEquipaJogador1.SelectedIndex = 0;
            } 
            private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                Player jogadorSelecionado = cB_addEquipaJogador1.SelectedItem as Player;
                List<Player> jogadores2 = new List<Player>(jogadores.Count);
                jogadores.ForEach(item =>
                {
                    jogadores2.Add(item);
                });
                jogadores2.Remove(jogadorSelecionado);
                cB_addEquipaJogador2.ItemsSource = jogadores2;
                cB_addEquipaJogador2.SelectedIndex = 0;
            }
        }
        public class Player
        {
        }
    }
