using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace database
{
    public partial class Form1 : Form
    {
        public static string conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\testdb.mdb;Persist S" +
           "ecurity Info=True;Jet OLEDB:Database Password=12345";
        private OleDbConnection conn;
        private BindingSource bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testdbDataSet1.Peoples". При необходимости она может быть перемещена или удалена.
            //this.peoplesTableAdapter.Fill(this.testdbDataSet1.Peoples);

            conn = new OleDbConnection(conStr);
            conn.Open();

            //var command = conn.CreateCommand();
           // command.CommandText = "INSERT INTO Peoples (id, NameN, SurName, DateBerth, Sex)" + " Values ('0', 'Bogdan', 'Bieliaiev', '20', 'M')";

            // OleDbCommand command = new OleDbCommand("INSERT INTO Peoples (NameN, SurName, DateBerth, Sex)" + " Values ('Bohdan', 'Bieliaev', '20', 'M')");
            OleDbCommand command = new OleDbCommand("SELECT * FROM Peoples");
            command.Connection = conn;

            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            DataSet dataset = new DataSet();

            adapter.Fill(dataset);
            //conn.Close();
            dataGridView1.AutoGenerateColumns = true;
            bindingSource.DataSource = dataset.Tables[0];
            dataGridView1.DataSource = bindingSource;
            MessageBox.Show("Load my project");
          

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
    }
}
