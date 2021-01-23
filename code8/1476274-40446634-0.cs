    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
        public static void Main()
        {
    
            string pattern = @"describe\('[^']*', function \(\) {.*?it\('([^']*)-Expected result-([^']*)',";
            string input = @"describe('Criteria and Adjustment Section', function () {
        it('the labels should have correct spellings -Expected result- the labels have correct spellings', function () {
        //some logic
    });
    
    
    describe('Test 1', function () {
        it('Click on the company dropdown -Expected result- Four options will be shown', function () {
        //some logic 
    });";
            RegexOptions options = RegexOptions.Multiline | RegexOptions.Singleline;
            int count=0;
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                ++count;
                Console.WriteLine("Test No : "+count);
                Console.WriteLine("Test-Cases: "+m.Groups[1].Value);
                Console.WriteLine("Expected Reult: "+m.Groups[2].Value);
    
            }
        }
    }
