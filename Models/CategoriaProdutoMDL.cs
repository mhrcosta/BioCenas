using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BioCenas.Models
{
    public class CategoriaProdutoMDL
    {
        public int ID_CategoriaProduto { get; set; }
        public int ID_Categoria { get; set; }
        public int ID_Produto{ get; set; }
    }
  
}
