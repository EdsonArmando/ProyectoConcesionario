using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AutoVentasASP.Models
{
    public partial class DB_CONCESIONARIO:DbContext
    {
        public DB_CONCESIONARIO(): base("name=DB_Concesionario"){}
        public virtual DbSet<Rol> rol { get; set; }
        public virtual DbSet<Archivo> archivo { get; set; }
        public virtual DbSet<Usuario> usuario { get; set; }
        public virtual DbSet<Automovil> automovil { get; set; }
        public virtual DbSet<Compra> compra { get; set; }
        public virtual DbSet<Venta> venta { get; set; }

    }
}