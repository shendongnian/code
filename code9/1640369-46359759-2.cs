    class OurException {
      virtual void handle() = 0;
    };
    class SpecialCaseException : public OurException {
      static const int code = NNN;
      virtual void handle() {
         // do what you need to
      }
    };
