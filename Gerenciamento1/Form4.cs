using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciamento1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Digite o Nome do Produto!");
            }
            else if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("Digite o Preço!");
            }
            else if(!double.TryParse(textBox3.Text, out double preco))
            {
                MessageBox.Show("Digite um Valor Numérico no Preço");
            }
            else if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Digite a Descrição!");
            }
            else
            {

                String nome = textBox1.Text;
                String descricao = textBox2.Text;

                Conexao conexao = new Conexao();
                conexao.AbrirConexao();

                string consulta = "INSERT INTO Produto (nomeProduto, Preco, Descricao) VALUES ('" + nome + "', " + preco + ", '" + descricao + "')";
                conexao.ExecutarQuery(consulta);

                conexao.FecharConexao();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

                Form2 form = new Form2();
                // _form2.CarregaGrid2();

                MessageBox.Show("Produto Cadastrado Com Sucesso!");
            }
        }
    }
}
