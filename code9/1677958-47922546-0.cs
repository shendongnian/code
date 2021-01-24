            case 1:
                TimeSpan sum;
                for (int i = 0; i < this.dataGridView1.NewRowIndex; i++)
                {
                    var value = this.dataGridView1[1, i].Value;
                    if (value is TimeSpan)
                    {
                        sum += ((TimeSpan)value);
                    }
                }
                e.Value = "Saldo: " + sum;
            break;
