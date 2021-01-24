     var groceries = xDoc.Descendants("Group").Where(d => d.Attributes("Name").FirstOrDefault().Value == "Groceries");
            foreach (var grocery in groceries)
            {
                var lifeTimeNode = grocery.Elements().FirstOrDefault(e => e.Name.LocalName == "Lifetime");
                var creationYear = int.Parse(lifeTimeNode.Attribute("Creation").Value);
                var expirationYear = int.Parse(lifeTimeNode.Attribute("Expiration").Value);
                var vegetableLifeTimes = grocery.Elements().Where(e => e.Name.LocalName != "Lifetime").Select(e => e.Descendants().FirstOrDefault(subE => subE.Name.LocalName == "LifeTime"));
                foreach (var vegLifeTime in vegetableLifeTimes)
                {
                    var vegCreationModifier = int.Parse(vegLifeTime.Attribute("Creation").Value);
                    var vegExpirationModifier = int.Parse(vegLifeTime.Attribute("Expiration").Value);
                    var newExpiration = expirationYear + vegExpirationModifier;
                    var newCreation = creationYear + vegCreationModifier;
                    vegLifeTime.Attribute("Creation").Value = newCreation.ToString();
                    vegLifeTime.Attribute("Expiration").Value = newExpiration.ToString();
                }
            }
