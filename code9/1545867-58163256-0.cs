      ClaimsIdentity getClaimsIdentity()
                    {
                        return new ClaimsIdentity(
                            getClaims()
                            );
                        
                       Claim[] getClaims()
                        {
                            List<Claim> claims = new List<Claim>();
                            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                            foreach (var item in user.Roles)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, item));
                            }
                            return claims.ToArray();
                        }
                       
                    }
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                          
                            Subject = getClaimsIdentity()
                        }
