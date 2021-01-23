        {
            int? a = 10;
            long? b = 10L;
            Process(a);
            Process(b);
        }
        private static void Process(INullable value)
        {
            if (value.IsNull)
            {
                // Process for null .. 
            }
            else
            {
                // Process for value .. 
            }
        }
