     /// <summary>
        /// Dates  represented as Unix timestamp 
        /// with slight modification: it defined as the number
        /// of seconds that have elapsed since 00:00:00, Thursday, 1 January 1970.
        /// To convert it to .NET DateTime use following extension
        /// </summary>
        /// <param name="_time">DateTime</param>
        /// <returns>Return as DateTime of uint time
        /// </returns>
        public DateTime ToDateTime( uint _time)
        {
            return new DateTime(1970, 1, 1).AddSeconds(_time);
        }
        /// <summary>
        /// Dates  represented as Unix timestamp 
        /// with slight modification: it defined as the number
        /// of seconds that have elapsed since 00:00:00 Thursday, 1 January 1970.
        /// To convert .NET DateTime to Unix time use following extension
        /// </summary>
        /// <param name="_time">DateTime</param>
        /// <returns>
        /// Return as uint time of DateTime
        /// </returns>
        public uint ToUnixTime(DateTime _time)
        {
            return (uint)_time.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
