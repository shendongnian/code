    if (serialPort1.IsOpen)
            {
                int MyInt = Convert.ToInt32(textBox1.Text);
                byte[] b = BitConverter.GetBytes(MyInt);
                serialPort1.Write(b, 0, 1);
    
                int MyInt2 = Convert.ToInt32(textBox2.Text);
                byte[] z = BitConverter.GetBytes(MyInt2);
                serialPort1.Write(z, 0, 1);
    
                int MyInt3 = Convert.ToInt32(textBox3.Text);
                byte[] p = BitConverter.GetBytes(MyInt3);
                serialPort1.Write(p, 0, 1);
            }
            else
            {
                MessageBox.Show("Please control your connection");
            }
