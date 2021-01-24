    return Ok(new {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo,
                        username = user.FullName,
                        StatusCode = StatusCode(200)
                    });
