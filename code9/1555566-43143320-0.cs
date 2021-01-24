    var cuentas = (from mov in _data.Movimientos.Where(w => w.IsDeleted == 0).GroupBy(g => g.CuentasId)
                  join ct in _data.Cuentas.Where(w => w.IsDeleted == 0).GroupBy(g => new { CuentasId = g.CuentasId, Alias = g.Alias, Monedas = g.Monedas.Nombre, Signo = g.Monedas.Signo, Banco = g.Bancos.Nombre })
                  on mov.Key.CuentasId equals ct.Key.CuentasId
                  select new
                  {
                      Alias = ct.Key.Alias,
                      Moneda = ct.Key.Moneda,
                      Signo = ct.Key.Signo,
                      Banco = ct.Key.Banco,
                      Monto = mov.Sum(s => s.Monto)
                   }
                   ).ToList();
