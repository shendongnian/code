    public string GenToken()
        {
            byte[] key = new byte[];
           var payload= new Dictionary<string, object>()
                    {
                        { "idUsr", 1 },
                        { "nameUsr", admin},
                        {"accessTime",DateTime.UtcNow.AddMinutes(30)}
                     };
            string token = JWT.JsonWebToken.Encode(payload, key , JWT.JwtHashAlgorithm.HS256);
                       return token;
        }
