using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Biblioteca.Model
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

        public Usuario(string nome, string cpf, string telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
        }

        public override string ToString()
        {
            return $"{Nome} - {Cpf}";
        }
    }
}
