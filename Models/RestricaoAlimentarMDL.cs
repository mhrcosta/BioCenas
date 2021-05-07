using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BioCenas.Models
{
    public class RestricaoAlimentarMDL
    {
        [Key]
        public int ID_RestricaoAlimentar { get; set; }
        public string DesignacaoRestricaoAlimentar { get; set; }
        public string DescricaoRestricaoAlimentar { get; set; }
    }
}
