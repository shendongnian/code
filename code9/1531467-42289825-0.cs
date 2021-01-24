    if (!allCorrect[i])
                {
                    if (int.TryParse(parameters[i], out INT))
                    {
                        if (_command.ParameterTypes[i] == EVariableType.INT)
                        {
                            allCorrect[i] = true;
                        }
                        else
                        {
                            allCorrect[i] = false;
                        }
                    }
                }
                if (!allCorrect[i])
                {
                    if (float.TryParse(parameters[i], out FLOAT))
                    {
                        if (_command.ParameterTypes[i] == EVariableType.FLOAT)
                        {
                            allCorrect[i] = true;
                        }
                        else
                        {
                            allCorrect[i] = false;
                        }
                    }
                }
                if (!allCorrect[i])
                {
                    if (parameters[i] == "0" ||
                    parameters[i] == "1" ||
                    parameters[i].ToLower() == "false" ||
                    parameters[i].ToLower() == "true")
                    {
                        if (_command.ParameterTypes[i] == EVariableType.BOOL)
                        {
                            allCorrect[i] = true;
                        }
                        else
                        {
                            allCorrect[i] = false;
                        }
                    }
                }
                if (!allCorrect[i])
                {
                    if (_command.ParameterTypes[i] == EVariableType.STRING)
                    {
                        allCorrect[i] = true;
                    }
                    else
                    {
                        allCorrect[i] = false;
                    }
                }
