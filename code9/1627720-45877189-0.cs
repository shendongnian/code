    // SEGA GENESIS CODE
          // ROM NAME 2
                
                    BinaryReader br = new 
                    BinaryReader(File.OpenRead(OpenFileDialog1.FileName));
                    string romNameA = null;
                    for (int i = 0x120; i <= 0x144; i++)
                    {
                        br.BaseStream.Position = i;
                        romNameA += br.ReadByte().ToString("X2");
	                    textBox4.Text = romNameA;
                    }
                    br.Close();
