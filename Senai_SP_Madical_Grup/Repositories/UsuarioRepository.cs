using Senai_SP_Madical_Grup.Contexts;
using Senai_SP_Madical_Grup.Domains;
using Senai_SP_Madical_Grup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SP_Madical_Grup.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedicalContext ctx = new SpMedicalContext();
        public void Atualizar(int id, Usuario userUpd)
        {
            Usuario userBuscado = BuscarPorId(id);

            if (userUpd.NomeUsuario != null || userUpd.SenhaUsuario != null || userUpd.EmailUsuario != null)
            {
                userBuscado.NomeUsuario = userUpd.NomeUsuario;
                userBuscado.EmailUsuario = userUpd.EmailUsuario;
                userBuscado.SenhaUsuario = userUpd.SenhaUsuario;

                ctx.Usuarios.Update(userBuscado);

                ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUser)
        {
            ctx.Usuarios.Add(novoUser);

            ctx.SaveChanges();
        }

        

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Usuario> ListarUsuarios()
        {
            return ctx.Usuarios
                 .Select(u => new Usuario
                 {
                     EmailUsuario = u.EmailUsuario,
                     NomeUsuario = u.NomeUsuario,
                     IdTipoUsuarioNavigation = new TipoUsuario()
                     {
                         TituloTipoUsuario = u.IdTipoUsuarioNavigation.TituloTipoUsuario
                     }
                 })
                 .ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.EmailUsuario == email && e.SenhaUsuario == senha);
        }
    }
}
