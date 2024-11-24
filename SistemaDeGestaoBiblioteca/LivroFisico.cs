using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model
{
    public class LivroFisico : Livro
    {
        public string Localizacao { get; set; }

        public LivroFisico(string titulo, string autor, string isbn, string localizacao)
            : base(titulo, autor, isbn)
        {
            Localizacao = localizacao;
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
                throw new InvalidOperationException("Este livro já está emprestado.");
            }
        }
    }
}
