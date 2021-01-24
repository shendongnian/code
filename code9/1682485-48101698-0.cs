            private void button1_Click_1(object sender, EventArgs e)
            {
                string[] FileV = new string[3];
                FileV[0] = "val1";
                FileV[2] = "val2";
                FileV[3] = "val3";
                save(FileV);
            }
            private void save(string[] FileValue)
            {
                System.IO.Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        System.IO.StreamWriter tw = System.IO.File.AppendText(saveFileDialog1.FileName + ".ex1");
                        tw.WriteLine(FileValue[1]);
                        tw.Flush();
                        tw.Close();
                        tw = System.IO.File.AppendText(saveFileDialog1.FileName + ".ex2");
                        tw.WriteLine(FileValue[2]);
                        tw.Flush();
                        tw.Close();
                        tw = System.IO.File.AppendText(saveFileDialog1.FileName + ".ex3");
                        tw.WriteLine(FileValue[3]);
                        tw.Flush();
                        tw.Close();
                        myStream.Close();
                    }
                }
            }
