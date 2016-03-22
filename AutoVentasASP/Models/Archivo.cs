using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutoVentasASP.Models
{
    public class Archivo
    {
        [Key]
        public int idArchivo { get; set; }
        public String nombre { get; set; }
        public String contentType { get; set; }
        public FileType tipo { get; set; }
        public byte[] contenido { get; set; }
        public virtual Automovil automovil { get; set; }
    }
}