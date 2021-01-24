    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            List<Player> data = new List<Player>();
            public Form1()
            {
                InitializeComponent();
                data.Add(new Player());
                data.Add(new Player());
                data.Add(new Player());
                cB_addEquipaJogador1.DataSource = data;
                cB_addEquipaJogador1.SelectedIndex = 0;
            }
            private void ComboBox_SelectionChanged(object sender, System.EventArgs e)
            {
                Player value = cB_addEquipaJogador1.SelectedItem as Player;
                List<Player> data2 = new List<Player>(data.Count);
                data.ForEach(item =>
                {
                    data2.Add(item);
                });
                data2.Remove(value);
                cB_addEquipaJogador2.DataSource = data2;
                cB_addEquipaJogador2.SelectedIndex = 0;
            }    
        }
        public class Player
        {
        }
    }
