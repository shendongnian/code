    DateTime data = string.IsNullOrEmpty((string)row.Cells["dataDataGridViewTextBoxColumn1"].FormattedValue) ? DateTime.MinValue : Convert.ToDateTime(row.Cells["dataDataGridViewTextBoxColumn1"].Value);
.
    //UPDATE DE LINHA
    DataGridViewRow row = SubProgDGV.Rows[e.RowIndex];
    Guid guid = (Guid)row.Cells["gUIDDataGridViewTextBoxColumn"].Value;
    int cascoid = Convert.ToInt16(row.Cells["cascoIDDataGridViewTextBoxColumn3"].Value);
    string casco = row.Cells["cascoDataGridViewTextBoxColumn11"].Value.ToString();
    int blocoid = Convert.ToInt16(row.Cells["blocoIDDataGridViewTextBoxColumn5"].Value);
    string bloco = row.Cells["blocoDataGridViewTextBoxColumn11"].Value.ToString();
    string sub = row.Cells["subDataGridViewTextBoxColumn1"].Value.ToString();
    string ssub = row.Cells["sSubDataGridViewTextBoxColumn1"].Value.ToString();
    string linha = row.Cells["linhaDataGridViewTextBoxColumn"].Value.ToString();
    int qtd = Convert.ToInt16(row.Cells["quantidadeDataGridViewTextBoxColumn3"].Value);
    double peso = Convert.ToDouble(row.Cells["pesoDataGridViewTextBoxColumn4"].Value);
    DateTime datacmb = Convert.ToDateTime(row.Cells["inicioPlanMontagemDataGridViewTextBoxColumn"].Value);
    string oficina = row.Cells["oficinaDataGridViewTextBoxColumn"].Value.ToString();
    DateTime datasub = Convert.ToDateTime(row.Cells["inicioPlanSubmontagemDataGridViewTextBoxColumn"].Value);
    DateTime datasubfim = Convert.ToDateTime(row.Cells["terminoPlanSubmontagemDataGridViewTextBoxColumn"].Value);
    DateTime datatermino = row.Cells["teminoRealDataGridViewTextBoxColumn"].Value == null ? DateTime.MinValue : Convert.ToDateTime(row.Cells["teminoRealDataGridViewTextBoxColumn"].Value);
    string turno = row.Cells["turnoDataGridViewTextBoxColumn"].Value.ToString();
    string statusproc = row.Cells["statusProcessamentoDataGridViewTextBoxColumn"].Value.ToString();
    string statussub = row.Cells["statusSubDataGridViewTextBoxColumn"].Value.ToString();
    DateTime data = row.Cells["dataDataGridViewTextBoxColumn1"].Value == null ? DateTime.MinValue : Convert.ToDateTime(row.Cells["dataDataGridViewTextBoxColumn1"].Value);
