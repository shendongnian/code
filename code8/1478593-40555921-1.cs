            [HttpPost]
        public JsonResult CreateG(List<string> group)
        {
            if (group == null)
            {
                ///break if the post failed
            }
       //assign values base on where they were placed in array and remove after
            string name = group[0];
            group.RemoveAt(0);
            string server = group[0];
            group.RemoveAt(0);
            string email = group[0];
            group.RemoveAt(0);
            string type = group[0];
            group.RemoveAt(0);
            string perm = group[0];
            group.RemoveAt(0);
    //iterate through the remainder of users
            foreach (string user in group)
            {
      //do whatever
            }
            
            return Json(group);
        }
