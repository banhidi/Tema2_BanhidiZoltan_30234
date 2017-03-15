using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement {
    interface IDbManager {
        bool OpenConnection();
        void CloseConnection();
        bool AddStudent(string name, string birthDate, string adress);
        bool ExistsStudent(string name, string birthDate, string adress);
        bool DeleteStudent(int id);
        bool AddCourse(string name, string teacherName, int studyYear);
        bool ExistsCourse(string name);
        bool DeleteCourse(int id);
        bool EnrollStudentToCourse(int studentID, int courseID);
        //void AddGrade(int studentId, int courseId);
    }
}
