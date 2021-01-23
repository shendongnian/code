        public ActionResult Files()
        {
            ViewBag.TheFiles = GetFiles(Server.MapPath("/testVirPath/"));
            return View();
        }
        private FileInfo[] GetFiles(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles();
            return files;
        }
