    protected void InjectDetpartment(Department dept,Employee emp)
     {
         if(dept is DeptCode100 dc1)
         {
             dc1.Prop3 = emp.Code;
             dc1.Prop4 = emp.Basic;
         }
         else if(dept is DeptCode200 dc2)
         {
             dc2.Prop5 = emp.Code;
             dc2.Prop6 = emp.Basic;
         }
         else
         {
             dept.Prop1 = emp.Code;
             dept.Prop2 = emp.Basic;
         }
     }
