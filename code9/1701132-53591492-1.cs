        private static void QueryWithTwoJoins(string collectionLink)
        {
            // SQL
            var familiesChildrenAndPets = client.CreateDocumentQuery<dynamic>(collectionLink,
                "SELECT f.id as family, c.FirstName AS child, p.GivenName AS pet " +
                "FROM Families f " +
                "JOIN c IN f.Children " +
                "JOIN p IN c.Pets ");
            foreach (var item in familiesChildrenAndPets)
            {
                Console.WriteLine(item);
            }
            // LINQ
            familiesChildrenAndPets = client.CreateDocumentQuery<Family>(collectionLink)
                    .SelectMany(family => family.Children
                    .SelectMany(child => child.Pets
                    .Select(pet => new
                    {
                        family = family.Id,
                        child = child.FirstName,
                        pet = pet.GivenName
                    }
                    )));
            foreach (var item in familiesChildrenAndPets)
            {
                Console.WriteLine(item);
            }
        }
