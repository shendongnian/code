     // Create a buy button for every type of good that can be bought.
     for (int g = 0; g < SGoods.Instance.goodsList.Count - 1; g++)
             {
                 // Get the text input for how much the player wants to buy.
                 GameObject buyQuantity = MenuElements.InitField(transform,
                     new Vector3(205.0f, -40.0f));
     
                 // Call the Button initialiser.
                 GameObject buyButton = MenuElements.TestInitButton(transform,
                     new Vector3(205.0f, -60.0f - 30.0f * g),
                     "Buy",
                     market.BuyFrom,
                     SGoods.Instance.goodsList[g],
                     buyQuantity.GetComponent<InputField>());
             }
