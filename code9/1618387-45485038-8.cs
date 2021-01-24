            object [,] columnHeaders = new object[3,0]; // or object[0,3]; if you'd like to add into 1 column
            columnHeaders[0, 0] = "Variable1";
            columnHeaders[1, 0] = "Variable2";
            columnHeaders[2, 0] = "Variable3";
            columnHeaders[3, 0] = "Variable4";
            xlRng.FormulaR1C1 = columnHeaders; // xlRng would be in the above Sheet2!R2C2:$R5C2
