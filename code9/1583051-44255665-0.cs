      List<Object> products = ((IEnumerable)dgvPapers.DataSource).Cast<object>().ToList();
      List<ContractPaperStepDTO> altered = new List<ContractPaperStepDTO>();
      foreach (var item in products)
      {
        altered.Add((ContractPaperStepDTO)item);
      }
      altered = altered.Where(c => c.PaperName.ToLower().Contains(tbSearchContracts.Text.ToLower())).ToList();
      dgvPapers.DataSource = altered;
      dgvPapers.Update();
    }
