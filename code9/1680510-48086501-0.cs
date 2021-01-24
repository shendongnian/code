            var hyperLinkCollection = worksheetPart.Worksheet.Descendants<Hyperlinks>().First();
            if (hyperLinkCollection.Any())
            {
                var hyperLinks = hyperLinkCollection.Descendants<Hyperlink>();
                foreach (var hyperLink in hyperLinks)
                {
                    worksheetPart.DeleteReferenceRelationship(hyperLink.Id);
                    //remove cell style using hyperLink.Reference
                }
                hyperLinkCollection.Remove();
                worksheetPart.Worksheet.Save();
            }
