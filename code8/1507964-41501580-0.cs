    public enum MethodAttributes
    {
        // NOTE: This Enum matchs the CorMethodAttr defined in CorHdr.h
 
        // member access mask - Use this mask to retrieve accessibility information.
        MemberAccessMask    =   0x0007,
        PrivateScope        =   0x0000,     // Member not referenceable.
        Private             =   0x0001,     // Accessible only by the parent type.  
        FamANDAssem         =   0x0002,     // Accessible by sub-types only in this Assembly.
        Assembly            =   0x0003,     // Accessibly by anyone in the Assembly.
        Family              =   0x0004,     // Accessible only by type and sub-types.    
        FamORAssem          =   0x0005,     // Accessibly by sub-types anywhere, plus anyone in assembly.
        Public              =   0x0006,     // Accessibly by anyone who has visibility to this scope.    
        // end member access mask
        ...
