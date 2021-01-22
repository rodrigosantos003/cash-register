using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace CaixaRegistadora
{
    public partial class Dados : Form
    {
        #region DB Connection
        string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.GetFullPath(@"../..") + "\\CaixaRegistradora.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection con;
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlDataAdapter sda;
        DataTable dt;
        #endregion
        public Dados()
        {
            InitializeComponent();
        }

        public void ShowData()
        {
            con = new SqlConnection(cs);
            con.Open();
            sda = new SqlDataAdapter("SELECT * FROM [Registo]", con);
            dt = new DataTable();
            sda.Fill(dt);
            dgv_TodosPedidos.DataSource = dt;

            cmd = new SqlCommand("SELECT SUM(Preço) FROM [Registo]", con);
            lbl_TotalGerado.Text = "Total: " + cmd.ExecuteScalar().ToString() + "€";

            con.Close();
        }

        private void Dados_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btn_Doacao_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("SELECT SUM(Preço) FROM [Registo] WHERE Produto LIKE 'Doaçao'", con);
            cmd2 = new SqlCommand("SELECT COUNT(Produto) FROM [Registo] WHERE Produto LIKE 'Doaçao'", con);
            MessageBox.Show("Total: " + cmd.ExecuteScalar().ToString() + "\n" + cmd2.ExecuteScalar().ToString());
            con.Close();
        }

        private void btn_Gomas_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("SELECT SUM(Preço) FROM [Registo] WHERE Produto LIKE 'Gomas'", con);
            cmd2 = new SqlCommand("SELECT COUNT(Produto) FROM [Registo] WHERE Produto LIKE 'Gomas'", con);
            MessageBox.Show("Total: " + cmd.ExecuteScalar().ToString() + "\n" + cmd2.ExecuteScalar().ToString());
            con.Close();
        }

        private void btn_Mousse_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("SELECT SUM(Preço) FROM [Registo] WHERE Produto LIKE 'Mousse de Oreo'", con);
            cmd2 = new SqlCommand("SELECT COUNT(Produto) FROM [Registo] WHERE Produto LIKE 'Mousse de Oreo'", con);
            MessageBox.Show("Total: " + cmd.ExecuteScalar().ToString() + "\n" + cmd2.ExecuteScalar().ToString());
            con.Close();
        }

        private void btn_Waffle_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("SELECT SUM(Preço) FROM [Registo] WHERE Produto LIKE 'Waffle'", con);
            cmd2 = new SqlCommand("SELECT COUNT(Produto) FROM [Registo] WHERE Produto LIKE 'Waffle'", con);
            MessageBox.Show("Total: " + cmd.ExecuteScalar().ToString() + "\n" + cmd2.ExecuteScalar().ToString());
            con.Close();
        }

        private void btn_Sumos_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("SELECT SUM(Preço) FROM [Registo] WHERE Produto LIKE 'Sumo' OR Produto LIKE 'Sumo (Desconto)'", con);
            cmd2 = new SqlCommand("SELECT COUNT(Produto) FROM [Registo] WHERE Produto LIKE 'Sumo' OR Produto LIKE 'Sumo (Desconto)'", con);
            MessageBox.Show("Total: " + cmd.ExecuteScalar().ToString() + "\n" + cmd2.ExecuteScalar().ToString());
            con.Close();
        }

        private void btn_Salame_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("SELECT SUM(Preço) FROM [Registo] WHERE Produto LIKE 'Salame'", con);
            cmd2 = new SqlCommand("SELECT COUNT(Produto) FROM [Registo] WHERE Produto LIKE 'Salame'", con);
            MessageBox.Show("Total: " + cmd.ExecuteScalar().ToString() + "\n" + cmd2.ExecuteScalar().ToString());
            con.Close();
        }

        private void btn_tartePastel_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("SELECT SUM(Preço) FROM [Registo] WHERE Produto LIKE 'Tarte de Pastel'", con);
            cmd2 = new SqlCommand("SELECT COUNT(Produto) FROM [Registo] WHERE Produto LIKE 'Tarte de Pastel'", con);
            MessageBox.Show("Total: " + cmd.ExecuteScalar().ToString() + "\n" + cmd2.ExecuteScalar().ToString());
            con.Close();
        }

        private void btn_tarteAmendoa_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("SELECT SUM(Preço) FROM [Registo] WHERE Produto LIKE 'Tarte de Amendoa'", con);
            cmd2 = new SqlCommand("SELECT COUNT(Produto) FROM [Registo] WHERE Produto LIKE 'Tarte de Amendoa'", con);
            MessageBox.Show("Total: " + cmd.ExecuteScalar().ToString() + "\n" + cmd2.ExecuteScalar().ToString());
            con.Close();
        }

        private void btn_boloBanana_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("SELECT SUM(Preço) FROM [Registo] WHERE Produto LIKE 'Bolo de Banana'", con);
            cmd2 = new SqlCommand("SELECT COUNT(Produto) FROM [Registo] WHERE Produto LIKE 'Bolo de Banana'", con);
            MessageBox.Show("Total: " + cmd.ExecuteScalar().ToString() + "\n" + cmd2.ExecuteScalar().ToString());
            con.Close();
        }

        private void btn_boloIogurte_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("SELECT SUM(Preço) FROM [Registo] WHERE Produto LIKE 'Bolo de Iogurte'", con);
            cmd2 = new SqlCommand("SELECT COUNT(Produto) FROM [Registo] WHERE Produto LIKE 'Bolo de Iogurte'", con);
            MessageBox.Show("Total: " + cmd.ExecuteScalar().ToString() + "\n" + cmd2.ExecuteScalar().ToString());
            con.Close();
        }

        private void btn_boloBolacha_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("SELECT SUM(Preço) FROM [Registo] WHERE Produto LIKE 'Bolo de Bolacha'", con);
            cmd2 = new SqlCommand("SELECT COUNT(Produto) FROM [Registo] WHERE Produto LIKE 'Bolo de Bolacha'", con);
            MessageBox.Show("Total: " + cmd.ExecuteScalar().ToString() + "\n" + cmd2.ExecuteScalar().ToString());
            con.Close();
        }

        private void btn_boloCenoura_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("SELECT SUM(Preço) FROM [Registo] WHERE Produto LIKE 'Bolo de Cenoura'", con);
            cmd2 = new SqlCommand("SELECT COUNT(Produto) FROM [Registo] WHERE Produto LIKE 'Bolo de Cenoura'", con);
            MessageBox.Show("Total: " + cmd.ExecuteScalar().ToString() + "\n" + cmd2.ExecuteScalar().ToString());
            con.Close();
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }
    }
}
