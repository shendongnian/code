    public class ReferentieBuilder : IReferentieBuilder
    {
        private readonly IUnitOfWorkAsync _unitOfWork;
        private static readonly Expression<Func<ParameterGetal, bool>> _datumExpression = o => o.parameter=="Datum";
        private static readonly Expression<Func<ParameterGetal, bool>> _ordertellerExpression = o => o.parameter == "orderteller";
        public ReferentieBuilder(IUnitOfWorkAsync unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }
            _unitOfWork = unitOfWork;
        }
        public static Expression<Func<ParameterGetal, bool>> DatumExpression
        {
            get { return _datumExpression;}
        }
        public static Expression<Func<ParameterGetal, bool>> OrderTellerExpression
        {
            get { return _ordertellerExpression; }
        }
        public string GetReferentie(string prefix)
        {
            IRepositoryAsync<ParameterGetal> parameterGetalRepository = _unitOfWork.RepositoryAsync<ParameterGetal>();
            Debug.Assert(parameterGetalRepository!=null);
            var dateparameterGetal = parameterGetalRepository
                .Query(DatumExpression)
                .Select()
                .Single();
            var ordertellerparametergetal = parameterGetalRepository
                    .Query(OrderTellerExpression)
                    .Select()
                    .Single();
            DateTime date = DateTime.Parse(dateparameterGetal.parameterwaarde);
            int orderteller=0;
            if (date == DateTime.Today)
            {
                orderteller = int.Parse(ordertellerparametergetal.parameterwaarde); 
            }
            else
            {
                dateparameterGetal.parameterwaarde = string.Format("{0:dd/MM/yyyy}", DateTime.Today);
                orderteller = 0;
            }
            orderteller++;
            ordertellerparametergetal.parameterwaarde = orderteller.ToString();
            string result = string.Format("{0}{1:yyyyMMdd}.{2:00}",prefix,DateTime.Today,orderteller);
            return result;
        }
    }
