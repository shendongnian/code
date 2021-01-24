            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb web = new HtmlWeb();
            //string InitialUrl = "https://www.hudhomestore.com/Home/Index.aspx";
            //Here you need to set the values of these variable to whatever user inputs
            //after setting these values, add them to initial URL
            string zipCode = "", city = "", county = "", street = "", sState = "AK", fromPrice = "0", toPrice = "0", fcaseNumber = "",
                   bed = "0", bath = "0", buyerType = "0", Status = "0", indoorAmenities = "", outdoorAmenities = "", housingType = "",
                   stories = "", parking = "", propertyAge = "", sLanguage = "ENGLISH";
            HtmlAgilityPack.HtmlDocument document = web.Load("https://www.hudhomestore.com/Listing/PropertySearchResult.aspx?" +
                "zipCode=" + zipCode + "&city=" + city + "&country=" + county + "&street=" + street + "&sState=" + sState + 
                "&fromPrice=" + fromPrice + "&toPrice=" + toPrice +
                "&fcaseNumber=" + fcaseNumber + "&bed=" + bed + "&bath=" + bath + 
                "&buyerType=" + buyerType + "&Status=" + Status + "&indoorAmenities=" + indoorAmenities + 
                "&outdoorAmenities=" +outdoorAmenities + "&housingType=" + housingType + "&stories=" + stories + 
                "&parking=" + parking + "&propertyAge=" + propertyAge + "&sLanguage=" + sLanguage);
            HtmlNodeCollection tdNodeCollection = document
                                     .DocumentNode
                                     .SelectNodes("//*[@id=\"dgPropertyList\"]//tr//td");
