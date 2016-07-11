using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppBienesRaices.Models
{
    [Table("Bien")]
    public class Bien
    {
        public int ID { get; set; }

        public bool Type { get; set; }

        [StringLength(25)]
        public string City { get; set; }


        public string Adress { get; set; }

        [StringLength(12)]
        public string DateWhenPublish { get; set; }

        public double OriginalPrice { get; set; }

        public double NewPrice { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }
    }
}