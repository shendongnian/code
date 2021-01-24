     protected override void OnStop()
            {
                _channel.Close();
                _connection.Close();
                _channel.Dispose();
                _connection.Dispose();
            }
