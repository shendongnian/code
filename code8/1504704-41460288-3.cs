        /// <summary>
        /// Sets property value at specified key
        /// </summary>
        /// <param name="key">Index</param>
        /// <param name="value">Value</param>
        public void SetValue(PropertyKey key, PropVariant value)
        {
            Marshal.ThrowExceptionForHR(storeInterface.SetValue(ref key, ref value));
        }
