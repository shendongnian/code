          var result = new List<string>();
            foreach (Login login in m_server.Logins)
            {
                if (!login.IsDisabled)
                {
                    result.Add(login.Name);
                }
            }
            return result;
