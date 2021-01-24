    public static class CreditCardEncryptor
    {
        public static string Encrypt(string ccNum)
        {
            return Convert.ToString(Convert.ToInt64(ccNum) * 13 + 43);
        }
        public static string Decrypt(string encryptedCcNum)
        {
            return Convert.ToString(-43 / 13 + Convert.ToInt64(encryptedCcNum) / 13);
        }
    }
    [TestFixture]
    public class CreditCardEncryptorTests
    {
        [TestCase("5105105105105100")]
        [TestCase("4012888888881881")]
        [TestCase("4222222222222")]
        [TestCase("4111111111111111")]
        public void WhenIDecryptItShouldReturnCcNumber(string ccNum)
        {
            Assert.That(ccNum, Is.EqualTo(CreditCardEncryptor.Decrypt(CreditCardEncryptor.Encrypt(ccNum))));
        }
    }
