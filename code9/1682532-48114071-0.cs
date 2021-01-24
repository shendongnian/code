    public void ClientOnGetTemoignageCompleted(object sender, GetTemoignageCompletedEventArgs e)
            {
                
                foreach (Temoignage item in e.Result)
                {
                    TemoignagesList.Add(item);
                }
    
            }
