    public class SolvencyBllTest
    {
        private MyAttBLL myAttBll;
        private readonly List<AttestationEntity> attestationsFakeForTest = new List<AttestationEntity>
        {
           /// ... Build the child object , used for 'mock'
		}
		
		//Initialize event => here we define what the 'mock' should to de when we use the [GetListWithChildren] function
		[TestInitialize]
        public void Setup()
        {
            var mockedAttestationFakeToTest = new Mock<IAttestationDataAccessLayer>();
            //setup GetAll : return the whole list
            mockedAttestationFakeToTest
                .Setup(attestation => attestation.GetListWithChildren(It.IsAny<Expression<Func<AttestationEntity, bool>>>()))
                .Returns((Expression<Func<AttestationEntity, bool>> expression) =>
                {
                    return this.attestationsFakeForTest.AsQueryable().Where(expression);
                });
           
            this.myAttBll = new MyAttBLL(attestationsCertificatesRefundDal: null, attestationDal: mockedAttestationFakeToTest.Object, emailNotifier: mockedEmailNotifier.Object);
        }
		
		[TestMethod]
        public void SolvencyBllTest_CheckAttestation()
        {
            // Initalize the result
            SolvencyCheckResult solvencyCheckResult = new SolvencyCheckResult()
            {
                solvency = new SolvencyModel()
            };
            
			// Declare and initializes our object which encapsulates our parameters for the solvency check
            SolvencyCheckParameters solvencyCheckParams = new SolvencyCheckParameters(TestConstants.Contact.LAST_NAME, TestConstants.Contact.FIRST_NAME, TestConstants.Contact.BIRTH_DATE, TestConstants.Address.STREET, TestConstants.Address.ZIPCODE, TestConstants.UNIT_TEST_USER);
            
			// this (solvencyBll) will not try to find in the database but in the collection with just mock before
			// Try to retrieve all certificates dating back 3 months and have the same name + first name + date of birth
			List<AttestationModel> attsLatestToCheck = this.myAttBll.CheckLatestAttestation(solvencyCheckResult, solvencyCheckParams);
            
			// 1 attestation created today   		=>  OK
            // 1 attestation created 1 month ago    =>  OK
            // 1 attestation created 2 month ago    =>  OK
            // 1 attestation created 4 month ago    =>  KO
            Assert.AreEqual(3, attsLatestToCheck.Count);
        }
