                private static void mytest()
                {
                    ExcelUtil util = new ExcelUtil();
                    ExcelUtil.PopulateInCollection(@"c:\datalocation\Data.xlsx");
                    string itemNo = ExcelUtil.ReadData(1, "Item");
                }
