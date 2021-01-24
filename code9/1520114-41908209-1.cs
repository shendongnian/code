    [System.Web.Script.Services.ScriptMethod()]
            [System.Web.Services.WebMethod]
            public static List<string> SearchAutoComplete(string prefixText, int count)
            {
                using (var _context = new Entities())
                {
                    var Q = from lcN in _context.table                                     
                                   where (lcN.Name.Contains(prefixText))
                                   select lcN;
                    List<String> List= new List<String>();
                    foreach (var Qr in Q )
                    {
                        List.Add(Qr.Q );
                    }
                    return List;
                }
            }
