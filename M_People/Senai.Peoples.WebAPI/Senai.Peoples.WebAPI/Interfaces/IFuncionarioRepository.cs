using Senai.Peoples.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebAPI.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> Listar();

        void Cadastrar(FuncionarioDomain funcionario);

        void Deletar(int id);

        FuncionarioDomain BuscarPorId(int id);

        void AtualizarIdUrl(int id, FuncionarioDomain funcionario);

    }
}
