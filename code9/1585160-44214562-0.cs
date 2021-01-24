     using (var client = new SshClient(host, user, pass)) {
                client.Connect();
                client.CreateCommand("export ORACLE_HOME=/opt/oracle/product/client/11.2.0").Execute();
                client.CreateCommand("export TWO_TASK=SSID").Execute();
                client.CreateCommand("$ORACLE_HOME/bin/sqlplus").Execute());
                ...
                client.Disconnect();
      }
