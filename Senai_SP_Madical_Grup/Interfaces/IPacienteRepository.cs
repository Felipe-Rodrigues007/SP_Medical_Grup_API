using Senai_SP_Madical_Grup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SP_Madical_Grup.Interfaces
{
    interface IPacienteRepository
    {
        List<Paciente> ListarTodos();
        void Cadastrar(Paciente novoPaciente);
        void Deletar(int id);
        void Atualizar(int id, Paciente attPaciente);
        Paciente BuscarPorId(int id);
    }
}
