    [TestClass]
    public class UnitTestExample {
        [TestMethod]
        public void Invalid_email_addresses_throw_errors() {
            //Arrange
            var badEmail = "1234_)(";
            var subject = new Customer { email = badEmail };
            //Act
            var results = ValidateModel(subject);
            //Assert
            Assert.IsTrue(results.Count > 0);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("email")));
        }
        public class Customer {
            [StringLength(100)]            
            [Display(Name = "Email")]
            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Email must be a valid email address")]
            public string email { get; set; }
        }
        private List<ValidationResult> ValidateModel<T>(T model) {
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(model, context, result, true);
            return result;
        }
    }
