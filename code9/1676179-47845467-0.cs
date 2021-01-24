     public ActionResult Test()
            {
                List<Tuple<int, int, string>> Downloadlist = new List<Tuple<int, int, string>>();
                Downloadlist.Add(new Tuple<int, int, string>(11, 7, "somedata"));
             
                ViewData["DownloadPages"] = Downloadlist;
                return View();
            }
