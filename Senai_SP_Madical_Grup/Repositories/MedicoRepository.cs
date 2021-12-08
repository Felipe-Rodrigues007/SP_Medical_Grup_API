using Senai_SP_Madical_Grup.Contexts;
using Senai_SP_Madical_Grup.Domains;
using Senai_SP_Madical_Grup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SP_Madical_Grup.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SpMedicalContext ctx = new SpMedicalContext();
        public List<Medico> ListarTodos()
        {
            return ctx.Medicos.Select(u => new Medico()
            {
                IdUsuario = u.IdUsuario,
                IdMedico = u.IdMedico,
                IdUsuarioNavigation = new Usuario()
                {
                    NomeUsuario = u.IdUsuarioNavigation.NomeUsuario
                }
            }).ToList();

        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }
    }
}
