    public static void ReplaceFormulasWithValue()
    {
        try
	    {
		    CalculationChainPart calculationChainPart = _spreadSheet.WorkbookPart.CalculationChainPart;
		    CalculationChain calculationChain = calculationChainPart.CalculationChain;
		    var calculationCells = calculationChain.Elements<CalculationCell>().ToList();
		
		    foreach (Row row in _worksheetPart.Worksheet.GetFirstChild<SheetData>().Elements<Row>())
		    {
			    foreach (Cell cell in row.Elements<Cell>())
			    {
				    if (cell.CellFormula != null && cell.CellValue != null)
				    {
					    string cellRef = cell.CellReference;							
					    CalculationCell calculationCell = calculationCells.Where(c => c.CellReference == cellRef).FirstOrDefault();
					    UpdateCell(cell, DataTypes.String, cell.CellValue.InnerText);
							
					    cell.CellFormula.Remove();
					    if(calculationCell != null)
					    {						
						    calculationCell.Remove();
						    calculationCells.Remove(calculationCell);
					    }
					    else
					    {
						    //Something is went wrong - log it
					    }					
				    }
				    if (calculationCells.Count == 0)
                         _spreadSheet.WorkbookPart.DeletePart(calculationChainPart);
			    }
			    _worksheetPart.Worksheet.Save();
		    }
	    }
	    catch(Exception ex)
	    {
		    Console.WriteLine(ex);
	    }
    }
                    
