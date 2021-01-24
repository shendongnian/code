    public List<Int64> lst2send;
    
            private void BtnProsthikiEggrafon_Click(object sender, EventArgs e)
            {
                lst2send = new List<Int64>();
                Int64 toSend;
                foreach (DataGridViewRow eggrafes in dataGridViewEggrafesProionParastikouEsodon.Rows)
                {
                    if (Convert.ToBoolean(eggrafes.Cells["CheckBoxColumn"].Value))
                    {
                        int RowIndexCheck = eggrafes.HeaderCell.RowIndex;             
                        Int64.TryParse(dataGridViewEggrafesProionParastikouEsodon.Rows[RowIndexCheck].Cells["proionParastatikouIDDataGridViewTextBoxColumn"].Value.ToString(),out toSend);
                        lst2send.Add(toSend);
                    }
                    
                }
                this.Close();
                
            }
