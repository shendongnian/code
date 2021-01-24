    public ActionResult PublicGrid()
        {
            ViewBag.members = db.Members.Count().ToString();
            var members = db.Members.ToList();
            return View(members.OrderBy(a => NumberOnly((a.Batch))).ThenBy(a=> a.LastName).ToList());
        }
        public static int NumberOnly(string strRaw)
        {
            string numbers = string.Empty;
            foreach (char c in strRaw)
            {
                
                if (Char.IsNumber(c))
                {
                    numbers += c;
                }
            }
            return Int32.Parse(numbers);
        }
