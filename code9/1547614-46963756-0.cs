     Byte[] file = File.ReadAllBytes("..\\..\\Data\\ccc.xxx");
            Stream stream = new MemoryStream(file);
            WebResponseDerializer<SIGetImageResponse> deserilizer = new WebResponseDerializer<SIGetImageResponse>(stream);
            SIGetImageResponse ddd = deserilizer.GetData();
            foreach (var item in ddd.ResponseData.AttachmentDescriptor.Attachment)
            {
                String contentId = "<<" + item.ImageData.Include.Href + ">>";
                contentId = contentId.Replace("%40", "@").Replace("cid:", "");
                item.ImageData.Include.XopData = deserilizer.GetAttachment(contentId);
            }
