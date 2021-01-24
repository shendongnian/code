            case 1:
                TimeSpan sum = TimeSpan.FromHours(0.0);
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
