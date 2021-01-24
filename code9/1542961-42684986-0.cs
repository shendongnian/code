        public override void Connect() {
            if (this.Connected) {
                return;
            }
            this.factory = new ConnectionFactory {
                HostName = this.config.Hostname,
                Password = this.config.Password,
                UserName = this.config.Username,
                HandshakeContinuationTimeout = TimeSpan.FromSeconds(2),
                Port = this.config.Port,
                RequestedHeartbeat = 1,
                ContinuationTimeout = TimeSpan.FromSeconds(2),
                AutomaticRecoveryEnabled = false,
                VirtualHost = VirtualHost,
                UseBackgroundThreadsForIO = true
            };
            this.connection = this.factory.CreateConnection();
            this.channel = this.connection.CreateModel();
            this.channel.ExchangeDeclare(
                exchange: Exchange,
                type: "direct",
                durable: true
            );
        }
