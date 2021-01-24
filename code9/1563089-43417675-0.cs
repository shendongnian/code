    private void textBox1_KeyDown(object sender, KeyEventArgs e)
                {
                    stopwatch1.Start();
                }
                private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
                {
                    e.Handled = true;
                    if (e.KeyChar == (char)Keys.W)
                    {
                        textBox1.Text = textBox1.Text + "W (" + stopwatch1.ElapsedMilliseconds + ") + ";
                    }
                    else if (e.KeyChar == (char)Keys.A)
                    {
                        textBox1.Text = textBox1.Text + "A (" + stopwatch1.ElapsedMilliseconds + ") + ";
                    }
                    else if (e.KeyChar == (char)Keys.S)
                    {
                        textBox1.Text = textBox1.Text + "S (" + stopwatch1.ElapsedMilliseconds + ") + ";
                    }
                    else if (e.KeyChar == (char)Keys.D)
                    {
                        textBox1.Text = textBox1.Text + "D (" + stopwatch1.ElapsedMilliseconds + ") + ";
                    }
                    stopwatch1.Stop();
                }
            }
        }
