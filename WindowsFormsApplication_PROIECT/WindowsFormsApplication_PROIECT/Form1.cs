using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            afisare_intrebari();
        }

        class Question
        {
            public Question()
            {
                Answers = new string[4];
            }
            public string QuestionText { get; set; }
            public string[] Answers { get; set; }
            public int CorrectAnswer { get; set; }
        }


        private void afisare_intrebari()
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
                            var question = new Question();

                            if (i % 4 == 0)
                            {
                                question.QuestionText = Intr["Intrebare"].ToString();
                                label1.Text = (i+1).ToString();
                                listBox1.Items.Add(Environment.NewLine);
                                listBox1.Items.Add(question.QuestionText);
                                label2.Text = question.QuestionText;
                                i = 4;

                            }
                            i--;
                            question.Answers[0] = Intr["Var_raspuns"].ToString();
                            //
                            //
                            radioButton1.Text = Intr["Var_raspuns"].ToString();
                            radioButton2.Text = Intr["Var_raspuns"].ToString();
                            radioButton3.Text = Intr["Var_raspuns"].ToString();
                            radioButton4.Text = Intr["Var_raspuns"].ToString();
                            listBox1.Items.Add(Intr["Var_raspuns"].ToString());
                           

                        }
                        Intr.NextResult();
                    }


                }

            }
        
        }
           
private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
