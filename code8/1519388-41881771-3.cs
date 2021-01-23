    [TestFixture]
    class ReferentieBuilderTests
    {
        private IUnitOfWorkAsync _unitOfWork;
        [SetUp]
        public void setup()
        {
            List<ParameterGetal> dateParameterGetallen = new List<ParameterGetal>
            {
                new ParameterGetal{ID = 29, parameter = "Datum", parameterwaarde = string.Format("{0:dd/MM/yyyy}", DateTime.Today.AddDays(-1)) }
            };
            List<ParameterGetal> tellerParameterGetallen = new List<ParameterGetal>
            {
                new ParameterGetal{ID = 3, parameter = "orderteller", parameterwaarde = "4" }
            };
            IQueryFluent<ParameterGetal> datefluent = MockRepository.GenerateStub<IQueryFluent<ParameterGetal>>();
            IQueryFluent<ParameterGetal> tellerfluent = MockRepository.GenerateStub<IQueryFluent<ParameterGetal>>();
            IRepositoryAsync<ParameterGetal> parametergetalrepository = MockRepository.GenerateStub<IRepositoryAsync<ParameterGetal>>();
            _unitOfWork = MockRepository.GenerateStub<IUnitOfWorkAsync>();
            _unitOfWork.Stub(u => u.RepositoryAsync<ParameterGetal>())
                .Return(parametergetalrepository);
            parametergetalrepository.Stub(r => r.Query(ReferentieBuilder.DatumExpression))
                .Return(datefluent);
            parametergetalrepository.Stub(r => r.Query(ReferentieBuilder.OrderTellerExpression))
                .Return(tellerfluent);
            datefluent.Stub(q => q.Select())
                .Return(dateParameterGetallen);
            tellerfluent.Stub(q => q.Select())
                .Return(tellerParameterGetallen);
        }
        [Test]
        public void GetFirstReferentieOfDay_returnsCorrectReferentie()
        {
            ReferentieBuilder referentieBuilder = new ReferentieBuilder(_unitOfWork);
            string prefix = "P";
            DateTime today = DateTime.Today;
            string correctReferentie = string.Format("{0}{1:yyyyMMdd}.01", prefix, today);
            Assert.AreEqual(correctReferentie,referentieBuilder.GetReferentie(prefix), "Wrong First Referentie");
        }
        [Test]
        public void GetSecondReferentieOfDay_returnsCorrectReferentie()
        {
            ReferentieBuilder referentieBuilder = new ReferentieBuilder(_unitOfWork);
            string prefix = "P";
            referentieBuilder.GetReferentie(prefix);
            DateTime today = DateTime.Today;
            string correctReferentie = string.Format("{0}{1:yyyyMMdd}.02", prefix, today);
            Assert.AreEqual(correctReferentie,referentieBuilder.GetReferentie(prefix), "Wrong Second Referentie");
        }
        [Test]
        public void GetThirdReferentieOfDay_returnsCorrectReferentie()
        {
            ReferentieBuilder referentieBuilder = new ReferentieBuilder(_unitOfWork);
            string prefix = "P";
            referentieBuilder.GetReferentie(prefix);
            referentieBuilder.GetReferentie(prefix);
            DateTime today = DateTime.Today;
            string correctReferentie = string.Format("{0}{1:yyyyMMdd}.03", prefix, today);
            Assert.AreEqual(correctReferentie, referentieBuilder.GetReferentie(prefix), "Wrong Second Referentie");
        }
    }
