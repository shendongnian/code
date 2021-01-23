            rxString = SerialPort.ReadExisting();
            byte[] bytes = Encoding.ASCII.GetBytes(rxString);
            var a = bytes[0];
            var b = bytes[1];
            if (a == 0x74)
            {
                tb_Status.AppendText("This is Good");
            }
