using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BioCenas.Models
{
    public class CategoriaMDL
    {
        [Key]
        public int ID_Categoria { get; set; }
        public string DesignacaoCategoria { get; set; }
        public string DescricaoCategoria { get; set; }
              
    }
   
}
