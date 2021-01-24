        JArray temp =  JArray.Parse(json);
        foreach (JToken tk in temp.Descendants())
        {
            if (tk.Type == JTokenType.Property)
            {
                JProperty p = tk as JProperty;
                if (p.Name == "flag")
                {
                    if ((bool)p.Value.ToObject(typeof(bool)) == true)
                        p.Value = false;
                }
                if ((p.Name == "info") && p.HasValues)
                {
                    bool flag = false;
                    foreach (JToken tkk in p.Descendants())
                    {
                        if (tkk.Type == JTokenType.Property)
                        {
                            JProperty pp = tkk as JProperty;
                            if ((pp.Name == "name") && (pp.Value.Type == JTokenType.Null))
                            {
                                flag = true;
                            }
                            if ((pp.Name == "infoFlag"))
                            {
                                pp.Value = (flag == true) ? true : false;
                            }
                        }
                    }
                }
            }
        }
        json = temp.ToString();
