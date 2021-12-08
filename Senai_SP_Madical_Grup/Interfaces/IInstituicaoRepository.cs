using Senai_SP_Madical_Grup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SP_Madical_Grup.Interfaces
{
    interface IInstituicaoRepository
    {
        void CadastrarClinica(Instituicao novaClinica);

        void Atualizar(int id, Instituicao attClinica);

        List<Instituicao> ListarTodas();

        void Deletar(int id);

        Instituicao BuscarClinica(int id);
    }
}
