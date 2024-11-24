using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model
{
    public abstract class Livro : IEmprestavel
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public bool EstaEmprestado { get; private set; }

        public Livro(string titulo, string autor, string isbn)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            EstaEmprestado = false;
        }

        public abstract void Emprestar(Usuario usuario);

        public void Devolver()
        {
            EstaEmprestado = false;
        }
    }
}
