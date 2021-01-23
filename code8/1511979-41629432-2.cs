            DirectoryInfo di = new DirectoryInfo(HostingEnvironment.MapPath("/App_Data"));
            var fi = di.EnumerateFiles("*.xml", SearchOption.TopDirectoryOnly);
            ViewBag.Files = fi;
            string[] fs = new string[fi.Count()];
            int fc = fi.Count();
            int x = 0;
            foreach (FileInfo f in fi)
            {
                StreamReader sr = new StreamReader(f.FullName);
                fs[x] = sr.ReadToEnd();
                sr.Close();
                if (x < fc) x++;
            }
            ViewBag.Contents = fs;
            ViewBag.ContCount = fc;
