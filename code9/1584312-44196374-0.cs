		// GET api/MyTable?langid=mk-MK
        [HttpGet]
        public IQueryable<MyTable> GetMyTable(string langid)
        {
            IQueryable<MyTable> mytable = db.MyTables.Where(x => x.LanguageId == langid);
            if (mytable == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return mytable;
        }
        // GET api/MyTable?id=5&langid=mk-MK
        [HttpGet]
        public MyTable GetMyTable(byte id, string langid)
        {
            MyTable mytable = db.MyTables.Find(id, langid);
                
            if (mytable == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return mytable;
        }
