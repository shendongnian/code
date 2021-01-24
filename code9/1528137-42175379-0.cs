	dynamic obj = System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
	dynamic wb = obj.Workbooks(1);
	Object[,] x = wb.Worksheets(1).Range("A1:C2").Value;
	Console.WriteLine($"{x.GetLength(0)} x {x.GetLength(1)} items");
	Console.WriteLine($"A2 = {x[2,1]}");
