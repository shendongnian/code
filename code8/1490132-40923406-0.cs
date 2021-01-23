        public async Task<BluetoothGattCharacteristic> GetCharecteristic(int timeout, BluetoothGattCharacteristic characteristic)
        {
            EnableCharacteristicNotification(characteristic);            
            m_gatt.ReadCharacteristic(characteristic);                 
            return m_characteristic;
        }
    
        public override void OnCharacteristicRead(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, [Android.Runtime.GeneratedEnum] GattStatus status)
        {
            m_SemaphoreSlim.Wait();
            m_characteristic = characteristic;
            m_SemaphoreSlim.Release();
        }
    
        public override void OnCharacteristicChanged(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic)
        {
            m_SemaphoreSlim.Wait();
            m_characteristic = characteristic;
            m_SemaphoreSlim.Release();
        }
