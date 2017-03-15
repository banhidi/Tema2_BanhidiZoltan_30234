using System;
using MySql.Data.MySqlClient;

namespace UniversityManagement {
    public class MainClass {

        public static void Main() {
            IDbManager dbManager = new DBManager("zoli", "noemi");
            dbManager.OpenConnection();
            Console.WriteLine("{0}", dbManager.DeleteCourse(1));
            dbManager.CloseConnection();
        }

    }

}