            XmlDocument doc = new XmlDocument();
            doc.LoadXml(@"<MenuInfo>
                                <Meal>
                                <MealID>1</MealID>
                                <Food>Meal 1 (Fish and Chips)</Food>
                                <Price>£4.99</Price>
                                <Time>25 minutes</Time>
                                <Quantity>12</Quantity>
                                </Meal>
                            </MenuInfo>");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/MenuInfo/Meal/Quantity");            
            int qty = Convert.ToInt32(node.InnerText);
             // Deducting 1 from orginal quantity, you can use variable instead of quantity 1
            node.InnerText = (qty - 1).ToString();
            //Finally you can retrieve modified xml from using doc.InnerXml
            string modifiedXml = doc.InnerXml
