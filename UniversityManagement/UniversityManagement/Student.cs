using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement {
    public class Student {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public string adress { get; set; }

        public override bool Equals(object obj) {
            if (obj is Student) {
                Student s = (Student)obj;
                return name.Equals(s.name) && birthDate.Equals(s.birthDate) && adress.Equals(s.adress);
            } else
                return false;
        }
    }
}
