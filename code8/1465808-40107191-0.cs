    Random random = new Random();
    int[] lottery = Enumerable.Range(1, 49).OrderBy(i => r.Next()).Take(6).ToArray();
    lblLot1.Text = lottery[0].ToString();
    lblLot2.Text = lottery[1].ToString();
    lblLot3.Text = lottery[2].ToString();
    lblLot4.Text = lottery[3].ToString();
    lblLot5.Text = lottery[4].ToString();
    lblLot6.Text = lottery[5].ToString();
