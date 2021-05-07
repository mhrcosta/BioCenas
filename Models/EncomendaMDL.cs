using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BioCenas.Models
{
    public class EncomendaMDL { 


         [Key]
        public int ID_Encomenda { get; set; }
        public int ID_DescritivoEncomenda { get; set; }
        public int ID_Cliente { get; set; }
        public string ID_LocalEntrega{ get; set; }
        public DateTime DataEntrega { get; set; }
    }
}

