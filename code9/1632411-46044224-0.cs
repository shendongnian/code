        int i;
        bool found = false;
        double lucro = 0;
        for (i = 0; i < viaturas.NumElementos; i++)
            if (viaturas.get(i).CVTipoVeículo == Int32.Parse(cbtipoveiculo.Text))
            {
                if (viaturas.get(i).CVDataVenda.Year == Int32.Parse(tbanopesquisa.Text))
                {
                    double a = viaturas.get(i).CVPreçoVenda;
                    double b = viaturas.get(i).CVPreçoAquisição;
                    lucro += a - b; // Add it instead of overwriting
                    found = true;
                    //falta-me pô-lo a somar todos os lucros.
                   
                }
            }
    // Show a MessageBox here with a text (Sorry, I don't speak your language) that outputs your 'lucro' variable
