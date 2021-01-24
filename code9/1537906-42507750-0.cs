    var mrls =
        from market in markets
        from ingredient in ingredientes
        from commodity in commodities
        let xpath = $"/MRLGroups/MRLGroup[{market.MarketId}]" +
            $"[ActiveIngredientID={ingredient.ActiveIngredientId}]" +
            $"[IndexCommodityID={commodity.IndexCommodityID}]/MRLs/MRL"
        select new {
            ms =
                (from a in doc.XPathSelectElements(xpath)
                select new xMRLIndividial {
                    publishedCommodityID = string.IsNullOrEmpty(a.Element("PublishedCommodityID").Value) ? "" : a.Element("PublishedCommodityID").Value,
                    publishedCommodityName = a.Element("PublishedCommodityName").Value,
                    mrlTypeId = a.Element("MRLTypeID").Value,
                    mrlTypeName = a.Element("MRLTypeName").Value,
                    deferredToMarketId = a.Element("DeferredToMarketID").Value,
                    deferredToMarketName = a.Element("DeferredToMarketName").Value,
                    undefinedCommodityLinkId = a.Element("UndefinedCommodityLinkInd").Value,
                    mrlValueInPPM = a.Element("MRLValueInPPM").Value,
                    residueDefinition = a.Element("ResidueDefinition").Value,
                    additionalRegulationNotes = a.Element("AdditionalRegulationNotes").Value,
                    expiryDate = a.Element("ExpiryDate").Value,
                    primaryInd = a.Element("PrimaryInd").Value,
                    exemptInd = a.Element("ExemptInd").Value
                }).ToList()
        };
