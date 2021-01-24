        /// <summary>
        ///    Writes a sequence of coils.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        void WriteMultipleCoils(byte slaveAddress, ushort startAddress, bool[] data);
