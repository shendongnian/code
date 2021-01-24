        public override void Execute(CommandContext context)
        {
            var RedirectFolder = new SitecoreContext(GetContentDatabase()).GetItem<BaseCommon>(context.Items[0].ID.ToGuid(), context.Items[0].Language);
            var lstLinkToRedirect = RedirectFolder.Children.OfType<LinkToLinkRedirect>();
            var filename = "RedirectsOutput_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
            var sb = new StringBuilder();
            sb.AppendLine($"{"Redirecttype"},{"Sourcelink Url"}, {"Targetlink Url"}");
            // collect all information 
            var allLines = (from item in lstLinkToRedirect
                            select new object[]
                            {
                                               item.RedirectType,
                                               item.SourceLink.Url,
                                               item.TargetLink.Url
                            }).ToList();
            // insert the content
            allLines.ForEach(line =>
            {
                sb.AppendLine(string.Join(",", line));
            });
            string filePath = "/temp/" + filename;
            using( TextWriter tw = new StreamWriter(filePath))
           {
               tw.WriteLine(sb.ToString());
               tw.Close();
           }
           SheerResponse.Download(filePath);
        }
