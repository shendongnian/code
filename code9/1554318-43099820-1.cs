            double vValue;
            string[] vValuesString = vLines[j].Split(',');
            double[] vValuesDouble = new double[vValuesString.Length];
            for (int x = 0; x < vValuesString.Length; x++)
                if (double.TryParse(vValuesString[x], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out vValue))
                    return; 'or use' continue;'or use' vValuesDouble[x] = 0;
                else vValuesDouble[x] = vValue;
