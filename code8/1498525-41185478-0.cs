            HtmlWeb h = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = h.Load("http://stackoverflow.com/questions/41183837/how-to-store-html-nodes-into-database");
            HtmlNodeCollection tableNodes = doc.DocumentNode.SelectNodes("//table");
            HtmlNodeCollection h1Nodes = doc.DocumentNode.SelectNodes("//h1");
            HtmlNodeCollection pNodes = doc.DocumentNode.SelectNodes("//p");
            //get other nodes here
    
            foreach (var pNode in pNodes)
            {
                string id = pNode.Id;
                string content = pNode.InnerText;
                string tag = pNode.Name;
    
                //do other stuff here and then save to database
    
                //just an example...
                SqlConnection conn = new SqlConnection("here goes conection string");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO tblNodeCollection (Tag, Id, Content) VALUES (@tag, @id, @content)";
                cmd.Parameters.Add("@tag", tag);
                cmd.Parameters.Add("@id", id);
                cmd.Parameters.Add("@content", content);
    
                cmd.ExecuteNonQuery();
            }
