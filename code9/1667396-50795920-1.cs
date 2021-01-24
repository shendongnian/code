    using (var workBook = new XLWorkbook())
                {
                    var workSheet = workBook.Worksheets.Add("Guests");
    
                    var guestTable = new DataTable();
                    guestTable.Columns.Add(Resources.Strings.FirstName, typeof(string));
                    guestTable.Columns.Add(Resources.Strings.LastName, typeof(string));
                    guestTable.Columns.Add(Resources.Strings.TicketName, typeof(string));
                    guestTable.Columns.Add(Resources.Strings.TicketType, typeof(string));
                    guestTable.Columns.Add(Resources.Strings.ShortCode, typeof(string));
                    guestTable.Columns.Add(Resources.Strings.HasVisitorEnteredEvent, typeof(string));
                    foreach (var entry in guestList)
                    {
                        guestTable.Rows.Add(
                            entry.FirstName,
                            entry.LastName,
                            entry.TicketName,
                            entry.TicketType,
                            entry.ShortCode,
                            entry.HasEntered);
                    }
                    workSheet.Cell(1, 1).InsertTable(guestTable);
                    workSheet.Tables.ForEach(t => t.ShowAutoFilter = false);
                    workSheet.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    workSheet.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    workSheet.Tables.ForEach(t => t.Theme = XLTableTheme.TableStyleLight13);
                    workSheet.Columns().AdjustToContents();
                    workBook.SaveAs(outputStream);
                }
