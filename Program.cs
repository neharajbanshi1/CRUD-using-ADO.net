using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace MyProject
{
    class Program
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        string sql = "";

        public Program()
        {
            // Creating connection
            string constr = "SERVER=localhost; DATABASE=employee_db; UID=csharpuser; PASSWORD=mypassword; AllowPublicKeyRetrieval=True; SSL Mode=None;";
            conn = new MySqlConnection(constr);
            conn.Open();

            // Creating table if not exists
            sql = "CREATE TABLE IF NOT EXISTS employee (eid INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(100) NOT NULL, department VARCHAR(50), gender ENUM('Male', 'Female', 'Other'))";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine(" Table Created Successfully!");

// Inserting multiple employees one by one
sql = "INSERT INTO employee (name, department, gender) VALUES " +
      "('Shiv', 'Finance', 'Female'), " +
      "('Roman', 'IT', 'Male'), " +
      "('Kendall', 'Finance', 'Female')";

cmd = new MySqlCommand(sql, conn);
cmd.ExecuteNonQuery();

Console.WriteLine("Data Inserted Successfully!");

            conn.Close();
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}
