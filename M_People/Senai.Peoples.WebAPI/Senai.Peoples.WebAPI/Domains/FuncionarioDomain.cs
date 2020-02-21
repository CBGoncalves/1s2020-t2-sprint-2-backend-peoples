using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebAPI.Domains
{
    public class FuncionarioDomain
    {
        public int IdFuncionario { get; set; }
        [Required(ErrorMessage = "Nome do usuario obrigatório")]

        public string Nome { get; set; }
        [Required(ErrorMessage = "Sobrenome do usuario obrigatório")]

        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Data de Nascimento do usuario obrigatória")]

        public DateTime DataNascimento { get; set; } 
    }
}
