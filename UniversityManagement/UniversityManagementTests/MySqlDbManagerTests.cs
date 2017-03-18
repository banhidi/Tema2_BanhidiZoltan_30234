using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace UniversityManagement.Tests {
    [TestClass()]
    public class MySqlDbManagerTests {
        private static string connectionString, format = "yyyy-MM-dd";

        private void addStudentsToDatabase() {
            MySqlConnection conn = null;

            try {
                conn = new MySqlConnection(connectionString);
                conn.Open();

                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText =
                    "insert into Student(Name, BirthDate, Adress) values " +
                    "(@Name1, @BirthDate1, @Adress1), " +
                    "(@Name2, @BirthDate2, @Adress2), " +
                    "(@Name3, @BirthDate3, @Adress3), " +
                    "(@Name4, @BirthDate4, @Adress4);";
                command.Prepare();

                command.Parameters.AddWithValue("@Name1", "Banhidi Zoltan");
                command.Parameters.AddWithValue("@BirthDate1", new DateTime(1995, 6, 26).ToString(format));
                command.Parameters.AddWithValue("@Adress1", "Cluj-Napoca, Observatorului Camin 7, camera 410");

                command.Parameters.AddWithValue("@Name2", "Nagy Noemi");
                command.Parameters.AddWithValue("@BirthDate2", new DateTime(1994, 8, 18).ToString(format));
                command.Parameters.AddWithValue("@Adress2", "Panet 686");

                command.Parameters.AddWithValue("@Name3", "Biro Agnes");
                command.Parameters.AddWithValue("@BirthDate3", new DateTime(1943, 9, 10).ToString(format));
                command.Parameters.AddWithValue("@Adress3", "Panet 117");

                command.Parameters.AddWithValue("@Name4", "Banhidi Attila");
                command.Parameters.AddWithValue("@BirthDate4", new DateTime(2001, 3, 29).ToString(format));
                command.Parameters.AddWithValue("@Adress4", "Zalau, Closca 47");

                command.ExecuteNonQuery();
            } catch(Exception e) {
                MessageBox.Show(e.ToString());
            } finally {
                if (conn != null)
                    conn.Close();
            }
        }

        private void deleteAllFromDatabase() {
            MySqlConnection conn = null;

            try {                
                conn = new MySqlConnection(connectionString);
                conn.Open();

                MySqlCommand command = new MySqlCommand("delete from CourseToStudent;", conn);
                command.Prepare();
                command.ExecuteNonQuery();

                command = new MySqlCommand("delete from Course;", conn);
                command.Prepare();
                command.ExecuteNonQuery();

                command = new MySqlCommand("delete from Student;", conn);
                command.Prepare();
                command.ExecuteNonQuery();
            } catch(Exception e) {
            } finally {
                if (conn != null)
                    conn.Close();
            }
            System.Console.WriteLine("Class initialize");
        }

        [ClassInitialize()]
        public static void classInit(TestContext tc) {
            connectionString =
              ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
        }

        [TestInitialize()]
        public void TestInit() {
            deleteAllFromDatabase();
            addStudentsToDatabase();
        }

        [TestCleanup()]
        public void TestClean() {
            deleteAllFromDatabase();
        }

        [TestMethod()]
        public void addStudentWithoutId_Test() {
            Student s = new Student();
            s.name = "Banhidi Geza-Zoltan";
            s.birthDate = new DateTime(1965, 1, 6);
            s.adress = "Zalau, Closca 47";

            IDbManager mgr = new MySqlDbManager();
            if (!mgr.addStudentWithoutId(s))
                Assert.Fail();
            Assert.IsTrue(mgr.existsStudentWithoutId(s));
        }

        [TestMethod()]
        public void existsStudentWithoutId_Test() {
            Student s = new Student();
            s.name = "Banhidi Zoltan";
            s.birthDate = new DateTime(1995, 6, 26);
            s.adress = "Cluj-Napoca, Observatorului Camin 7, camera 410";
            IDbManager mgr = new MySqlDbManager();
            Assert.IsTrue(mgr.existsStudentWithoutId(s));
        }
    }
}