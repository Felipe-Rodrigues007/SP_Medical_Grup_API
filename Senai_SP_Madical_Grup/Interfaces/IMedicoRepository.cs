using Senai_SP_Madical_Grup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SP_Madical_Grup.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> ListarTodos();

        void Cadastrar(Medico novoMedico);
    }
}
