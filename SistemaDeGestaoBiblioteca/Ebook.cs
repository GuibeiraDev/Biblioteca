using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model
{
    public class Ebook : Livro
    {
        public string FormatoArquivo { get; set; }

        public Ebook(string titulo, string autor, string isbn, string formatoArquivo)
            : base(titulo, autor, isbn)
        {
            FormatoArquivo = formatoArquivo;
        }

        public override void Emprestar(Usuario usuario)
        {
            if (!EstaEmprestado)
            {
                EstaEmprestado = true;
                usuario.Emprestimos.Add(new Emprestimo(this, usuario));
            }
            else
            {
                throw new InvalidOperationException("Este e-book já está emprestado.");
            }
        }
    }
}
