        internal decimal GetDecimal(NativeBuffer_RowBuffer buffer) {
            if (typeof(decimal) != _metaType.BaseType) { 
                throw ADP.InvalidCast();
            }
            if (IsDBNull(buffer)) {
                throw ADP.DataReaderNoData(); 
            }
            Debug.Assert(null == _longBuffer, "dangling long buffer?"); 
  
            decimal result = OracleNumber.MarshalToDecimal(buffer, _valueOffset, _connection);
            return result; 
        }
 
        internal double GetDouble(NativeBuffer_RowBuffer buffer) {
            if (typeof(decimal) != _metaType.BaseType) { 
                throw ADP.InvalidCast();
            } 
            if (IsDBNull(buffer)) { 
                throw ADP.DataReaderNoData();
            } 
            Debug.Assert(null == _longBuffer, "dangling long buffer?");
 
            decimal decimalValue = OracleNumber.MarshalToDecimal(buffer, _valueOffset, _connection);
            double result = (double)decimalValue; 
            return result;
        } 
