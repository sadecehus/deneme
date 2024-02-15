using MySql.Data.MySqlClient;

namespace WinFormsApp1

{
    public partial class Form1 : Form
    {
        private MySqlConnection conn;
        private MySqlDataReader reader;
        private MySqlCommand command;
        private MySqlParameter[] parameters;
        public static string sqlconn = "Server=92.205.5.130;Database=example;User Id=kocaturk4145;Password=kocaturk4145;Port=3306;";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sorgu = "SELECT name_surname FROM tbl_user_login WHERE username = @username AND password = @password";

            using (conn = new MySqlConnection(sqlconn))
            {
                using (command = new MySqlCommand(sorgu, conn))
                {
                    command.Parameters.AddWithValue("@username", textBox1.Text);
                    command.Parameters.AddWithValue("@password", textBox2.Text);

                    try
                    {
                        conn.Open();

                        using (reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Baþarýlý");
                            }
                            else
                            {
                                MessageBox.Show("Baþarýsýz");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close(); // Baðlantýyý her durumda kapat
                    }
                }
            }
        }

    }

}
