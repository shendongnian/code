    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    namespace YuGiOh_Card_List
    {
        public partial class frmAddLOB : Form
        {
            List<string> cardNo = new List<string>();
            List<string> cardName = new List<string>();
            List<string> cardRarity = new List<string>();
            List<string> cardType = new List<string>();
           List<string> Lines = new List<string>();
            
            public frmAddLOB()
            {
                InitializeComponent();
                StreamReader reader = File.OpenText("..\\Debug\\lobList.csv");
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Lines.Add(line);
                    cardNo.Add(values[0]);
                    cardName.Add(values[1]);
                    cardRarity.Add(values[2]);
                    cardType.Add(values[3]);
                    cboCardNo.Items.Add(values[0]);
                }
                reader.Close();
            }
            private void cboCardNo_SelectedIndexChanged(object sender, EventArgs e)
            {
                lblCardNoFinal.Text = cardNo[cboCardNo.SelectedIndex];
                lblCardNameFinal.Text = cardName[cboCardNo.SelectedIndex];
                lblCardRarityFinal.Text = cardRarity[cboCardNo.SelectedIndex];
                lblCardTypeFinal.Text = cardType[cboCardNo.SelectedIndex];
            }
            private void btnAdd_Click(object sender, EventArgs e)
            {
                string file = ("..\\Debug\\LOB.csv");
                string delimiter = ",";
                var card = new Card(lblCardNoFinal.Text, lblCardNameFinal.Text, lblCardRarityFinal.Text,
                    lblCardTypeFinal.Text);
                Global.card.Add(card);
                var newLine = card.CardNo + delimiter + card.CardName + delimiter + card.CardRarity + delimiter +
                              card.CardType;
                File.AppendAllLines(file,
                    new string [] {newLine});
                if (Lines.Contains(newLine))
                {
                    Lines.Remove(newLine);
                    File.WriteAllLines("..\\Debug\\lobList.csv", Lines);
                }
                MessageBox.Show("Card Added");
            }
        }
    }
