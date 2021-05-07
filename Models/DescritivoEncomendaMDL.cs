using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BioCenas.Models
{
    public class DescritivoEncomendaMDL
    {//em cada encomenda tenho varios produtos
        [Key]
        public int DescritivoEncomenda { get; set; }
        public int ID_Encomenda { get; set; }
        public int ID_Produto { get; set; }
        public int QTProduto { get; set; }

    }
  
}
