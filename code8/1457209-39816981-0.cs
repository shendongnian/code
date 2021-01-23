    var ozellik = veri.entegrekat;
                        Dictionary<string, dynamic> result = ozellik.ToObject<Dictionary<string, dynamic>>();
    
                        foreach (KeyValuePair<string, dynamic> kat in result)
                        {
                            
                            MessageBox.Show(""+kat.Key);
                        
                        }
