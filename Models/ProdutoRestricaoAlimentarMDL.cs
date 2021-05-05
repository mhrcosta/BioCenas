using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BioCenas.Models
{
    public class ProdutoRestricaoAlimentarMDL
    {
        public int ID_ProdutoRestricaoAlimentar { get; set; }
        public int ID_Produto { get; set; }
        public int ID_RestricaoAlimentar { get; set; }


    }
}
