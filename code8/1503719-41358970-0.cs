    using namespace System;
    namespace ClassLibrary1 {
	public ref class Class1
	{
		// TODO: Add your methods for this class here.
	public:
		void ThrowException()
		{
			int * p = (int*)-1;
			*p = 10;
		}
	};
