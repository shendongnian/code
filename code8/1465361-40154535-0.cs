            var clrTypeNamespace = @"http://schemas.microsoft.com/ado/2013/11/edm/customannotation:ClrType";
            var firstEdmType = set.AssociationSetEnds[0]?.EntitySet?.ElementType;
            var secondEdmType = set.AssociationSetEnds[1]?.EntitySet?.ElementType;
            var firstType = firstEdmType?.MetadataProperties.SingleOrDefault(p => p.Name == clrTypeNamespace)?.Value as Type;
            var secondType = secondEdmType?.MetadataProperties.SingleOrDefault(p => p.Name == clrTypeNamespace)?.Value as Type; 
