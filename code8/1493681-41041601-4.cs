    /// <summary>
    /// Асинхронный запрос на ожидание приёма данных с возможностью досрочного выхода
    /// (для выхода из ожидания вызовите метод Disconnect())
    /// </summary>
    /// <param name="client">Рабочий экземпляр класса UdpClient</param>
    /// <param name="breakToken">Признак досрочного завершения</param>
    /// <returns>Если breakToken произошёл до вызова данного метода или в режиме ожидания
    /// ответа, вернёт пустой UdpReceiveResult; при удачном получении ответа-результат
    /// асинхронной операции чтения</returns>
    public Task<UdpReceiveResult> ReceiveAsync(UdpClient client, CancellationToken breakToken)
        => breakToken.IsCancellationRequested
            ? Task<UdpReceiveResult>.Run(() => new UdpReceiveResult())
            : Task<UdpReceiveResult>.Factory.FromAsync(
                (callback, state) => client.BeginReceive(callback, state),
                (ar) =>
                    {
                        /// Предотвращение <exception cref="ObjectDisposedException"/>
                        if (breakToken.IsCancellationRequested)
                            return new UdpReceiveResult();
    
                        IPEndPoint remoteEP = null;
                        var buffer = client.EndReceive(ar, ref remoteEP);
                        return new UdpReceiveResult(buffer, remoteEP);
                    },
                null);
