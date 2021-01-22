using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;


namespace CaixaRegistadora
{
    public partial class Form1 : Form
    {
        List<string> Queue = new List<string> { };
        double t = 0.0;

        #region Connection
        string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.GetFullPath(@"..\..") + "\\CaixaRegistradora.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection con;
        SqlCommand cmd;
        public void insertData(string produto, string preço)
        {
            cmd = new SqlCommand("INSERT INTO [Registo] ([Produto], [Preço]) VALUES (@Produto, @Preço)");
            cmd.Connection = con;
            con.Open();
            cmd.Parameters.AddWithValue("@Produto", produto);
            cmd.Parameters.AddWithValue("@Preço", preço);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
        }

        private void btn_Produto_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            switch (button.Name)
            {
                case "btn_boloCenoura":
                    lst_Queue.Items.Add("Bolo de Cenoura");
                    Queue.Add("Bolo de Cenoura");
                    break;

                case "btn_boloBolacha":
                    lst_Queue.Items.Add("Bolo de Bolacha");
                    Queue.Add("Bolo de Bolacha");
                    break;

                case "btn_boloIogurte":
                    lst_Queue.Items.Add("Bolo de Iogurte");
                    Queue.Add("Bolo de Iogurte");
                    break;

                case "btn_boloBanana":
                    lst_Queue.Items.Add("Bolo de Banana");
                    Queue.Add("Bolo de Banana");
                    break;

                case "btn_tartePastel":
                    lst_Queue.Items.Add("Tarte de Pastel");
                    Queue.Add("Tarte de Pastel");
                    break;

                case "btn_tarteAmendoa":
                    lst_Queue.Items.Add("Tarte de Amendoa");
                    Queue.Add("Tarte de Amendoa");
                    break;

                case "btn_Gomas":
                    lst_Queue.Items.Add("Gomas");
                    Queue.Add("Gomas");
                    break;

                case "btn_Salame":
                    lst_Queue.Items.Add("Salame");
                    Queue.Add("Salame");
                    break;

                case "btn_Mousse":
                    lst_Queue.Items.Add("Mousse de Oreo");
                    Queue.Add("Mousse de Oreo");
                    break;

                case "btn_Sumos":
                    DialogResult dialogResult = MessageBox.Show("Aplicar o desconto?", "Sumos", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        lst_Queue.Items.Add("Sumo (Desconto)");
                        Queue.Add("Sumo (Desconto)");
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        lst_Queue.Items.Add("Sumo");
                        Queue.Add("Sumo");
                    }
                    break;

                case "btn_Doacao":
                    double i;
                    bool result = double.TryParse(txt_Donation.Text, out i);
                    if (result && i > 0)
                    {
                        lst_Queue.Items.Add("Doação (" + i + "€)");
                        Queue.Add("Doação (" + i + ")");
                    }
                    else
                    {
                        MessageBox.Show("Introduza um valor númerico.");
                    }
                    break;

                case "btn_Waffle":
                    double preço = 1.0;
                    double x;
                    bool result2 = double.TryParse(txt_Toppings.Text, out x);
                    if (chck_Acucar.Checked)
                    {
                        preço += 0.1;
                    }
                    if (result2 && x > 0)
                    {
                        preço += 0.3 + ((x - 1) * 0.2); //toppings
                    }
                    lst_Queue.Items.Add("Waffle");
                    Queue.Add("Waffle (" + preço.ToString() + ")");
                    break;
            }
        }

        private void btn_Aceitar_Click(object sender, EventArgs e)
        {
            foreach (string Item in Queue)
            {
                switch (Item.ToString())
                {
                    case "Bolo de Cenoura":
                        insertData("Bolo de Cenoura", "0.90");
                        t += 0.90;
                        break;

                    case "Bolo de Bolacha":
                        insertData("Bolo de Bolacha", "0.90");
                        t += 0.90;
                        break;

                    case "Bolo de Iogurte":
                        insertData("Bolo de Iogurte", "0.60");
                        t += 0.60;
                        break;

                    case "Bolo de Banana":
                        insertData("Bolo de Banana", "0.60");
                        t += 0.60;
                        break;

                    case "Tarte de Pastel":
                        insertData("Tarte de Pastel", "0.80");
                        t += 0.80;
                        break;

                    case "Tarte de Amendoa":
                        insertData("Tarte de Amendoa", "0.80");
                        t += 0.80;
                        break;

                    case "Gomas":
                        insertData("Gomas", "0.50");
                        t += 0.50;
                        break;

                    case "Salame":
                        insertData("Salame", "0.50");
                        t += 0.50;
                        break;

                    case "Mousse de Oreo":
                        insertData("Mousse de Oreo", "0.70");
                        t += 0.70;
                        break;

                    case "Sumo (Desconto)":
                        insertData("Sumo (Desconto)", "0.20");
                        t += 0.20;
                        break;

                    case "Sumo":
                        insertData("Sumo", "0.30");
                        t += 0.30;
                        break;

                    default:
                        if (Item.ToString().Contains("Doação"))
                        {
                            insertData("Doaçao", Item.ToString().Substring(8, Item.Length - 9).Replace(",", "."));
                            MessageBox.Show("Doação: " + txt_Donation.Text + "€", "Obrigado");
                        }
                        else if (Item.ToString().Contains("Waffle"))
                        {
                            insertData("Waffle", Item.ToString().Substring(8, Item.Length - 9).Replace(",", "."));
                            t += double.Parse(Item.ToString().Substring(8, Item.Length - 9));
                        }
                        break;
                }
            }
            lbl_Total.Text = "Total = " + t + "€";

            lst_Queue.Items.Clear();
            Queue.Clear();
        }

        private void btn_Recusar_Click(object sender, EventArgs e)
        {
            lst_Queue.Items.Clear();
            Queue.Clear();
            lbl_Total.Text = "Total = 0€";
            t = 0.0;
        }

        private void btn_VerDados_Click(object sender, EventArgs e)
        {
            new Dados().Show();
            this.Hide();
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
