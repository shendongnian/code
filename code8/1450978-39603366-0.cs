       ret.AddRange(_entities.Users.AsEnumerable().Where(x =>EncDec.Decrypt(x.UserVar01.Trim().Replace("_",string.Empty), 
                    Enums.EncDecSecKeyToString(Enums.EncDecSecKey.Email)).Contains(fText.Trim()))
                                 .Select(select => new Lookup
                                 {
                                     boundvalue = select.UserID,
                                     boundtext = EncDec.Decrypt(select.UserVar01.Trim().Replace("_", string.Empty),
                                     Enums.EncDecSecKeyToString(Enums.EncDecSecKey.Email)),
                                 }));
