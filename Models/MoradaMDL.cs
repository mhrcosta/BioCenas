using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BioCenas.Models
{
    public class MoradaMDL
    {

        [Key] 
        public int ID_Morada { get; set; }
        public string Morada { get; set; }
        public string CodigoPostal { get; set; }

    }
}
