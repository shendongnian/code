    public class SmsManagerOptions
    {
        public SmsManagerOptions(string smsAccountSid, string smsAuthToken, string smsFromNumber)
        {
            SmsAccountSid = smsAccountSid ?? throw new ArgumentNullException(nameof(smsAccountSid));
            SmsAuthToken = smsAuthToken ?? throw new ArgumentNullException(nameof(smsAuthToken));
            SmsFromNumber = smsFromNumber ?? throw new ArgumentNullException(nameof(smsFromNumber));
        }
        public string SmsAccountSid { get; }
        public string SmsAuthToken { get; }
        public string SmsFromNumber { get; }
    }
