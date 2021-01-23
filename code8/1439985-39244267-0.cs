    public void Handle(AddItemToBasketCommand command)
    {
        var product = this.productRepository.Get(command.ProductId);
        var person = this.personRepository.Get(this.userContext.UserId);
        if (product.IsAdultProduct && person.GetAge(this.ageCalculator) < 18) {
            throw new ValidationException("You must be 18 to order this item.");
        }
        var basket = this.basketService.GetUserBasket();
        basket.AddItemToBasket(command.ProductId, command.Quantity);
    }
