     if (this.JsonData == null)
                    {
                        _dynamicProperties = new Dictionary<string, object>();
                    }
                    else
                    {
                        _dynamicProperties = Mapper.Map<IDictionary<string, object>>(JObject.Parse(this.JsonData));
                    }
