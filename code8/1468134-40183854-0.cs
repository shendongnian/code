     private static TimeStampResp readTimeStampResp(
            Asn1InputStream input)
        {
            try
            {
                return TimeStampResp.GetInstance(input.ReadObject());
            }
            catch (ArgumentException e)
            {
                throw new TspException("malformed timestamp response: " + e, e);
            }
            catch (InvalidCastException e)
            {
                throw new TspException("malformed timestamp response: " + e, e);
            }
        }
