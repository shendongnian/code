    public interface IReadParamModel { }
    public interface IReadResultModel { }
    public class ReaderParamModel : IReadParamModel { }
    public class ReadResultModel : IReadResultModel { }
    public interface IDataReader<in TParam, out TResult>
        where TParam : IReadParamModel
        where TResult : IReadResultModel
    {
        TResult Get(TParam param);
    }
    // First variant - much interface usage
    public class DataReader_1 : IDataReader<IReadParamModel, ReadResultModel>
    {
        public ReadResultModel Get(IReadParamModel param) { return null; }
    }
    public abstract class BaseReportService_1<TReader>
        where TReader : IDataReader<IReadParamModel, IReadResultModel>
    {
        protected TReader reader;
        // input is interface, reader.Get result is interface
        protected virtual IReadResultModel Test(IReadParamModel param)
        {
            var result = reader.Get(param);
            return result;
        }
    }
    public class ReportService_1 : BaseReportService_1<DataReader_1>
    {
        // input is interface, reader.Get result is concrete class
        protected override IReadResultModel Test(IReadParamModel param)
        {
            var result = reader.Get(param);
            return result;
        }
    }
    // Second variant - less interface usage, more generic parameters
    public class DataReader_2 : IDataReader<ReaderParamModel, ReadResultModel>
    {
        public ReadResultModel Get(ReaderParamModel param) { return null; }
    }
    public abstract class BaseReportService_2<TReader, TReaderParam>
        where TReader : IDataReader<TReaderParam, IReadResultModel>
        where TReaderParam : IReadParamModel
    {
        protected TReader reader;
        // input is concrete class, reader.Get result is interface
        protected virtual IReadResultModel Test(TReaderParam param)
        {
            var result = reader.Get(param);
            return result;
        }
    }
    public class ReportService_2 : BaseReportService_2<DataReader_2, ReaderParamModel>
    {
        // input is concrete class, reader.Get result is concrete class
        protected override IReadResultModel Test(ReaderParamModel param)
        {
            var result = reader.Get(param);
            return result;
        }
    }
    // Third variant - fully parameterized
    public class DataReader_3 : IDataReader<ReaderParamModel, ReadResultModel>
    {
        public ReadResultModel Get(ReaderParamModel param) { return null; }
    }
    public abstract class BaseReportService_3<TReader, TReaderParam, TReadResult>
        where TReader : IDataReader<TReaderParam, TReadResult>
        where TReaderParam : IReadParamModel
        where TReadResult : IReadResultModel
    {
        protected TReader reader;
        // input is concrete class, reader.Get result is concrete class
        protected virtual TReadResult Test(TReaderParam param)
        {
            var result = reader.Get(param);
            return result;
        }
    }
    public class ReportService_3 : BaseReportService_3<DataReader_3, ReaderParamModel, ReadResultModel>
    {
        // input is concrete class, reader.Get result is concrete class
        protected override ReadResultModel Test(ReaderParamModel param)
        {
            var result = reader.Get(param);
            return result;
        }
    }
