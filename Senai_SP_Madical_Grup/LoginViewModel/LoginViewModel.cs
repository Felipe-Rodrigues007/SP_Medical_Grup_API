using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SP_Madical_Grup.LoginViewModel
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string SenhaUsuario { get; set; }
    }
}
