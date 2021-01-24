          [WebMethod]
          public string Insert(string i, string c, string f, string l, string a)
          {
            XmlDocument xl = new XmlDocument();
            xl.Load(Server.MapPath("~/student.xml"));
            XmlElement parent = xl.CreateElement("student");
            XmlElement id = xl.CreateElement("id");
            XmlElement cohort = xl.CreateElement("cohort");
            XmlElement fname = xl.CreateElement("firstname");
            XmlElement lname = xl.CreateElement("lastname");
            XmlElement add = xl.CreateElement("address");
            id.InnerText = i;
            cohort.InnerText = c;
            fname.InnerText = f;
            lname.InnerText = l;
            add.InnerText = a;
            parent.AppendChild(id);
            parent.AppendChild(cohort);
            parent.AppendChild(fname);
            parent.AppendChild(lname);
            parent.AppendChild(add);
            xl.DocumentElement.AppendChild(parent);
            xl.Save(Server.MapPath("~/student.xml"));
            LoadData();
            return i.ToString()+ c.ToString() + f.ToString() + l.ToString() + 
            a.ToString();
           }
