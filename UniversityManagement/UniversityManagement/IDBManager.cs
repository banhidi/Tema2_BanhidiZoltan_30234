using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UniversityManagement {
    public interface IDbManager {
        bool OpenConnection();
        void CloseConnection();
        bool AddStudent(string name, string birthDate, string adress);
        bool ExistsStudent(string name, string birthDate, string adress);
        bool ExistsStudent(int id);
        bool DeleteStudent(int id);
        bool AlterStudent(int id, string newName, string newBirthDate, string newAdress);
        bool AddCourse(string name, string teacherName, int studyYear);
        bool ExistsCourse(string name);
        bool ExistsCourse(int id);
        bool DeleteCourse(int id);
        bool EnrollStudentToCourse(int studentID, int courseID);
        bool ExistsStudentToCourse(int studentID, int courseID);
        bool AddGrade(int studentId, int courseId, int grade);
        DataTable getStudentsDataTable();
    }
}
