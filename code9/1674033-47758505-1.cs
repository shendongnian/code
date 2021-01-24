            var output = new List<object>
            {
                new { Sample = "Sample" }
            };
            var objectSerialize = new ObjectSerialize
            {
                ObjectList = output
            };
            XmlSerializer xsSubmit = new XmlSerializer(typeof(ObjectSerialize));
            var xml = "";
    
            using (var sww = new StringWriter())
            {
                using (XmlWriter writers = XmlWriter.Create(sww))
                {
                    try
                    {
                        xsSubmit.Serialize(writers, objectSerialize);
                    }
                    catch (Exception ex)
                    {
    
                        throw;
                    }
                    xml = sww.ToString(); // Your XML
                }
            }
