            dsImages = bolImages.SelectImagesByID();
            if (dsImages.Tables[0].Rows.Count > 0)
            {
                string[] values = dsImages.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                  values[i] = values[i].Trim();
                }
                var newdsImages = values.ToList();
                DLImages.DataSource = newdsImages ;
                DLImages.DataBind();
            }
