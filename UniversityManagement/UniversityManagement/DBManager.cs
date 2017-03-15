using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace UniversityManagement {
    class DBManager : IDbManager {
        private MySqlConnection connection;
        private string connectionString;

        public DBManager(string username, string password) {
            connectionString = "server=localhost; userid=" + username + 
                "; password=" + password + "; database=UniversityDatabase";
            connection = null;
        }

        public bool OpenConnection() {
            try {
                connection = new MySqlConnection(connectionString);
                connection.Open();
            } catch(Exception e) {
                return false;
            }
            return true;
        }

        public void CloseConnection() {
            if (connection != null) {
                connection.Close();
                connection = null;
            }
        }

        public bool AddStudent(string name, string birthDate, string adress) {
            try {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "insert into Student(Name, BirthDate, Adress) values " +
                    "(@Name, @BirthDate, @Adress);";
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@BirthDate", birthDate);
                command.Parameters.AddWithValue("@Adress", adress);
                command.ExecuteNonQuery();
            } catch(Exception e) {
                return false;
            }           
            return true;            
        }

        public bool ExistsStudent(string name, string birthDate, string adress) {
            MySqlDataReader reader = null;
            try {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "select ID from Student where Name = @Name and " +
                    "BirthDate = @BirthDate and " + "Adress = @Adress; ";
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@BirthDate", birthDate);
                command.Parameters.AddWithValue("@Adress", adress);
                reader = command.ExecuteReader();
                if (reader.Read())
                    return true;
                else
                    return false;
            } catch(Exception e) {
                return false;
            } finally {
                if (reader != null)
                    reader.Close();
            }
        }

        public bool DeleteStudent(int id) {
            try {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "delete from Student where ID = @ID; ";
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
                return true;
            } catch(Exception e) {
                return false;
            }
        }

        public bool AddCourse(string name, string teacherName, int studyYear) {
            try {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "insert into Course(Name, TeacherName, StudyYear) values " +
                    "(@Name, @TeacherName, @StudyYear)";
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@TeacherName", teacherName);
                command.Parameters.AddWithValue("@StudyYear", studyYear);
                command.ExecuteNonQuery();
            } catch(Exception e) {
                return false;
            }
            return true;
        }

        public bool ExistsCourse(string name) {
            MySqlDataReader reader = null;
            try {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "select id from Course where Name = @Name; ";
                command.Parameters.AddWithValue("@Name", name);
                reader = command.ExecuteReader();
                return reader.Read();
            } catch(Exception e) {
                return false;
            } finally {
                if (reader != null)
                    reader.Close();
            }
        }

        public bool DeleteCourse(int id) {
            try {
                MySqlCommand command = new MySqlCommand();
                command.Connection = this.connection;
                command.CommandText = "delete from Course where ID = @ID; ";
                command.Prepare();
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
            } catch(Exception e) {
                return false;
            }
            return true;
        }



    }
}
