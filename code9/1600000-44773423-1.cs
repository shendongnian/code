    public ActionResult DisplayCSV()
        {
            List<person> People = populatePeople();
            StringBuilder sb = new StringBuilder();
            foreach(var person in People)
            {
                sb.AppendLine(person.PersonToCSVLine);
            }
            return Content(sb.ToString());
        }
