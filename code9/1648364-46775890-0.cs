     private static void GenerateNewInputFile(
            string server, 
            string user, 
            string password, 
            int port, 
            string database,
            string query,
            string mysqlLocation,
            string outputFilePath)
        {
            using (var powershell = PowerShell.Create())
            {
                var sb = new StringBuilder();
                sb.Append($"$server = \"{server}\"\n");
                sb.Append($"$user = \"{user}\"\n");
                sb.Append($"$password = \"{password}\"\n");
                sb.Append($"$port = {port}\n");
                sb.Append($"$db = \"{database}\"\n");
                sb.Append($"$query = \"{query}\"\n");
                sb.Append($"$mysql = \"{mysqlLocation}\"\n");
                sb.Append("$params = \"-C\",\"-B\",\"-h$server\",\"-P$port\",\"-u$user\",\"-p$password\",$db,\"-e$query\"\n");
                sb.Append($"&  $mysql @params | Out-File \"{outputFilePath}\"\n");
                powershell.AddScript(sb.ToString());
                
                powershell.Invoke();
            }
        }
