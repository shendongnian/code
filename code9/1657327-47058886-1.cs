    using FluentValidation;
    using Xunit;
    using System;
    using System.Collections.Generic;
    
    namespace test
    {
        public class InputsValidatorTests
        {
            [Fact]
            public void WhenContainsNull_ThenIsNotValid()
            {
                var inputs = new Inputs();
                inputs.MobileNos = new List<string>() { null, "7897897897" };
                var inputsValidator = new InputsValidator();
                
                var result = inputsValidator.Validate(inputs);
                
                Assert.False(result.IsValid);
            }
        }
    }
