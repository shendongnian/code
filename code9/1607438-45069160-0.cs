         public void Eliminar(int id)
        {
            var resp = BaseDatos.Proveedor.Where(x => x.Medicamento.Any());
            var proveedoresParaEliminar = BaseDatos.Proveedor.Where(p => 
            p.IdProveedor == id);
            foreach (var item in proveedoresParaEliminar)
            {             
                    BaseDatos.Proveedor.Remove(item);               
            }
            BaseDatos.SaveChanges();
        }
