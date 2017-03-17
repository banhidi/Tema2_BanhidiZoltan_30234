using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

namespace UniversityManagement {
    public interface IDbManager {
        bool addStudentWithoutId(Student s);
        bool existsStudentWithoutId(Student s);
        bool deleteStudentById(Student s);
        bool updateStudentById(Student s);
        bool addCourse(string name, string teacherName, int studyYear);
        bool existsCourse(int id);
        bool deleteCourse(int id);
        bool enrollStudentToCourse(int studentID, int courseID);
        bool existsStudentToCourse(int studentID, int courseID);
        bool deleteStudentToCourse(int studentId, int courseId);
        bool addGrade(int studentId, int courseId, int grade);
        IList<Student> getStudents();
    }
}
