    public class GAMonthlyAPIController
    {
        private readonly IGAMonthlySQLReader gaMonthlySqlReader;
        public GAMonthlyAPIController(IGAMonthlySQLReader gaMonthlySqlReader)
        {
            this.gaMonthlySqlReader = gaMontlySqlReader 
                ?? throw new ArgumentNullException(nameof(gaMontlySqlReader));
        }
        // implementation of controller...
    }
