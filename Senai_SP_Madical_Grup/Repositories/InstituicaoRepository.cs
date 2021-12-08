using Microsoft.EntityFrameworkCore;
using Senai_SP_Madical_Grup.Contexts;
using Senai_SP_Madical_Grup.Domains;
using Senai_SP_Madical_Grup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SP_Madical_Grup.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        SpMedicalContext ctx = new SpMedicalContext();

        public void Atualizar(int id, Instituicao attClinica)
        {
            Instituicao clinicaBuscada = BuscarClinica(id);
            if (attClinica.Endereco != null || attClinica.Cnpj != null || attClinica.NomeInstuicao != null || attClinica.RazaoSocial != null)
            {
                clinicaBuscada.Endereco = attClinica.Endereco;
                clinicaBuscada.Cnpj = attClinica.Cnpj;
                clinicaBuscada.NomeInstuicao = attClinica.NomeInstuicao;
                clinicaBuscada.RazaoSocial = attClinica.RazaoSocial;

                ctx.Instituicaos.Update(clinicaBuscada);

                ctx.SaveChanges();
            }
        }

        public Instituicao BuscarClinica(int id)
        {
            return ctx.Instituicaos.FirstOrDefault(c => c.IdInstituicao == id);
        }

        public void CadastrarClinica(Instituicao novaClinica)
        {
            ctx.Instituicaos.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Instituicaos.Remove(BuscarClinica(id));

            ctx.SaveChanges();
        }

        public List<Instituicao> ListarTodas()
        {
            return ctx.Instituicaos
                    .AsNoTracking()
                    .Select(c => new Instituicao
                    {
                        Cnpj = c.Cnpj,
                        Endereco = c.Endereco,
                        NomeInstuicao = c.NomeInstuicao,
                        Medicos = ctx.Medicos.Where(m => m.IdInstituicao == c.IdInstituicao).ToList()
                    })
                    .ToList();
        }
    }
}
