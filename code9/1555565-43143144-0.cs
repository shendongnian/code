    var cuentas = (from mov in _data.Movimientos
                   join ct in _data.Cuentas
                   on mov.CuentasId equals ct.CuentasId
                   where ct.IsDeleted == 0 && mov.IsDeleted == 0
                   group mov.Monto by new
                   {
                       CuentasId = ct.CuentasId,
                       Alias = ct.Alias,
                       Moneda = ct.Monedas.Nombre,
                       Signo = ct.Monedas.Signo,
                       Banco = ct.Bancos.Nombre
                   } into ctg
                   select new
                   {
                       Alias = ctg.Key.Alias,
                       Moneda = ctg.Key.Moneda,
                       Signo = ctg.Key.Signo,
                       Banco = ctg.Key.Banco,
                       Monto = ctg.Sum()
                   }).ToList();
