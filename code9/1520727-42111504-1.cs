    private bool mIsImeProcessed = true;
    private bool mIsImeContinue = false;
    case WM_IME_COMPOSITION:
                    {
                        if (mKoreanInput == true)
                        {
                            long lParam = m.LParam.ToInt64();
                            long wParam = m.WParam.ToInt64();
                            char c = (char)m.WParam;
                            if (lParam == 24600)
                            {
                                if (mIsImeProcessed)
                                {
                                    mIsImeProcessed = false;
                                    mIsImeContinue = false;
                                    PassCharToThirdParty(m);
                                }
                                else
                                {
                                    PassCharToThirdPartyWithBackSpace(((char)m.WParam).ToString());
                                }
                                mIsImeContinue = true;
                            }
                        }
                        else if (lParam == 2048)
                        {
                            if (mIsImeProcessed)
                            {
                            }
                            else
                            {
                                if (mIsImeContinue == true)
                                {
                                    PassCharToThirdPartyWithBackSpace(((char)m.WParam).ToString());
                                }
                            }
                            mIsImeProcessed = true;
                        }
                        else
                        {
                                PassBackSpaceToThirdParty();
                        }
                    }
                    break;
    case Common.Interop.Window.WM_IME_ENDCOMPOSITION:
                    if (mKoreanInput == true)
                    {
                        mIsImeProcessed = true;
                        mIsImeContinue = false;
                    }
                    break; 
