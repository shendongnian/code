        public void OpenBookmarksFile()
        {
            string BookmarksFile_w_impeding_tags = @"your_bookmarks_file.html";
            BuildTree(treeView, XDocument.Load(Path.Combine(Directory.GetCurrentDirectory(), (DeleteTags(BookmarksFile_w_impeding_tags)))));
        }
        public string DeleteTags(string BookmarksFile_w_impeding_tags)
        {
            StreamReader BookmarkDatei = new StreamReader(BookmarksFile_w_impeding_tags);
            string content = BookmarkDatei.ReadToEnd();
            BookmarkDatei.Close();
            HtmlDocument doc_lessTags = new HtmlDocument();
            //deletes all DD Tags
            string DD = "(<DD>[a-zA-Z0-9]+[^<]+)"; //Regex-Pattern
            doc_lessTags.LoadHtml(Regex.Replace(content, DD, ""));
            //variable for each tag that could be impeding for displaying the correct hierarchy
            var metas = doc_lessTags.DocumentNode.SelectNodes("//meta");
            var titles = doc_lessTags.DocumentNode.SelectNodes("//title");
            var h1s = doc_lessTags.DocumentNode.SelectNodes("//h1");
            var dts = doc_lessTags.DocumentNode.SelectNodes("//dt");
            var ps = doc_lessTags.DocumentNode.SelectNodes("//p");
            var hrs = doc_lessTags.DocumentNode.SelectNodes("//hr");
            var dds = doc_lessTags.DocumentNode.SelectNodes("//dd");
            var aa = doc_lessTags.DocumentNode.SelectNodes("//a");
            var h3s = doc_lessTags.DocumentNode.SelectNodes("//h3");
            //delete all tags that could be impeding (comments too)
            //------------------------------------------------------------------------------------------------------------------------
            var doctype = doc_lessTags.DocumentNode.SelectSingleNode("/comment()[starts-with(.,'<!DOCTYPE')]");
            if (doctype != null)
            {
                doctype.Remove();
            }
            //------------------------------------------------------------------------------------------------------------------------
            var comments = doc_lessTags.DocumentNode.SelectSingleNode("//comment()");
            if (comments != null)
            {
                comments.Remove();
            }
            //------------------------------------------------------------------------------------------------------------------------
            foreach (var meta in metas)
            {
                meta.Remove();
            }
            //------------------------------------------------------------------------------------------------------------------------
            foreach (var title in titles)
            {
                title.Remove();
            }
            //------------------------------------------------------------------------------------------------------------------------
            foreach (var h1 in h1s)
            {
                h1.Remove();
            }
            //-----some(open tags, like DT) can not be deleted the normal way becaue they would reverse the order of our file------
            if (dts != null)
            {
                foreach (var dt in dts)
                {
                    if (!dt.HasChildNodes)
                    {
                        dt.ParentNode.RemoveChild(dt);
                        continue;
                    }
                    for (var i = dt.ChildNodes.Count - 1; i >= 0; i--)
                    {
                        var child = dt.ChildNodes[i];
                        dt.ParentNode.InsertAfter(child, dt);
                    }
                    dt.ParentNode.RemoveChild(dt);
                }
            }
            //--------------------------------------------------------------------------------------------------------------------------------------
            if (ps != null)
            {
                foreach (var p in ps)
                {
                    if (!p.HasChildNodes)
                    {
                        p.ParentNode.RemoveChild(p);
                        continue;
                    }
                    for (var i = p.ChildNodes.Count - 1; i >= 0; i--)
                    {
                        var child = p.ChildNodes[i];
                        p.ParentNode.InsertAfter(child, p);
                    }
                    p.ParentNode.RemoveChild(p);
                }
            }
            //--------------------------------------------------------------------------------------------------------------------------------------
            if (hrs != null)
            {
                foreach (var hr in hrs)
                {
                    if (!hr.HasChildNodes)
                    {
                        hr.ParentNode.RemoveChild(hr);
                        continue;
                    }
                    for (var i = hr.ChildNodes.Count - 1; i >= 0; i--)
                    {
                        var child = hr.ChildNodes[i];
                        hr.ParentNode.InsertAfter(child, hr);
                    }
                    hr.ParentNode.RemoveChild(hr);
                }
            }
            //--------------------------------------------------------------------------------------------------------------------------------------
            if (dds != null)
            {
                foreach (var dd in dds)
                {
                    if (!dd.HasChildNodes)
                    {
                        dd.ParentNode.RemoveChild(dd);
                        continue;
                    }
                    for (var i = dd.ChildNodes.Count - 1; i >= 0; i--)
                    {
                        var child = dd.ChildNodes[i];
                        dd.ParentNode.InsertAfter(child, dd);
                    }
                    dd.ParentNode.RemoveChild(dd);
                }
            }
            //------------------------------------------------------------------------------------------------------------------------
            //system partition
            string sysPart = System.IO.Path.GetPathRoot(Environment.SystemDirectory);
            //currently logged in user
            string userName = Environment.UserName;
            //after deleting all impeding tags we save the result to a new file so that we can keep our original file untouched
            string BookmarksFile_less_tags = $@"{sysPart}Users\{userName}\Desktop\bookmarks_less_tags";
            doc_lessTags.Save(BookmarksFile_less_tags);
            return BookmarksFile_less_tags;
        }
