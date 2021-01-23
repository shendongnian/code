     string[] textboxValues = Request.Form.GetValues("DynamicTextBox");
                            if (textboxValues == null || textboxValues.Length == 0)
                            {
                                string empty = "true";
                            }
                            else
                            {
    
                                JavaScriptSerializer serializer = new JavaScriptSerializer();
                                this.Values = serializer.Serialize(textboxValues);
    
                                foreach (string textboxValue in textboxValues)
                                {
    
                                    MultipleId.Add(textboxValue);
                                }
                            }
