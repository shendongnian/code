            value = theCell.InnerText;
            if (theCell.DataType != null)
            {
                switch (theCell.DataType.Value)
                {
                    case CellValues.SharedString:
                        var stringTable = 
                            wbPart.GetPartsOfType<SharedStringTablePart>()
                            .FirstOrDefault();                        
                        if (stringTable != null)
                        {
                            value = 
                                stringTable.SharedStringTable
                                .ElementAt(int.Parse(value)).InnerText;
                        }
                        break;
                }
            }
