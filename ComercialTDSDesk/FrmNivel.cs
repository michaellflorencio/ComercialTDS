using ComercialTDSClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComercialTDSDesk
{
    public partial class FrmNivel : Form
    {
        public FrmNivel()
        {
            InitializeComponent();
        }

        private void DgvNiveis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Nivel nivel = new(txtNome.Text, label2.Text);
            nivel.Inserir();
            if (nivel.Id > 0)
            {
                MessageBox.Show($"Nível cadastrado com sucesso ");
                FrmNivel_Load(sender, e);
            }
        }

        private void FrmNivel_Load(object sender, EventArgs e)
        {
            var niveis = Nivel.ObterLista();
            int linha = 0;
            DgvNiveis.Rows.Clear();
            foreach (var nivel in niveis)
            {
                DgvNiveis.Rows.Add();
                DgvNiveis.Rows[linha].Cells[0].Value = nivel.Id;
                DgvNiveis.Rows[linha].Cells[1].Value = nivel.Nome;
                DgvNiveis.Rows[linha].Cells[2].Value = nivel.Sigla;
                linha++;
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
        }

        private void FrmNivel_Load_1(object sender, EventArgs e)
        {

        }

        private void dgvNiveis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // recuperando o indice da linha grid
            int linha = DgvNiveis.CurrentRow.Index;
            // recuperando o id do nivel na coluna, oculta, ID (0)
            int id = Convert.ToInt32(DgvNiveis.Rows[linha].Cells[0].Value);
            // obter o objeto nivel
            var nivel = Nivel.ObterPorId(id);
            // atribuindo os dados aos controles
            txtId.Text = nivel.Id.ToString();
            txtNome.Text = nivel.Nome;
            txtSigla.Text = nivel.Sigla;
            txtNome.ReadOnly = true;
            txtSigla.ReadOnly = true;
            txtNome.ReadOnly = true;

            //MessageBox.Show($"Nível: {nivel.Nome} {nivel.Sigla}");

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNome.ReadOnly = false;
            txtSigla.ReadOnly = false;
            btnEditar.Enabled = false;
            btnGravar.Enabled = true;
        }

        private void LimpaControle()
        {
            txtId.Clear();
            txtNome.Clear();
            txtSigla.Clear();
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            if (txtId.Text == string.Empty)
            {
                if (txtNome.Text != string.Empty && txtSigla.Text != string.Empty)
                {
                    Nivel nivel = new(txtNome.Text, txtSigla.Text);
                    nivel.Inserir();
                    if (nivel.Id > 0)
                    {
                        MessageBox.Show($"Nível cadastrado com sucesso ");
                        FrmNivel_Load(sender, e);
                        btnGravar.Enabled = false;
                    }
                }
            }
            else
            {
                Nivel nivel = new(int.Parse(txtId.Text), txtNome.Text, txtSigla.Text);
                MessageBox.Show("Nivel atualizado com sucesso");
            }
        }
    }
}