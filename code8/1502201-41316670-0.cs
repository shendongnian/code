        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (ActiveControl.Name!="textBox20")
            {
                if (e.KeyCode == Keys.C)
                    button2_Click(sender, e);
                if (e.KeyCode == Keys.P)
                    button3_Click(sender, e);
                if (e.KeyCode == Keys.B)
                    button4_Click(sender, e);
                if (e.KeyCode == Keys.U)
                    button5_Click(sender, e);
                if (e.KeyCode == Keys.T)
                    button6_Click(sender, e);
                if (e.KeyCode == Keys.W)
                    button7_Click(sender, e);
                if (e.KeyCode == Keys.X)
                    button8_Click(sender, e);
            }
        }
