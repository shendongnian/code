	    for (int j = 2; j <= colCount; j++)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    string line = string.Empty;
                    //Used for loop for number of columns.
                    for (int i = 4; i <= rowCount; i++)
                    {
                        //Prepared final xpath of specific cell as per values of i and j.
                        String finalXpath = firstPart + i + secondPart + j + thirdPart;
                        //Will retrieve value from located cell and print It.
                        String tableData = driver.FindElement(By.XPath(finalXpath)).Text;
                        line = line + string.Format("{0},",tableData);
                    }
                    sw.WriteLine(line);
                }
            }	
