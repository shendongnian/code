     .OutCallback((double d1,
                      double d2,
                      double d3,
                      out double v1,
                      out double v2,
                      out double v3) =>
                     {
                       v1 = 15;
                       v2 = 1000;
                       v3 = 500;
                     }).Returns(IFwCompressor.CalculationResult.MaxRps);.OutCallback((double d1,
                      double d2,
                      double d3,
                      out double v1,
                      out double v2,
                      out double v3) =>
                     {
                       v1 = 15;
                       v2 = 1000;
                       v3 = 500;
                     }).Returns(IFwCompressor.CalculationResult.MaxRps);
    namespace MoqExtensions
    {
    using Moq.Language;
    using Moq.Language.Flow;
    using System.Reflection;
    public static class MoqExtensions
    {
        public delegate void OutAction<TOut>(out TOut outVal);
        public delegate void OutAction<in T1, TOut>(T1 arg1, out TOut outVal);
        public delegate void OutAction<in T1, TOut1, TOut2>(T1 arg1, out TOut1 outVal1, out TOut2 outVal2);
        public delegate void OutAction<in T1, in T2, in T3, TOut1, TOut2, TOut3>(T1 arg1, T2 arg2, T3 agr3, out TOut1 outVal1, out TOut2 outVal2, out TOut3 outVal3);
        public static IReturnsThrows<TMock, TReturn> OutCallback<TMock, TReturn, TOut>(this ICallback<TMock, TReturn> mock, OutAction<TOut> action)
            where TMock : class
        {
            return OutCallbackInternal(mock, action);
        }
        public static IReturnsThrows<TMock, TReturn> OutCallback<TMock, TReturn, T1, T2, T3, TOut1, TOut2, TOut3>(this ICallback<TMock, TReturn> mock, OutAction<T1, T2, T3, TOut1, TOut2, TOut3> action)
        where TMock : class
        {
            return OutCallbackInternal(mock, action);
        }
        public static IReturnsThrows<TMock, TReturn> OutCallback<TMock, TReturn, T1, TOut1, TOut2>(this ICallback<TMock, TReturn> mock, OutAction<T1, TOut1, TOut2> action)
            where TMock : class
        {
            return OutCallbackInternal(mock, action);
        }
        public static IReturnsThrows<TMock, TReturn> OutCallback<TMock, TReturn, T1, TOut>(this ICallback<TMock, TReturn> mock, OutAction<T1, TOut> action)
            where TMock : class
        {
            return OutCallbackInternal(mock, action);
        }
        private static IReturnsThrows<TMock, TReturn> OutCallbackInternal<TMock, TReturn>(ICallback<TMock, TReturn> mock, object action)
            where TMock : class
        {
            mock.GetType()
                .Assembly.GetType("Moq.MethodCall")
                .InvokeMember("SetCallbackWithArguments", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, mock,
                    new[] { action });
            return mock as IReturnsThrows<TMock, TReturn>;
        }
    }
}
