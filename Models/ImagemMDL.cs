using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BioCenas.Models
{
    public class ImagemMDL
    {
        [Key]
        public int ID_Imagem { get; set; }
        public int ID_Produto { get; set; }

        public String NomeImagem { get; set; }
        public String LocalizacaoImagem { get; set; }

        public String ExtensaoImagem { get; set; }



    }
}
