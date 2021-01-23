    //GET THE BOXED VALUE FROM THE STACK
    Object* obj = OpStackGet<Object*>(tos);
    
    //GET THE TARGET TYPE METADATA
    unsigned boxTypeTok = getU4LittleEndian(m_ILCodePtr + 1);
    boxTypeClsHnd = boxTypeResolvedTok.hClass;
    boxTypeAttribs = m_interpCeeInfo.getClassAttribs(boxTypeClsHnd);
    
    //IF THE TARGET TYPE IS A REFERENCE TYPE
    //NOTHING CHANGE FROM ABOVE
    if ((boxTypeAttribs & CORINFO_FLG_VALUECLASS) == 0)
    {
        !ObjIsInstanceOf(obj, TypeHandle(boxTypeClsHnd), TRUE)
    }
    //ELSE THE TARGET TYPE IS A REFERENCE TYPE
    else
    {
        unboxHelper = m_interpCeeInfo.getUnBoxHelper(boxTypeClsHnd);
        switch (unboxHelper)
            {
            case CORINFO_HELP_UNBOX:
                    MethodTable* pMT1 = (MethodTable*)boxTypeClsHnd;
                    MethodTable* pMT2 = obj->GetMethodTable();
    
                    if (pMT1->IsEquivalentTo(pMT2))
                    {
                        res = OpStackGet<Object*>(tos)->UnBox();
                    }
                    else
                    {
                        CorElementType type1 = pMT1->GetInternalCorElementType();
                        CorElementType type2 = pMT2->GetInternalCorElementType();
    
                        // we allow enums and their primtive type to be interchangable
                        if (type1 == type2)
                        {
                              res = OpStackGet<Object*>(tos)->UnBox();
                        }
                    }
    
    		//THE RUNTIME DOES NOT KNOW HOW TO UNBOX THIS ITEM
                    if (res == NULL)
                    {
                        COMPlusThrow(kInvalidCastException);
    
                        //I INSERTED THIS COMMENTS
    		    //auto thCastFrom = obj->GetTypeHandle();
    		    //auto thCastTo = TypeHandle(boxTypeClsHnd);
    		    //RealCOMPlusThrowInvalidCastException(thCastFrom, thCastTo);
                    }
                    break;
            case CORINFO_HELP_UNBOX_NULLABLE:
                    InterpreterType it = InterpreterType(&m_interpCeeInfo, boxTypeClsHnd);
                    size_t sz = it.Size(&m_interpCeeInfo);
                    if (sz > sizeof(INT64))
                    {
                        void* destPtr = LargeStructOperandStackPush(sz);
                        if (!Nullable::UnBox(destPtr, ObjectToOBJECTREF(obj), (MethodTable*)boxTypeClsHnd))
                        {
                            COMPlusThrow(kInvalidCastException);
                        //I INSERTED THIS COMMENTS
    		    //auto thCastFrom = obj->GetTypeHandle();
    		    //auto thCastTo = TypeHandle(boxTypeClsHnd);
    		    //RealCOMPlusThrowInvalidCastException(thCastFrom, thCastTo);
                        }
                    }
                    else
                    {
                        INT64 dest = 0;
                        if (!Nullable::UnBox(&dest, ObjectToOBJECTREF(obj), (MethodTable*)boxTypeClsHnd))
                        {
                            COMPlusThrow(kInvalidCastException);
                        //I INSERTED THIS COMMENTS
    		    //auto thCastFrom = obj->GetTypeHandle();
    		    //auto thCastTo = TypeHandle(boxTypeClsHnd);
    		    //RealCOMPlusThrowInvalidCastException(thCastFrom, thCastTo);
                        }
                    }
                }
                break;
            }
    }
