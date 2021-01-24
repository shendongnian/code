    [Route("Preview"), HttpPost]
            public string Preview(PlateTemplateExtendedDto data)
            {
                var img = new PlateService().CreateTemplate(true);
                using (var ms = new MemoryStream())
                {
                    img.Save(ms, ImageFormat.Jpeg);
                    var base64 = "data:image/jpeg;base64," + Convert.ToBase64String(ms.ToArray());
                    return base64;
                }
            }
