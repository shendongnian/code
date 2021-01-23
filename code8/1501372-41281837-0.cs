     public FileContentResult Download(int id)
     {
        return File(_context.myTable.Find(id).MyBLOBField,
                    _context.myTable.Find(id).MyFieldContentType, 
                    _context.Richieste.Find(id).MyFieldOriginalFileName
         );
     }
    
