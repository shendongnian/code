    HRESULT STDMETHODCALLTYPE
    ClrDataTypeDefinition::GetCorElementType(
        /* [out] */ CorElementType *type)
    {
        HRESULT status;
    
        DAC_ENTER_SUB(m_dac);
    
        EX_TRY
        {
            if (m_typeHandle.IsNull())
            {
                status = E_NOTIMPL;
            }
            else
            {
                *type = m_typeHandle.GetInternalCorElementType();
                status = S_OK;
            }
        }
        EX_CATCH
        {
            if (!DacExceptionFilter(GET_EXCEPTION(), m_dac, &status))
            {
                EX_RETHROW;
            }
        }
        EX_END_CATCH(SwallowAllExceptions)
    
        DAC_LEAVE();
        return status;
    }
