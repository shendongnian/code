        try
            {
                st = File.Open("PlayerDetails.bin", FileMode.Open, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
    
                //try
                //{
                while (st.Position < st.Length && found == false)
                    {
                        pos = st.Position;
                        readPlayer = (Player)bf.Deserialize(st);
    
                        if (readPlayer.username.CompareTo(username)==0)
                        {
                            found = true;
                            readPlayer.password = password;
    
                            st.Seek(pos, SeekOrigin.Begin);
                            bf.Serialize(st, readPlayer);
    
                        }
                    } 
    finally {
    st.Close(); st.Dispose();
    }
