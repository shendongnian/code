    DT.Rows.Add(); //Add new line to get last line of table without errors
            DT.Rows.Add(); //Add new line to get last line of table without errors
            DT.Columns.Add(); //Add new column to get last column wihout errors
            DT.Columns.Add();//Add new column to get last column wihout errors
            //Array to know when start and end etch table
            int[,] TablesIndex = new int[1, 6]; //Array to save matriz of each table
            //[X,0] = Coluna inicial
            //[X,1] = Linha inicial
            //[X,2] = Coluna final
            //[X,3] = Linha final
            int x = 1;
            int y = 1;
            bool Entra = true;
            bool UltimaTabela = false;
            //Get the index of tables
            
            for (int j = 1; j<=DT.Columns.Count-2; j++)
                {
                if ((x == 1) && (y == 1) && (Entra == true))
                {
                    //Coluna inicio
                    TablesIndex[0, 0] = 0;
                    //Linha Inicio
                    TablesIndex[0 , 1] = 4;
                    Entra = false;
                }
                else if (Entra == true)
                {
                    //Coluna Fim tabela anterior
                    TablesIndex[x-1 , 0] = TablesIndex[x-2, 2] + 2;
                    //Linha Inicio
                    TablesIndex[x-1, 1] = 4;
                    Entra = false;
                    
                }
                    if (DT.Rows[5][j - 1].ToString() == "Total")//é sempre o ultima coluna
                    
                {
                    //se nao for a ultima tabela
                    if ((DT.Rows[5][j].ToString() == "")&&(DT.Rows[5][j + 1].ToString() != ""))
                    {
                        //Coluna Fim
                        TablesIndex[x - 1, 2] = j - 1;
                    }
                    //Se for a ultima tabela 
                    if (DT.Columns.Count - 2 == j)
                    {
                        //Coluna Fim
                        TablesIndex[x - 1, 2] = j-1;
                        UltimaTabela = true;
                    }
                    for (int k =1; k<= DT.Rows.Count; k++)
                    {
                        if((DT.Rows[k][TablesIndex[x-1, 2]].ToString() == "") && (DT.Rows[k-1][TablesIndex[x-1, 2]].ToString() != "") && (DT.Rows[k+1][TablesIndex[x-1, 2]].ToString() == "") || (DT.Columns.Count - 1 == j))
                        {
                            DT.Rows.Add();
                            //Linha Fim
                            TablesIndex[x-1, 3] = k;
                           
                            if (UltimaTabela == false )
                            { 
                            x += 1;
                            int[,] temp = new int[x, 6];
                            if (TablesIndex != null)
                            {
                                Array.Copy(TablesIndex, temp, Math.Min(TablesIndex.Length, temp.Length));
                                TablesIndex = temp;
                                Entra = true;
                            }
                            }
                            break;
                        }
                    
                }
                
                }
           
            }
