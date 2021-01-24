     using (var wb = new XLWorkbook())
            {
                var ticketList = _context.Tickets.ToList();
                var dateForXcellSheet = DateTime.Now;
                var worksheet = wb.Worksheets.Add("Sample Sheet");
              
                for (int i= 0; i < ticketList.Count(); i++)
                {
                    date = ticketList[i].DateCreated.ToString();
                    title = ticketList[i].Title;
                    createdBy = ticketList[i].CreatedBy;
                    isCallBack = ticketList[i].IsCallBack;
                
    			int index =  i + 1;
    			worksheet.Cell("A" + index).Value = date;
                worksheet.Cell("B" + index).Value = title;
                worksheet.Cell("C" + index).Value = createdBy;
                worksheet.Cell("D" + index).Value = isCallBack;
                }
    
               
    
                // Add ClosedXML.Extensions in your using declarations
    
                return wb.Deliver("tickets-" + dateForXcellSheet + ".xlsx");
            }
