	private void btnAdd_Click(object sender, EventArgs e)
	{
	    string file = ("..\\Debug\\LOB.csv");
	    string delimiter = ",";
	
		var card = new Card(lblCardNoFinal.Text, lblCardNameFinal.Text, lblCardRarityFinal.Text, lblCardTypeFinal.Text)
		Global.card.Add(card);
	    File.AppendAllLines(file, new[] {card.CardNo + delimiter + card.CardName + delimiter + card.CardRarity + delimiter + card.CardType});
	
	    MessageBox.Show("Card Added");
	}
