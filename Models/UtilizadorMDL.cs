using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BioCenas.Models
{
    public class UtilizadorMDL
    {
        public int ID_Utilizador { get; set; }
        public string Nome { get; set; }
        public int ID_RestricaoAlimentar { get; set; }
        public int ID_Morada { get; set; }     
     }
}
