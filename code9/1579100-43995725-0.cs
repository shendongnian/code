    try
    {
       using (var _context = new DBContext())
       {
          //Normal save logic here
         _context.Save();
       }
    }
    catch(Exception ex)
    {
       using (var _context = new DBContext())
       {
          //Log error here
         _context.Save();
       }
    }
