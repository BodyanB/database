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
            //SELECT * FROM Peoples
            //"INSERT INTO Peoples (id, NameN, SurName, DateBerth, Sex)" + " Values ('2', 'Andrey', 'Mahonin', '1', 'M')");
            string query = "SELECT * FROM Peoples";
            OleDbCommand command = new OleDbCommand(query, conn);
            textBox1.Text = command.ExecuteScalar().ToString();

            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            DataSet dataset = new DataSet();

            adapter.Fill(dataset);
            //conn.Close();
            dataGridView1.AutoGenerateColumns = true;
            bindingSource.DataSource = dataset.Tables[0];
            dataGridView1.DataSource = bindingSource;
            
          

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT NameN, SurName, Sex FROM Peoples ORDER BY id";
            OleDbCommand command = new OleDbCommand(query, conn);
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();
            while(reader.Read())
            {
                listBox1.Items.Add(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " ");  
            }
            reader.Close();
        }
    }
}
