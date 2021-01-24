        public static string TryGetMacAddressOnLinux(string ip)
        {
            _erro.Clear(); 
            if (!Ping(ip))
                _erro.Append("Não foi possível testar a conectividade (ping) com o ip informado.\n");
            string arp = $"arp -a {ip}";
            string retorno = Bash(arp);
            StringBuilder sb = new StringBuilder();
            string pattern = @"(([a-f0-9]{2}:?){6})";
            int i = 0;
            foreach (Match m in Regex.Matches(retorno, pattern, RegexOptions.IgnoreCase))
            {
                if (i > 0)
                    sb.Append(";");
                sb.Append(m.ToString());
                i++;
            }
            return sb.ToString();
        }
