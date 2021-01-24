    [OracleCustomTypeMapping("TEST.TBL_IDS")]
        public class TBL_IDS_FACTORY : IOracleArrayTypeFactory
        {
            #region IOracleArrayTypeFactory Members
            public Array CreateArray(int numElems)
            {
                return new string[numElems];
            }
    
            public Array CreateStatusArray(int numElems)
            {
                return null;
            }
    
            #endregion
        }
