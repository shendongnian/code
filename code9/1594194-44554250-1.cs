    #region ==== BORRAR REGISTROS DEL INGRESO ====
    protected void gvw_CliEmp_EmpData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int EmpCliCod = Convert.ToInt32(e.CommandArgument);
            DialogResult dialogResult = MessageBox.Show(new Form { TopMost = true }, "Eliminar?", "Confirmar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                cliEmpBL.clientesEmpleados_SupEmpleado(EmpCliCod); //eliminar desde DL
                Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", "alert('Eliminado!');", true);
            }
            else if (dialogResult == DialogResult.No)
            { }
            gvw_CliEmp_EmpData.DataSource = null;
            gvw_CliEmp_EmpData.DataBind();
            gvw_CliEmp_EmpData.DataSource = cliEmpBL.clientes_Empleados_cons_EmpxCliente(lbl_CliEmp_CliCod.Text);
            gvw_CliEmp_EmpData.DataBind();
        }
    }
    protected void gvw_CliEmp_EmpData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {//this is because grid fired event RowDeleting which wasn't handled
    }
    #endregion
