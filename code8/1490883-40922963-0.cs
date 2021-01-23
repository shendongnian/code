            /// <summary>
            /// Convert DateTime object into specially formated string.
            /// </summary>
            /// <param name="dateTime">DateTime which will be converted.  </param>
            /// <returns>Custom date and time string.</returns> 
            public static string ToFormattedString(this DateTime dateTime)
            {
                return dateTime.ToString("dd/MM/yyyy HH:mm");
            }
