    System.IO.StreamReader reader = new System.IO.StreamReader(this.Variables.varFileName);
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            **string Hkey; //Make this whatever the key is**
            string[] items = line.Split('|');
            // HEADER = 000
            if (items[0] == "000")
            {
                HeaderBuffer.AddRow();
                HeaderBuffer.H1 = items[0];
                HeaderBuffer.H2 = items[1];
                HeaderBuffer.H3 = items[2];
                HeaderBuffer.H4 = items[3];
                HeaderBuffer.H5 = items[4];
                HeaderBuffer.H6 = items[5];
                HeaderBuffer.H7 = items[6];
                HeaderBuffer.H8 = items[7];
                HeaderBuffer.H9 = items[8];
                HeaderBuffer.H10 = items[9];
                HeaderBuffer.H11 = items[10];
                HeaderBuffer.H12 = items[11];
                HeaderBuffer.H13 = items[12];
                **Hkey = items[keynode]**
            }
            // DETAIL = 001
            else if (items[0] == "001")
            {
                DetailBuffer.AddRow();
                **DetailBuffer.Hkey = Hkey;**
                DetailBuffer.D1 = items[0];
                DetailBuffer.D2 = items[1];
                DetailBuffer.D3 = items[2];
                DetailBuffer.D4 = items[3];
                DetailBuffer.D5 = items[4];
                DetailBuffer.D6 = items[5];
            }
        }
