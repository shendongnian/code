    private void levDGV_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
            {
                string dataPropertyName = levDGV.Columns[e.ColumnIndex].DataPropertyName;
                if (dataPropertyName.Equals("deliveryProcent"))
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            string testValueStr = e.Value.ToString();
                            char lastChar = testValueStr[testValueStr.Length - 1];
                            if (lastChar == (char)37)
                            {
                                //Remove % character from entered string
                                testValueStr = testValueStr.Substring(0, testValueStr.Length - 1);
                            }
                            //divide the value by 100 and set as currentCell value
                            double testValue = (Convert.ToDouble(testValueStr)) / 100;
                            e.Value = testValue;
                            e.ParsingApplied = true;
                        }
                        catch (FormatException)
                        {
                            // Set to false in case another CellParsing handler
                            // wants to try to parse this DataGridViewCellParsingEventArgs instance.
                            e.ParsingApplied = false;
                        }
                    }
                        
                }
            }
