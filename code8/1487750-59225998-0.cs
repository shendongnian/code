    var elementName = "Dancing";
    var xmlDoc = new XmlDocument();
    xmlDoc.LoadXml(@"<?xml version='1.0' encoding='utf-8'?>
    <Collection>
      <Elements>
        <Element>
          <name>Cooking</name>
          <Calories>100</Calories>
        </Element>
        <Element>
          <name>Dancing</name>
          <Calories>0</Calories>
        </Element>
        <Element>
          <name>Walking</name>
          <Calories>0</Calories>
        </Element>
      </Elements>
    </Collection>");
    // be careful: xml is case-sensitive!
    // maybe you want to change the "name" element to "Name" to be using the same casing convention
    var calories = xmlDoc.SelectSingleNode($"/Collection/Elements/Element[name='{elementName}']/Calories");
    if (calories != null)
        calories.InnerText = "X";
    xmlDoc.Save(Console.Out);
