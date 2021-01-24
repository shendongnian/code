    public ref class CPlusClass
    {
       public:
       void PerformJob(System::Action<System::String^>^ del)
       {
           del->Invoke(gcnew String("Hello World"));
       }
    };
