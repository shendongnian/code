    public static Expression<Func<PTT_CUSTOMER_DEVICES, CustomerDevice>>
                CustomerDeviceExpression = d =>
                    new CustomerDevice
                    {
                        customerAssetTag = d.CustomerAssetTag,
                        customerDeviceID = d.CustomerDeviceID,
                        Model = new Model()
                        {
                            ModelID = d.PTS_MODELS.ModelID,
                            Name = d.PTS_MODELS.Name,
                            Make = new Make()
                            {
                                MakeID = d.PTS_MODELS.PTS_MAKES.MakeID,
                                Name = d.PTS_MODELS.PTS_MAKES.Name
                            }
                        }
                     };
