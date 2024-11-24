using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model
{
    public class Emprestimo
    {
        public Livro LivroEmprestado { get; private set; }
        public Usuario Usuario { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime? DataDevolucao { get; private set; }

        public Emprestimo(Livro livro, Usuario usuario)
        {
            LivroEmprestado = livro;
            Usuario = usuario;
            DataEmprestimo = DateTime.Now;
        }

        public void DevolverLivro()
        {
            DataDevolucao = DateTime.Now;
            LivroEmprestado.Devolver();
        }
    }
}

