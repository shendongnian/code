            [HttpPost]
            public bool haha([FromBody]int id)
            {
                bool res = false;
                try
                {
                    int ans = id / 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return res;
            } 
