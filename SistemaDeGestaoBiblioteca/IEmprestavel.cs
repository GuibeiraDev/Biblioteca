using Biblioteca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model
{
    public interface IEmprestavel
    {
        void Emprestar(Usuario usuario);
        void Devolver();
    }
}
