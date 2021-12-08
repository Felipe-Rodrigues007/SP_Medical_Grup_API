using Microsoft.AspNetCore.Http;
using Senai_SP_Madical_Grup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SP_Madical_Grup.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarUsuarios();
        void Cadastrar(Usuario novoUser);
        Usuario Login(string email, string senha);
        void Deletar(int id);
        
        
        Usuario BuscarPorId(int id);
        void Atualizar(int id, Usuario userUpd);
    }
}
