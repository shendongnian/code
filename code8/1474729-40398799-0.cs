    XNamespace order = "urn:oasis:names:specification:ubl:schema:xsd:Order-2";
    XNamespace cbc = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";
    XNamespace cac = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2";
    var doc = XDocument.Load(stream);
    var id = (string) doc.Elements(order + "Order")
        .Elements(cbc + "ID")
        .Single();
    var issueDate = (DateTime) doc.Elements(order + "Order")
        .Elements(cbc + "IssueDate")
        .Single();
    var buyerPartySchemeId = (string) doc.Descendants(cac + "BuyerCustomerParty")
        .Descendants(cbc + "ID")
        .Attributes("schemeID")
        .Single();
