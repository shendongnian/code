            public void GetSettingDisplayTable(DataGridView dataGridView, int height)
        {
            dataGridView.RowTemplate.Height = height; //высота строк
            dataGridView.AllowUserToAddRows = false; //нельзя пользователю добавлять самому строки
            //Как будет отображаться таблица
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Растягивать таблицу (колонки) под окно dataGridView
        }
