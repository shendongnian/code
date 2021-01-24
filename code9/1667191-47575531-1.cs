    // Dimension field
                    MyRow++;
                    MyCol = 0;
                    QueryOutputWS.ActiveWorksheet.Cells[MyRow, MyCol].Value = nameof(product.dimension) + ":";
                    // aquameth
                    MyRow++;
                    MyCol = 0;
                    QueryOutputWS.ActiveWorksheet.Cells[MyRow, MyCol].Value = nameof(product.dimension.aquameth) + ":";
                    // label
                    MyRow++;
                    MyCol = 0;
                    QueryOutputWS.ActiveWorksheet.Cells[MyRow, MyCol].Value = nameof(product.dimension.aquameth.label) + ":";
                    MyCol = 1;
                    QueryOutputWS.ActiveWorksheet.Cells[MyRow, MyCol].Value = product.dimension.aquameth.label;
                    // category
                    MyRow++;
                    MyCol = 0;
                    QueryOutputWS.ActiveWorksheet.Cells[MyRow, MyCol].Value = nameof(product.dimension.aquameth.category) + ":";
                    // category index
                    MyRow++;
                    MyCol = 0;
                    QueryOutputWS.ActiveWorksheet.Cells[MyRow, MyCol].Value = nameof(product.dimension.aquameth.category.index) + ":";
                    // CAG
                    foreach (string key in product.dimension.aquameth.category.index.Keys)
                    {
                        MyRow++;
                        MyCol = 0;
                        dynamic myvalue = key;
                        QueryOutputWS.ActiveWorksheet.Cells[MyRow, MyCol].Value = myvalue + ":";
                        MyCol = 1;
                        myvalue = product.dimension.aquameth.category.index[key];
                        QueryOutputWS.ActiveWorksheet.Cells[MyRow, MyCol].Value = myvalue;
                    }
                    MyRow++;
                    MyCol = 0;
                    QueryOutputWS.ActiveWorksheet.Cells[MyRow, MyCol].Value = nameof(product.dimension.aquameth.category.label) + ":";
                    // CAG
                    foreach (string key in product.dimension.aquameth.category.label.Keys)
                    {
                        MyRow++;
                        MyCol = 0;
                        dynamic myvalue = key;
                        QueryOutputWS.ActiveWorksheet.Cells[MyRow, MyCol].Value = myvalue + ":";
                        MyCol = 1;
                        myvalue = product.dimension.aquameth.category.label[key];
                        QueryOutputWS.ActiveWorksheet.Cells[MyRow, MyCol].Value = myvalue;
                    }
