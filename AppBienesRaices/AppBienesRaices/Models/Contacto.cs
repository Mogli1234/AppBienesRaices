using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppBienesRaices.Models
{
    [Table("Contactos")]
    public class Contacto
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 20)]
        [Display(Name = "Nombre Completo")]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 30)]
        [Display(Name = "Mensaje")]
        public string Mensaje { get; set; }
    }
}