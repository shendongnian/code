                    combinedCount = 0;
                    counter = 0;
                    int testCount = 2;
                    foreach (DataRowView drv in view)
                       {
                            if (combinedCount != 0)//if its the first one, there is nothing to compare it to
                            {
                                if (combinedList[combinedCount - 1][0] == combinedList[combinedCount][0])//look at the previous one to check if its the same as the one before it, because we dont want to increment it everytime else it will increment on a different and empty page
                                {
                                    testCount++;
                                }
                                else
                                {
                                    testCount = 2; //2 is where our first row starts on each page
                                }
                            }
                            else { }
                               Aspose.Cells.Worksheet sheet = wb.Worksheets[combinedList[combinedCount][0]];
                               Aspose.Cells.Cell cell1 = sheet.Cells["A" + testCount];
                               Aspose.Cells.Cell cell2 = sheet.Cells["B" + testCount];
                               Aspose.Cells.Cell cell3 = sheet.Cells["C" + testCount];
                               Aspose.Cells.Cell cell4 = sheet.Cells["D" + testCount];
                               Aspose.Cells.Cell cell5 = sheet.Cells["E" + testCount];
                               Aspose.Cells.Cell cell6 = sheet.Cells["F" + testCount];
                               Aspose.Cells.Cell cell7 = sheet.Cells["G" + testCount];
                               Aspose.Cells.Cell cell14 = sheet.Cells["N" + testCount];
                               Aspose.Cells.Cell cell15 = sheet.Cells["O" + testCount];
                               Aspose.Cells.Cell cell16= sheet.Cells["P" + testCount];
                               Aspose.Cells.Cell cell17 = sheet.Cells["Q" + testCount];
                               Aspose.Cells.Cell cell18 = sheet.Cells["R" + testCount];
                               Aspose.Cells.Cell cell19 = sheet.Cells["S" + testCount];
                               Aspose.Cells.Cell cell20 = sheet.Cells["T" + testCount];
    
                               cell1.PutValue(drv[0]);
                               cell2.PutValue(drv[1]);
                               cell3.PutValue(drv[13]);
                               cell4.PutValue(drv[2]);
                               cell5.PutValue(drv[10]);
                               cell6.PutValue(drv[11]);
                               cell7.PutValue(drv[12]);
                               cell14.PutValue(drv[3]);
                               cell15.PutValue(drv[4]);
                               cell16.PutValue(drv[5]);
                               cell17.PutValue(drv[6]);
                               cell18.PutValue(drv[7]);
                               cell19.PutValue(drv[8]);
                               cell20.PutValue(drv[9]);  
                               
    }
