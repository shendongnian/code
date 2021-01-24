    private void NewMessage(object sender, MessageEventArgs e)
    {
        this.BeginInvoke((Action)(() => DataHolder.TableSource.Add(new 
          CustomData(e.Name, e.Surname, 
          e.Whatever, e.WhoTheHellCares))));
    }
