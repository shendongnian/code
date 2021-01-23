                var emailRegex = new Regex(@"((\w+[ ])|\""(.*?)\""+[ ])+(<?\b(\S+@\S+\.\S+)\b>)|(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)", RegexOptions.IgnoreCase);
                var emailMatches = emailRegex.Matches(Headers["to"]);
                foreach (Match emailMatch in emailMatches)
                {
                    try
                    {
                        To.Add(new MailAddress(emailMatch.Value));
                    }
                    catch (Exception ex)
                    {
                    }
                }
