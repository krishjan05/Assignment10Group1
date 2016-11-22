using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment10Group1
{
    class SQLiteDatabase
    {
        static private SQLiteDatabase db;
        private SQLiteConnection conn;
        const string CONNECT_START = "Data Source=";
        const string DBFILE = "Personnel.db3";

        private SQLiteDatabase()
        {
            string dataPath = Path.Combine(DataDirectory.GetDataPath(), DBFILE);
            string connectionString = CONNECT_START + dataPath;
            conn = new SQLiteConnection(connectionString);
            conn.Open();

            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS employee (employeeID INTEGER PRIMARY KEY, Name TEXT, Position TEXT, Rate INTEGER)";
            cmd.ExecuteNonQuery();
        }

        public long InsertEmployee(string name, string position, int rate)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = "INSERT INTO employee(employeeID, name, position, rate) VALUES (@EMPLOYEEID, @NAME, @POSITION, @RATE)";
            cmd.Parameters.AddWithValue("@NAME", name);
            cmd.Parameters.AddWithValue("@POSITION", position);
            cmd.Parameters.AddWithValue("@RATE", rate);
            return conn.LastInsertRowId;
        }
        public void InsertEmployee(Employee e)
        {
            long id = InsertEmployee(e.name, e.position, e.rate);
            e.employeeID = (int)id;
        }
        public void UpdateEmployee(Employee e)
        {
            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.CommandText = "UPDATE employee SET Name = @NAME, Position = @POSITION, Rate = @RATE where employeeID = @ID";
            cmd.Parameters.AddWithValue("@ID", e.employeeID);
            cmd.Parameters.AddWithValue("@NAME", e.name);
            cmd.Parameters.AddWithValue("@Position", e.position);
            cmd.Parameters.AddWithValue("@Rate", e.rate);
            cmd.ExecuteNonQuery();

        }
        public List<Employee> GetEmployee()
        {
            List<Employee> le = new List<Employee>();
            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.CommandText = "SELECT emplyeeID, Name, Position, Rate";
            SQLiteDataReader sdr = cmd.ExecuteReader();
        }
    }
}
