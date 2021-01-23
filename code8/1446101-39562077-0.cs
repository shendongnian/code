    var jsonObject = new JObject
                            {
                                {"accountEnabled", true},
                                {"country", customer.CustomerBase.Company},
                                {"creationType", "LocalAccount"},
                                {"displayName", pendingCustomer.Email.Trim()},
                                {"passwordPolicies", "DisablePasswordExpiration,DisableStrongPassword"},
                                {"passwordProfile", new JObject
                                {
                                    {"password", pwd},
                                    {"forceChangePasswordNextLogin", true}
                                } },
                                {"signInNames", new JArray
                                    {
                                        new JObject
                                        {
                                            {"value", pendingCustomer.Email.Trim()},
                                            {"type", "emailAddress"}
                                        }
                                    }
                                }
                            };
    client = new B2CGraphClient(ClientId, ClientSecret, TenantId);
    var response = await client.CreateUser(jsonObject.ToString());
    var newUser = JsonConvert.DeserializeObject<User>(response);
