    public static List<SearchResults> getMatchedHits(ScoreDoc[] hits, IndexSearcher searcher)
    {
       List<SearchResults> list = new List<SearchResults>();
       SearchResults obj;
       try
         {
           for (int i = 0; i < hits.Count(); i++)
            {
              // get the document from index
              Document doc = searcher.Doc(hits[i].Doc);
              string strFirstName  = doc.Get("FirstName");
              string strLastName = doc.Get("LastName");
              string strDesigName = doc.Get("DesigName");
              string strAddres  = doc.Get("Addres");
              string strCategoryName = doc.Get("CategoryName");
              obj = new SearchResults();
              obj.FirstName = strFirstName;
              obj.LastName = strLastName;
              obj.DesigName= strDesigName;
              obj.Addres = strAddres;
              obj.CategoryName = strCategoryName;
              list.Add(obj);
           }
           return list;
        }
        catch (Exception ex)
        {
           return null;
         }
    }
