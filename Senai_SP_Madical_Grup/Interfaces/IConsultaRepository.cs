using Senai_SP_Madical_Grup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SP_Madical_Grup.Interfaces
{
    interface IConsultaRepository
    {
        List<Consultum> ListarTodas();

        List<Consultum> ListarMinhasConsultas(int id, int idTipo);

        void CadastrarConsulta(Consultum novaConsulta);

        void CancelarConsulta(int Id);

        void RemoverConsultaSistema(int id);

        void AlterarDescricao(string descricao, int id);

        Consultum BuscarPorId(int id);
    }
}
