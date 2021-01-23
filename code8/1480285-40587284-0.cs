    var cardList = new List<CardTextModel>(){
		new CardTextModel{ 
			prod_Code = "G01Q0320WS",
			page1Text = "SHORTY SET SZ 10",
			insideText = "SHORTY SET SZ 10",
			userName = "daz",
			exportDate = null
		},
		new CardTextModel{ 
			prod_Code = "G01Q0380",
			page1Text = "TREE DECS SET 4 RESIN",
			insideText = "TREE DECS SET 4 RESIN",
			userName = "mark",
			exportDate = null
		},
	};
	string output = JsonConvert.SerializeObject(cardList);
