using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //pääavain määrittely
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varastonhallinta
{
    public class Tuote
    {
        [Key]
        public int? id { get; set; }
        
        public string? Tuotenimi { get; set; }

        public string? Tuotenhinta { get; set; }

        public string? Varastosaldo { get; set; }


    }
}
