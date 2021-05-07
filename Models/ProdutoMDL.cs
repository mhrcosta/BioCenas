using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BioCenas.Models
{
    public class ProdutoMDL
    {
        [Key]
        public int ID_Produto { get; set; }
        public string DesignacaoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int QTDisponivel { get; set; }

        /* Caso o produto tenha sido descontinuado ou deixou de ser vendido pela loja*/
        public string EstadoProduto { get; set; }
        public int PrecoProduto { get; set; }
        
     

    }
}
