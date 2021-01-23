    DataTable JsonToDataTable (string text)
            {
                if(text.Substring(0,5) == "empty")
                {
                    text = text.Remove(0, 5);
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(text, (typeof(DataTable)));
                    dt.Rows[0].Delete();
                    return dt;
                }
                return (DataTable)JsonConvert.DeserializeObject(text, (typeof(DataTable)));
            }
