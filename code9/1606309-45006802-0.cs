    interface IFace<T, U>
    {
        T ValueOne { get; set; }
        U ValueTwo { get; set; }
    }
    abstract class FaceBase : IFace<object, object>
    {
        public object ValueOne { get; set; }
        public object ValueTwo { get; set; }
        protected FaceBase(object valueOne, object valueTwo)
        {
            ValueOne = valueOne;
            ValueTwo = valueTwo;
        }
    }
    class GenClass<T> where T : FaceBase
    {
        private T Value { get; set; }
        public GenClass()
        {
            // do something with Value.ValueOne or Value.ValueTwo
        }
    }
