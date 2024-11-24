using Biblioteca.Model;

namespace Biblioteca
{
    public partial class frmBiblioteca : Form
    {
        public frmBiblioteca()
        {
            InitializeComponent();
        }

        private void frmBiblioteca_Load(object sender, EventArgs e)
        {
            btnCadastrarLivro.Enabled = false;
            btnCadastrarUsuario.Enabled = false;
            btnEmprestarLivro.Enabled = false;
        }

        private void txtNomeUsuario_TextChanged(object sender, EventArgs e)
        {
            VerificarCaixasUsuario();
        }

        private void txtCpfUsuario_TextChanged(object sender, EventArgs e)
        {
            VerificarCaixasUsuario();
        }

        private void VerificarCaixasUsuario()
        {
            if (!string.IsNullOrEmpty(txtNomeUsuario.Text) && !string.IsNullOrEmpty(txtCpfUsuario.Text))
                btnCadastrarUsuario.Enabled = true;
            else
                btnCadastrarUsuario.Enabled = false;
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            string nome = txtNomeUsuario.Text;
            string cpf = txtCpfUsuario.Text;
            string telefone = txtTelefoneUsuario.Text;

            Usuario usuario = new Usuario(nome, cpf, telefone);
            lstUsuarios.Items.Add(usuario.ToString());
            LimparCaixasUsuario();
        }

        private void LimparCaixasUsuario()
        {
            txtNomeUsuario.Clear();
            txtCpfUsuario.Clear();
            txtTelefoneUsuario.Clear();
        }

        private void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUsuarios.SelectedIndex >= 0)
            {
                string[] itens = lstUsuarios.GetItemText(lstUsuarios.SelectedItem).Split(" - ");
                txtNomeUsuario.Text = itens[0];
                txtCpfUsuario.Text = itens[1];
                btnEmprestarLivro.Enabled = true;
            }
        }

        private void txtTituloLivro_TextChanged(object sender, EventArgs e)
        {
            VerificarCaixasLivro();
        }

        private void txtAutorLivro_TextChanged(object sender, EventArgs e)
        {
            VerificarCaixasLivro();
        }

        private void VerificarCaixasLivro()
        {
            if (!string.IsNullOrEmpty(txtTituloLivro.Text) && !string.IsNullOrEmpty(txtAutorLivro.Text))
                btnCadastrarLivro.Enabled = true;
            else
                btnCadastrarLivro.Enabled = false;
        }

        private void btnCadastrarLivro_Click(object sender, EventArgs e)
        {
            string titulo = txtTituloLivro.Text;
            string autor = txtAutorLivro.Text;
            string isbn = txtIsbnLivro.Text;
            string tipo = cmbTipoLivro.SelectedItem.ToString();

            Livro livro = tipo == "Físico"
                ? new LivroFisico(titulo, autor, isbn, "Localização Exemplo")
                : new Ebook(titulo, autor, isbn, "Formato PDF");

            lstLivros.Items.Add($"{livro.Titulo} - {livro.Autor}");
            LimparCaixasLivro();
        }

        private void LimparCaixasLivro()
        {
            txtTituloLivro.Clear();
            txtAutorLivro.Clear();
            txtIsbnLivro.Clear();
            cmbTipoLivro.SelectedIndex = -1;
        }

        private void btnEmprestarLivro_Click(object sender, EventArgs e)
        {
            if (lstUsuarios.SelectedIndex >= 0 && lstLivros.SelectedIndex >= 0)
            {
                string[] usuarioDados = lstUsuarios.GetItemText(lstUsuarios.SelectedItem).Split(" - ");
                string[] livroDados = lstLivros.GetItemText(lstLivros.SelectedItem).Split(" - ");

                Usuario usuario = new Usuario(usuarioDados[0], usuarioDados[1], "");
                Livro livro = new LivroFisico(livroDados[0], livroDados[1], "123", "Localização Exemplo"); // Exemplo

                Emprestimo emprestimo = new Emprestimo(livro, usuario);
                lstEmprestimos.Items.Add($"{usuario.Nome} - {livro.Titulo} - {emprestimo.DataEmprestimo.ToShortDateString()}");
                MessageBox.Show($"Livro '{livro.Titulo}' emprestado para '{usuario.Nome}'");
            }
        }
    }
}