        public string GetBasketTotalPrice(string basketLocation)
        {
            var basketTotalPrice = _driver.FindElements(CommonPageElements.BasketTotalPrice);
            int index = GetElementIndexForBasketLocation(basketLocation);
            return basketTotalPrice[index].Text.Replace("£", "");          
        }
        
        private int GetElementIndexForBasketLocation(string basketLocation)
        {
            return basketLocation.ToLower() == "top" ? 0 : 1;
        }
