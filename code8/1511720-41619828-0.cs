           public static void WriteError(Exception ex)
            {
                XDocument doc = new XDocument("Error", new object[] {
                    new XElement("message", ex.Message),
                    new XElement("stacktrace", ex.StackTrace),
                    new XElement("helplink", ex.HelpLink)
                });
                
                sql.Insert(doc);
            }
