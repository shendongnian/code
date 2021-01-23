    public ref class MockTdcConnector : public ITdcConnector
    {
    public:
        virtual Void Close(UInt32);
        virtual Void FetchRequestAsync(ManagedFetchRequest^);
        virtual UInt32 Open(String^, Action<UInt32, ManagedFetchResponse^>^
          [Runtime::InteropServices::Out] Int64%);
    };
