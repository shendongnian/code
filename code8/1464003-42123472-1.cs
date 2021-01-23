      [HttpPost]
        public ActionResult SaveEvent(DiaryEvent events)
        {
            try
            {
                int submit = bookingService.Insert(events);
                //get record here to check if inserted
                if(submit > 0)
                {
                }
            }
            catch(Exception ex)
            {
                ErrorLog.Capture(ex);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                //return some shit
            }
            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }
