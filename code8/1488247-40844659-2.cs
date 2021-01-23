    // Fourth variant - decoupled
    // the reader is not really needed for this example...
    public class DataReader_4 : IDataReader<ReaderParamModel, ReadResultModel>
    {
        public ReadResultModel Get(ReaderParamModel param) { return null; }
    }
    public abstract class BaseReportService_4<TReaderParam, TReadResult>
        where TReaderParam : IReadParamModel
        where TReadResult : IReadResultModel
    {
        // reader is interface, can be assigned from DataReader_4 or different implementations
        protected IDataReader<TReaderParam, TReadResult> reader;
        // input is concrete class, reader.Get result is concrete class
        protected virtual TReadResult Test(TReaderParam param)
        {
            var result = reader.Get(param);
            return result;
        }
    }
    public class ReportService_4 : BaseReportService_4<ReaderParamModel, ReadResultModel>
    {
        // input is concrete class, reader.Get result is concrete class
        protected override ReadResultModel Test(ReaderParamModel param)
        {
            var result = reader.Get(param);
            return result;
        }
    }
