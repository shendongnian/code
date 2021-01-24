     delegate void UpdateStringinTheGrid(string s);
      private void ListAddItem(string s)
        {
            if (lst_show.InvokeRequired())
            {
                var updateDel = new UpdateStringinTheGrid(ListAddItem);
                this.BeginInvoke(updateDel, s);
            }
          else
            lst_show.Items.Add(s);
    private void ReceiveData()
            {
                int recv;
                string stringData;
                while (true)
                {
                    recv = client.Receive(data);
                    stringData = Encoding.ASCII.GetString(data, 0, recv);
                    if (stringData == "bye")
                        break;
                   listAddString(stringData);
                }
                stringData = "bye";
                byte[] message = Encoding.ASCII.GetBytes(stringData);
                client.Send(message);
                client.Close();
                lst_show.Items.Add("Connection stopped");
                return;
            }
