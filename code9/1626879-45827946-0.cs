                /* START THE MEAT OF THIS PROCEDURE */
                IList<string> deserializeMessages = new List<string>();
                /* first get any serialization issues */
                MyCoolObject p = JsonConvert.DeserializeObject<MyCoolObject>(jsonContent,
                    new JsonSerializerSettings
                    {
                        Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                        {
                            deserializeMessages.Add(args.ErrorContext.Error.Message);
                            args.ErrorContext.Handled = true;
                        }
                    });
                IList<string> jsonSchemaMessages = new List<string>();
                bool jsonSchemaIsValid = true;
                /* now, only if there were no serialization issues, look at the schema */
                if (!deserializeMessages.Any())
                {
                    Newtonsoft.Json.Linq.JObject jobj = Newtonsoft.Json.Linq.JObject.Parse(jsonContent);
                    jsonSchemaIsValid = jobj.IsValid(jschem, out jsonSchemaMessages);
                }
                IEnumerable<string> allMessages = deserializeMessages.Union(jsonSchemaMessages);
                bool overallValid = !allMessages.Any();
                /* END THE MEAT OF THIS PROCEDURE */
