    var country = Twilio.Rest.Pricing.V1.PhoneNumber.CountryResource.Fetch("US");
    var prices = country.PhoneNumberPrices;
    foreach(var price in prices) 
    {
        Console.Writeline(price.NumberType.ToString());
    }
