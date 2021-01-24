        public ActionResult DownloadExcel(EntityReportModel erModel, string filename)
        {
            var dataResponse = iEntityViewService.LoadEntityView(new EntityViewInput
            {
                SecurityContext = SessionCache.Instance.SecurityContext,
                EntityViewName = "Ticket",
                Parameters = new Dictionary<string, object> {
                    {"MinTicketDateTime", "04/26/16"}
                }
            });
            var table = dataResponse.DataSet.Tables[0];
            filename = "TICKETS-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            using (ExcelPackage pack = new ExcelPackage())
            {
                ExcelWorksheet ws = pack.Workbook.Worksheets.Add(filename);
                //Add second sheet to put Validations into
                ExcelWorksheet productVal = pack.Workbook.Worksheets.Add("ProductValidations");
                // Hide Validation Sheet
                productVal.Hidden = OfficeOpenXml.eWorkSheetHidden.Hidden;
                // Load the data from the datatable 
                ws.Cells["A1"].LoadFromDataTable(table, true);
                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                int columnCount = table.Columns.Count;
                int rowCount = table.Rows.Count;
                // Format Worksheet// 
                ws.Row(1).Style.Font.Bold = true;
                List<string> deleteColumns = new List<string>() {
                    "CurrentTicketId",
                    };
                List<string> dateColumns = new List<string>() {
                    "TicketDateTime",
                    "Updated",
                    "InvoiceDate"
                    };
                ExcelRange r;
                // Format Dates
                for (int i = 1; i <= columnCount; i++)
                {
                    // if cell header value matches a date column
                    if (dateColumns.Contains(ws.Cells[1, i].Value.ToString()))
                    {
                        r = ws.Cells[2, i, rowCount + 1, i];
                        r.AutoFitColumns();
                        r.Style.Numberformat.Format = @"mm/dd/yyyy hh:mm";
                    }
                }
                  // Delete Columns
                for (int i = 1; i <= columnCount; i++)
                {
                    // if cell header value matches a delete column
                    if ((ws.Cells[1, i].Value != null) && deleteColumns.Contains(ws.Cells[1, i].Value.ToString()))
                    {
                        ws.DeleteColumn(i);
                    }
                }
                int col = 0;
                int Prow = 0;
                int valRow = 1;
                // Data Validations //
                // Iterate over the Rows and insert Validations
                for (int i = 2; i-2 < rowCount; i++)
                {
                    Prow = 0;
                    col++;
                    valRow++;
                    // Add Validations At this row in column 7 //
                    var ProdVal = ws.DataValidations.AddListValidation(ws.Cells[valRow, 7].Address);
                    ProdVal.ShowErrorMessage = true;
                    ProdVal.ErrorTitle = "Entry was invalid.";
                    ProdVal.Error = "Please choose options from the drop down only.";
                    var ticketEntity = ticketQueryable.Where(o => o.TTSTicketNumber == ws.Cells[i, 3].Value.ToString()).Single<CustCurrentTicketEntity>();
                    // Product Validation // 
                    var prodIds = prodExtQueryable.Where(p => p.ZoneId == ticketEntity.ZoneId && p.TicketTypeId == ticketEntity.TicketTypeId);
                    if (ticketEntity != null)
                    {
                        var prodIdsList = new List<int>();
                        foreach (var prodId in prodIds)
                        {
                            prodIdsList.Add(prodId.ProductId);
                        }
                        var ProductList = ProductCache.Instance.AllProducts.Where(p => prodIdsList.Contains(p.ProductId)).Select(p => new SelectListItem() { Value = p.ProductId.ToString(), Text = p.Name });
                        //For Each Item in the list move the row forward and add that value to the Validation Sheet
                        foreach (var Result in ProductList)
                        {
                            Prow++;
                            var product = Result.Text;
                                productVal.Cells[Prow, col].Value = product;
                        }
                        // convert column name from a number to the Excel Letters i.e A, AC, BCE//
                        int dividend = col;
                        string columnName = String.Empty;
                        int modulo;
                        while (dividend > 0)
                        {
                            modulo = (dividend - 1) % 26;
                            columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                            dividend = (int)((dividend - modulo) / 26);
                        }
                        // Pass back to sheeet as an Excel Formula to get around the 255 Char limit for Validations// 
                        string productValidationExcelFormula = "ProductValidations!" + columnName + "1:" + columnName + Prow;
                        ProdVal.Formula.ExcelFormula = productValidationExcelFormula;
                    }
                }
                // Save File //
                var fileStream = new MemoryStream(pack.GetAsByteArray());
                string handle = Guid.NewGuid().ToString();
                fileStream.Position = 0;
                TempData[handle] = fileStream.ToArray();
                // Note we are returning a filename as well as the handle
                return new JsonResult()
                {
                    Data = new { FileGuid = handle, FileName = filename }
                };
            }
        }
        [HttpGet]
                public virtual ActionResult Download(string fileGuid, string fileName)
                {
                    if (TempData[fileGuid] != null)
                    {
                        byte[] data = TempData[fileGuid] as byte[];
                        return File(data, "application/vnd.ms-excel", fileName);
                    }
                    else
                    {
                    //Log err
                        return new EmptyResult();
                    }
                }        
