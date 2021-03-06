    public static decimal GetCartTotal(HttpSessionState session)
    {
      decimal cartTotal = 0;
      var storedData = session.GetString(ShoppingCartTotal);
      if (storedData != null)
      {
        cartTotal = JsonConvert.DeserializeObject<decimal>(storedData);
      }
      return cartTotal;
    }
