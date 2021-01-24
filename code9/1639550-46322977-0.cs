    ioWrapper.Setup(_ => _.ReadAsync2(
                             It.IsAny<byte[]>(), 
                             It.IsAny<int>(), 
                             It.IsAny<int>(), 
                             It.IsAny<CancellationToken>()
                         )
                    )
            .ReturnsAsync(BitConverter.ToInt32(AutoAck, 0));
