    XNamespace ns = "http://www.juniper.es/webservice/2007/";
    var hotels = (from hotelData in data.Root.Descendants(ns + "HotelResult")
                  select new
                  {
                      Code = (string)hotelData.Attribute("Code"),
                      JpCode = (string)hotelData.Attribute("JPCode"),
                      DestinationZone = (string)hotelData.Attribute("DestinationZone"),
                      JpdCode = (string)hotelData.Attribute("JPDCode"),
                      HotelInfo = (from hi in hotelData.Descendants(ns + "HotelInfo")
                                   select new
                                   {
                                       Name = (string)hi.Element("Name"),
                                       Description = (string)hi.Element(ns + "Description"),
                                       Image = (from img in hi.Descendants(ns + "Images")
                                                select new
                                                {
                                                    Images = (string)img.Element(ns + "Image")
                                                }).ToList(),
                                       HotelCategory = (string)hi.Element(ns + "Name"),
                                       HotelType = (string)hi.Element(ns + "Description"),
                                       Address = (string)hi.Element(ns + "Description"),
                                   }).ToList(),
                      HotelOptions = (from ho in hotelData.Descendants(ns + "HotelOption")
                                      select new
                                      {
                                          HotelOption = ho.Attribute("RatePlanCode").Value,
                                          Board = ho.Element(ns + "Board").Attribute("Type").Value,
                                          Prices = (from pr in ho.Descendants(ns + "Prices")
                                                    select new
                                                    {
                                                        Price = (string)pr.Element(ns + "Price"),
                                                        TotalFixAmounts = (from tfa in pr.Descendants(ns + "Price").Descendants(ns + "TotalFixAmounts")
                                                                           select new
                                                                           {
                                                                               Service = tfa.Element(ns + "Service").Attribute("Amount").Value,
                                                                               ServiceTaxes = tfa.Element(ns + "ServiceTaxes").Attribute("Included").Value,
                                                                               AmountServiceTaxes = tfa.Element(ns + "ServiceTaxes").Attribute("Amount").Value,
                                                                               Commissions = tfa.Element(ns + "Commissions").Attribute("Included").Value,
                                                                               AmountCommissions = tfa.Element(ns + "Commissions").Attribute("Amount").Value,
                                                                               HandlingFees = tfa.Element(ns + "HandlingFees").Attribute("Included").Value,
                                                                               AmountHandlingFees = tfa.Element(ns + "HandlingFees").Attribute("Amount").Value
                                                                           }).ToList(),
                                                    }).ToList(),
                                      }).ToList(),
                  }).ToList();
