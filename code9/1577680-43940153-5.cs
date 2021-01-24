    using System.Collections.Generic;
    using System.Windows.Forms;
        
    namespace WindowsFormsApplication1
    {
        public partial class AdicionarEquipa_Admin : Form
        {
            private DiagramaEntidadesContainer dbATMT;
            public AdicionarEquipa_Admin()
            {
                InitializeComponent();
                dbATMT = new DiagramaEntidadesContainer();
            
                //Needs improvement :/
                cB_addEquipaJogador1.DataSource = (from player in dbATMT.PlayerSet select player).ToList<Player>();
                cB_addEquipaJogador1.SelectedIndex = 0;
            }
            private void PreencherListas()
            {
                //Needs improvement :/
                List<Player> jogadores = (from player in dbATMT.PlayerSet
                                      select player).ToList<Player>();
                Player value = cB_addEquipaJogador1.SelectedItem as Player;
                List<Player> jogadores2  = new List<Player>(jogadores.Count);
                jogadores.ForEach(item =>
                {
                    jogadores2.Add(item);
                });
                jogadores2.Remove(value);
                cB_addEquipaJogador2.DataSource = jogadores2;
                cB_addEquipaJogador2.SelectedIndex = 0;
            }
            private void cB_addEquipaJogador1_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                PreencherListas();
            }
        }
        public class Player
        {
        }
    }
