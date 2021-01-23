        public static string Serialize<T>(T entity)
        {
            if (entity == null)
                return String.Empty;
            try
            {
                XmlSerializer XS = new XmlSerializer(typeof(T));
                System.IO.StringWriter SW = new System.IO.StringWriter();
                XS.Serialize(SW, entity);
                return SW.ToString();
            }
            catch (Exception e)
            {
                Logging.Log(Severity.Error, "Unable to serialize entity", e);
                return String.Empty;
            }
        }
