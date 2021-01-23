    using System;
    using System.Linq;
    using Xunit;
    using MonthlyStatements.Controllers;
    using MonthlyStatements.Models;
    using System.IO;
    using System.Web.Mvc;
    
    namespace UnitTestProject1
    {
        public class UnitTest1
        {
            [Theory]
            [InlineData(10.20, "System.Double")]
            [InlineData(0, "System.Double")]
            public void checkValidation(double amt, string ExpectedResult)
            {
                //Arrange
                string actualResult = "";
                //Act
                //double doubleAmt = double.Parse(amt.ToString());
                actualResult = amt.GetType().ToString();
                //Assert
                 Assert.Equal(ExpectedResult, actualResult);
            }
        }
    }
