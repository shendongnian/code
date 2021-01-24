	System.IO.StreamReader reader = new System.IO.StreamReader(this.Variables.varFileName);
				string H1;
				string H2;
				string H3;
				string H4;
				string H5;
				string H6;
				string H7;
				string H8;
				string H9;
				string H10;
				string H11;
				string H12;
				string H13;
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				string[] items = line.Split('|');
				// HEADER = 000
				
				if (items[0] == "000")
				{
					
					H1 = items[0];
					H2 = items[1];
					H3 = items[2];
					H4 = items[3];
					H5 = items[4];
					H6 = items[5];
					H7 = items[6];
					H8 = items[7];
					H9 = items[8];
					H10 = items[9];
					H11 = items[10];
					H12 = items[11];
					H13 = items[12];
				}
				// DETAIL = 001
				else if (items[0] == "001")
				{
					DetailBuffer.AddRow();
					DetailBuffer.D1 = items[0];
					DetailBuffer.D2 = items[1];
					DetailBuffer.D3 = items[2];
					DetailBuffer.D4 = items[3];
					DetailBuffer.D5 = items[4];
					DetailBuffer.D6 = items[5];
					DetailBuffer.H1 = H1;
					DetailBuffer.H2 = H1;
					DetailBuffer.H3 = H2;
					DetailBuffer.H4 = H3;
					DetailBuffer.H5 = H4;
					DetailBuffer.H6 = H5;
					DetailBuffer.H7 = H6;
					DetailBuffer.H8 = H7;
					DetailBuffer.H9 = H8;
					DetailBuffer.H10 = H9;
					DetailBuffer.H11 = H10;
					DetailBuffer.H12 = H11;
					DetailBuffer.H13 = H12;				
					
									
				}
			}
