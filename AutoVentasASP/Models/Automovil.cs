using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutoVentasASP.Models
{
    public class Automovil
    {
        [Key]
        public int idAutomovil { get; set; }
        [Display(Name = "Marca")]
        [Required(ErrorMessage = "El campo marca es obligatorio.")]
        public String marca { get; set; }
        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "El campo modelo es obligatorio.")]
        public String modelo { get; set; }
        [Display(Name = "Color")]
        [Required(ErrorMessage = "El campo color es obligatorio.")]
        public String color { get; set; }
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo precio es obligatorio.")]
        public int precio { get; set; }
        public virtual List<Archivo> archivos { get; set; }
        public virtual List<Compra> compra { get; set; }
        public virtual List<Venta> venta { get; set; }
        

    }
}