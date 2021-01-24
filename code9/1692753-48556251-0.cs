    private void txtOrder_KeyDown(object sender, KeyEventArgs e)
            {
                sqlconnection = new SqlConnection(@"server= KAASH-AV-SRV; database=mamlakalab; Integrated Security=true; ");
    
                if (checkInitialResult.Checked == true && checkApproveResult.Checked == false && txtOrder.Text != string.Empty && e.KeyCode == Keys.Enter )
                {
                    dgvResult.DataSource = result.GetOrderForResult(txtOrder.Text);
    
                    comboMachines.DataSource = result.GET_RESULT_MACHINES(txtOrder.Text);
                    comboMachines.DisplayMember = "MACHINE NAME";
                    comboMachines.ValueMember = "machine_id";
                }
    }
