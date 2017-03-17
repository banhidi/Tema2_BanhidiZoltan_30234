using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace UniversityManagement {
    public class MySqlDbManager : IDbManager {
        private string connectionString;

        public MySqlDbManager() {
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
        }

        public bool addStudentWithoutId(Student s) {
            MySqlConnection conn = null;
            try {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "insert into Student(Name, BirthDate, Adress) values " +
                    "(@Name, @BirthDate, @Adress);";
                //command.Prepare();
                command.Parameters.AddWithValue("@Name", s.name);
                command.Parameters.AddWithValue("@BirthDate", s.birthDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@Adress", s.adress);
                command.ExecuteNonQuery();
            } catch(Exception e) {
                return false;
            } finally {
                conn.Close();
            }           
            return true;            
        }


        public bool existsStudentWithoutId(Student s) {
            MySqlConnection conn = null;
            MySqlDataReader reader = null;
            try {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "select * from Student where Name = @Name and BirthDate = @Birthdate " +
                    "and Adress = @Adress; ";
                //command.Prepare();
                command.Parameters.AddWithValue("@Name", s.name);
                command.Parameters.AddWithValue("@Birthdate", s.birthDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@Adress", s.adress);
                reader = command.ExecuteReader();
                return reader.Read();
            } catch(Exception e) {
                return false;
            } finally {
                if (conn != null)
                    conn.Close();
                if (reader != null)
                    reader.Close();
            }
        }

        public bool deleteStudentById(Student s) {
            MySqlConnection conn = null;
            try {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "delete from UniversityDatabase.Student where ID = @ID; ";
                command.Prepare();
                command.Parameters.AddWithValue("@ID", s.id);
                command.ExecuteNonQuery();
            } catch(Exception e) {
                return false;
            } finally {
                if (conn != null)
                    conn.Close();
            }
            return true;
        }

        public bool updateStudentById(Student s) {
            MySqlConnection conn = null;
            try {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "update Student set Name = @Name, BirthDate = @BirthDate, " +
                    "Adress = @Adress where ID = @ID; ";
                command.Prepare();
                command.Parameters.AddWithValue("@Name", s.name);
                command.Parameters.AddWithValue("@BirthDate", s.birthDate);
                command.Parameters.AddWithValue("@Adress", s.adress);
                command.Parameters.AddWithValue("@ID", s.id);
                command.ExecuteNonQuery();
            } catch(Exception e) {
                return false;
            } finally {
                conn.Close();
            }
            return true;
        }

        public bool addCourse(string name, string teacherName, int studyYear) {
            MySqlConnection conn = null;
            try {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "insert into Course(Name, TeacherName, StudyYear) values " +
                    "(@Name, @TeacherName, @StudyYear)";
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@TeacherName", teacherName);
                command.Parameters.AddWithValue("@StudyYear", studyYear);
                command.ExecuteNonQuery();
            } catch(Exception e) {
                return false;
            } finally {
                conn.Close();
            }
            return true;
        }

        public bool existsCourse(int id) {
            MySqlConnection conn = null;
            MySqlDataReader reader = null;
            try {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand command = new MySqlCommand("select * from Course where ID = @ID;", conn);
                command.Parameters.AddWithValue("@ID", id);
                reader = command.ExecuteReader();
                return reader.Read();
            } catch(Exception e) {
                return false;
            } finally {
                if (conn != null)
                    conn.Close();
                if (reader != null)
                    reader.Close();
            }
        }

        public bool deleteCourse(int id) {
            MySqlConnection conn = null;
            try {
                conn = new MySqlConnection(connectionString);
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "delete from Course where ID = @ID; ";
                command.Prepare();
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
            } catch(Exception e) {
                return false;
            } finally {
                if (conn != null)
                    conn.Close();
            }
            return true;
        }

        public bool enrollStudentToCourse(int studentID, int courseID) {
            MySqlConnection conn = null;
            conn.Open();
            try {
                conn = new MySqlConnection(connectionString);
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "insert into StudentToCourse(StudentID, CourseID) " +
                    "values (@StudID, @CourseID); ";
                command.Parameters.AddWithValue("@StudID", studentID);
                command.Parameters.AddWithValue("@CourseID", courseID);
                command.ExecuteNonQuery();
                return true;
            } catch(Exception e) {
                return false;
            } finally {
                if (conn != null)
                    conn.Close();
            }
        }

        public bool existsStudentToCourse(int studentID, int courseID) {
            MySqlConnection conn = null;
            MySqlDataReader reader = null;
            try {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand command = new MySqlCommand("select * from StudentToCourse where " +
                    "StudentID = @SID and CourseID = @CID;", conn);
                command.Parameters.AddWithValue("@SID", studentID);
                command.Parameters.AddWithValue("@CID", courseID);
                reader = command.ExecuteReader();
                return reader.Read();
            } catch(Exception e) {
                return false;
            } finally {
                if (conn != null)
                    conn.Close();
                if (reader != null)
                    reader.Close();
            }
        }

        public bool deleteStudentToCourse(int studentId, int courseId) {
            MySqlConnection conn = null;
            try {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "delete from StudentToCourse where StudentID = @SID and CourseID = @CID; ";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@SID", studentId);
                command.Parameters.AddWithValue("@CID", courseId);
                command.ExecuteNonQuery();
            } catch(Exception e) {
                return false;
            } finally {
                if (conn != null)
                    conn.Close();
            }
            return true;
        }

        public bool addGrade(int studentId, int courseId, int grade) {
            MySqlConnection conn = null;
            try {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "update StudentToCourse set Grade = @Grade " +
                    "where StudentID = @StudentID and CourseID = @CourseID; ";
                command.Parameters.AddWithValue("@StudentID", studentId);
                command.Parameters.AddWithValue("@CourseID", courseId);
                command.ExecuteNonQuery();
            } catch(Exception e) {
                return false;
            } finally {
                if (conn != null)
                    conn.Close();
            }
            return true;
        }

        public IList<Student> getStudents() {
            MySqlConnection conn = null;
            MySqlDataReader reader = null;
            IList<Student> list = new List<Student>();
            try {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand command = new MySqlCommand("select * from Student;", conn);
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    Student s = new Student();
                    s.id = reader.GetInt32("ID");
                    s.name = reader.GetString("Name");
                    s.birthDate = reader.GetDateTime("BirthDate");
                    s.adress = reader.GetString("Adress");
                    list.Add(s);
                }
            } catch( Exception e) {
                return list; 
            } finally {
                if (conn != null)
                    conn.Close();
                if (reader != null)
                    reader.Close();
            }
            return list;
        }

    }
}
