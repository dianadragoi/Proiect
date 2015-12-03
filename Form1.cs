using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;//


using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication_PROIECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Proiect;Integrated Security=SSPI");

            //  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnName"].ConnectionString);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {

                //  Console.WriteLine("Connection in {0}", conn.State);
                // Console.WriteLine("Server version {0}", conn.ServerVersion);
                Console.WriteLine(Environment.NewLine);
                string queryString =
                    "SELECT DISTINCT dbo.Intrebari.Intrebare, dbo.Raspunsuri.Var_raspuns FROM dbo.Intrebari INNER JOIN dbo.Raspunsuri on dbo.Intrebari.ID=dbo.Raspunsuri.ID_intrebare ;";
            //  "SELECT Intrebare FROM dbo.Intrebari;" +
             // "SELECT  dbo.Raspunsuri.Var_raspuns FROM dbo.Intrebari INNER JOIN dbo.Raspunsuri on dbo.Intrebari.ID=dbo.Raspunsuri.ID_intrebare ;";
                using (conn)
                {
                    SqlCommand command1 = new SqlCommand(queryString, conn);
                    SqlDataReader Intr = command1.ExecuteReader();
                    int i = 4;
                    while (Intr.HasRows)
                    {
                       // MessageBox.Show(Intr.GetName(1));

                        while (Intr.Read())
                        {
                        
                            if (i % 4 == 0)
                            {
                                listBox1.Items.Add(Environment.NewLine);
                                listBox1.Items.Add(Intr["Intrebare"].ToString());

                                i = 4;

                            }
                            i--;
                            //  for (int i = 1; i <= 4; i++)
                            // {
                               listBox1.Items.Add(Intr["Var_raspuns"].ToString());
                            // }
                            //   listBox1.Items.Add()
                            //  MessageBox.Show(Intr["Intrebare"].ToString());

                        }
                        Intr.NextResult();
                    }


                }

            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
