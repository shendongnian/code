    public IList<Reciept> Get_Terrorist_Records2(string po_code)
            {
                IList<Reciept> p = null;
                using (ISession session = OpenSession())
                {
                    Reciept d = null;
                    Post_Office dt = null;
    
                    try
                    {
                        p = session.QueryOver<Reciept>(() => d)
                        .JoinAlias(() => d.po, () => dt)
                        .Where(() => dt.PO_CODE == po_code)
                        .List<Reciept>();
    
                       
                    }
                    catch (Exception rd)
                    { }
    
                }
                return p;
            }
