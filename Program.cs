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
            try{
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

//updating data
//sql="UPDATE employee SET name='Jebidiah' WHERE eid=1";
//cmd=new MySqlCommand(sql,conn);
//cmd.ExecuteNonQuery();
//Console.WriteLine("Data Updated Successfully!");

//deleting data
//sql="DELETE FROM employee WHERE eid=1";
//cmd=new MySqlCommand(sql,conn);
//cmd.ExecuteNonQuery();
//Console.WriteLine("Data Deleted Successfully!");

//selecting data
sql="SELECT * FROM employee";
cmd=new MySqlCommand(sql,conn);
MySqlDataAdapter adapter=new MySqlDataAdapter(cmd);
DataTable dt=new DataTable();
adapter.Fill(dt);


if(dt.Rows.Count!=0){
for(int i=0;i<dt.Rows.Count;i++){
string sid= dt.Rows[i]["eid"].ToString();
string name= dt.Rows[i]["name"].ToString();
Console.WriteLine(sid+" "+name);
}
}

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally{
                if(conn!=null && conn.State ==ConnectionState.Open){
                    conn.Close();
                    Console.WriteLine("Connection Closed Successfully!");
                }
            }
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}
