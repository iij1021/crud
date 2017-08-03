using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace WCrud
{
    public partial class FLogin : Form
    {
        private System.Windows.Forms.DataGrid mDataGrid;
        private MySqlConnection Conexao;
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;
        private MySqlDataReader reader   ;
                                
        public FLogin()
        {
            InitializeComponent();
            mDataSet = new DataSet();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string configuracao = "server = localhost;uid = root;database = empresa";
            Conexao = new MySqlConnection(configuracao);
            try
            {
                Conexao.Open();
               
                if (Conexao.State == ConnectionState.Open)
                {
                   MySqlCommand sql = new MySqlCommand("SELECT * FROM CLIENTE WHERE idcliente =@id",Conexao);
                   MySqlParameter parametros = new MySqlParameter();
                    parametros.ParameterName = "@id";
                    sql.Parameters.Add(parametros);
                    reader = sql.ExecuteReader();

                    MessageBox.Show("Clientes " + reader.);

                }

            }
            catch(System.Exception E)
            {
                MessageBox.Show(" Erro " + E.Message);
            }
        }
    }
}
