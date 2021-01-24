    GRBLinExpr[,] sumPj = new GRBLinExpr [M,C];
    for (int m = 0; m < M; m++)                       
    {
            
    for (int i = 0; i < C; i++)
        {
            sumPj[m,i] = 0;
            foreach (int p in VehicleList[m])
            {
                sumPj[m,i].AddTerm(a[i].Column[p], z[p]);
            }
            master.AddConstr(sumPj[m,i] <= y[m], "tj" + m + "," + i);
        }
    }
