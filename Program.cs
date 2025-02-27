// Connecting c# with mysql
using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "SERVER=localhost; DATABASE=employee_db; UID=csharpuser; PASSWORD=mypassword; AllowPublicKeyRetrieval=True; SSL Mode=None;";


        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                Console.WriteLine("✅ Connected to MySQL database successfully!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error: " + ex.Message);
        }
    }
}
