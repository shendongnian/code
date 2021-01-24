    public void cceceec()
            {
                if (listView1.Items.Count > 0)
                {
                    
                    for (int e = 0; e < listView2.Items.Count; e++)
                    {
                        for (int w = 0; w < listView1.Items.Count; w++)
                        {
                            if (listView2.Items[e].SubItems[0].Text == listView1.Items[w].SubItems[2].Text)
                            {
                                if (listView1.Items[w].SubItems[7].Text == "Finished")
                                {
                                    fcounter[e] = fcounter[e] + 1;
                                    for (int dd = 0; dd < dataGridView1.Rows.Count; dd++)
                                    {
                                        if (listView2.Items[e].SubItems[0].Text == dataGridView1.Rows[dd].Cells[0].Value.ToString())
                                        {
                                            MessageBox.Show(fcounter[0].ToString());
                                            if (fcounter[e] == Int32.Parse(dataGridView1.Rows[dd].Cells[2].Value.ToString()))
                                            {
                                                listView2.Items[e].SubItems[1].Text = "Complete";
                                            }
                                        }
                                    }
                                }
                            }
                        }
    
                    }
                }
            }
            private void timer2_Tick(object sender, EventArgs e)
            {
                
                servings();
                label3.Text = string.Format("{0:h:mm:ss tt}", DateTime.Now);
               
                if(dataGridView1.Rows.Count > 0)
                {
                    for (int lst = 0; lst < listView2.Items.Count; lst++)
                    {
                        
                        for (int dgv = 0; dgv < dataGridView1.Rows.Count; dgv++)
                        {
                            if (listView2.Items[lst].SubItems[0].Text == dataGridView1.Rows[dgv].Cells[0].Value.ToString())
                            {
                                //serv checking
                                if (dataGridView1.Rows[dgv].Cells[1].Value.ToString() == "blanked")
                                {
                                    continue;
                                }
                                else if (dataGridView1.Rows[dgv].Cells[1].Value.ToString() == "noblanked")
                                {
                                    cceceec();
                                } 
                            }
                        }
                    }
                }`
