    private byte[] TransferSpi(byte[] writeBuffer, byte ChipNo)
    {
        var readBuffer = new byte[writeBuffer.Length];
        if (ChipNo == 1) GpioPin_19.Write(GpioPinValue.Low);
        if (ChipNo == 2) GpioPin_26.Write(GpioPinValue.Low);
        if (ChipNo == 3) GpioPin_13.Write(GpioPinValue.Low);
         
        _spi1.TransferFullDuplex(writeBuffer, readBuffer);
        if (ChipNo == 1) GpioPin_19.Write(GpioPinValue.High);
        if (ChipNo == 2) GpioPin_26.Write(GpioPinValue.High);
        if (ChipNo == 3) GpioPin_13.Write(GpioPinValue.High);
        return readBuffer;
    }
