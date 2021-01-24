                auto handle = CreateEvent(NULL, TRUE, FALSE, CString("MyEvent"));
                if (handle != NULL)
                {
                    HANDLE handles[] = { handle };
                    hr = prescOverview->ShowOverviewDialog((long)handle);
                    auto handleCount = _countof(handles);
                    if (SUCCEEDED(hr))
                    {
                        BOOL running = TRUE;
                        do {
                            DWORD const res = ::MsgWaitForMultipleObjectsEx(
                                handleCount,
                                handles,
                                INFINITE,
                                QS_ALLINPUT,
                                MWMO_INPUTAVAILABLE | MWMO_ALERTABLE);
                            if (res == WAIT_FAILED)
                            {
                                running = FALSE;
                                hr = GetLastError();
                                break;
                            }
                            else if (res == WAIT_OBJECT_0 + 0)
                            {
                                CComBSTR err;
                                prescOverview->GetError(&err);
                                CString errContainer(err);
                                if (errContainer.GetLength() > 0)
                                {
									// log
                                    hr = E_FAIL;
                                }
                                else {
                                    hr = S_OK;
                                }
                                running = FALSE;
                                break;
                            }
                            else if (res >= WAIT_OBJECT_0 && res <= WAIT_OBJECT_0 + handleCount)
                            {
                                // process messages.
                                MSG msg;
                                while (PeekMessage(&msg, NULL, 0, 0, PM_REMOVE))
                                {
                                    if (msg.message == WM_QUIT)
                                    {
                                        PostQuitMessage(static_cast<int>(msg.wParam));
                                        hr = ERROR_CANCELLED;
                                        running = FALSE;
                                        break;
                                    }
                                    else {
                                        TranslateMessage(&msg);
                                        DispatchMessage(&msg);
                                    }
                                }
                                
                            }
                        } while (running);
                    }
                    CloseHandle(handle);
                }
			}
