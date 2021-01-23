            if (color.ShowDialog() == DialogResult.OK)
            {
                while(color.Color == Color.Black)
                {
                    MessageBox.Show("Color cannot be black", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    color.ShowDialog();
                }
                BackColor = color.Color;
                backColor = color.Color;
            }
