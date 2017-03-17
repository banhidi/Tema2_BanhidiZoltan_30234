using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityManagement {
    public partial class StudentForm : Form {

        public enum OperationEnum { Add, Modify };
        private IDbManager dbManager;
        private OperationEnum operation;
        public OperationEnum Operation {
            get {
                return operation;
            }
            set {
                //MessageBox.Show(value.ToString());
                if (value == OperationEnum.Add) {
                    Button.Text = "Add";
                    operation = OperationEnum.Add;
                } else if (value == OperationEnum.Modify) {
                    Button.Text = "Modify (ID=" + student.id.ToString() + ")";
                    NameTextBox.Text = student.name;
                    birthdayTimePicker.Value = student.birthDate;
                    AdressTextBox.Text = student.adress;
                    operation = OperationEnum.Modify;
                }
            }
        }
        public Student student { get; set; }
        private MainForm mainForm;

        public StudentForm(MainForm mf) {
            InitializeComponent();
            dbManager = new MySqlDbManager();
            Operation = OperationEnum.Add;
            student = null;
            mainForm = mf;
        }  
        
        private void showErrorMessage(string text) {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }               

        private void AddButton_Click(object sender, EventArgs e) {           
            if (operation == OperationEnum.Add) {
                if (!addStudentToDatabase()) {
                    return;
                }
            } else if (operation == OperationEnum.Modify) {
                if (!modifyStudentInDatabase()) {
                    return;
                }
            }            
            mainForm.Enabled = true;
            mainForm.ReloadStudentsTable();
            this.Hide();            
        }

        private bool addStudentToDatabase() {
            student = new UniversityManagement.Student();
            student.name = NameTextBox.Text;
            student.birthDate = birthdayTimePicker.Value;
            student.adress = AdressTextBox.Text;
            if (dbManager.existsStudentWithoutId(student)) {
                showErrorMessage("A student with the same name, birthdate and address exists in " +
                    "the database already.");
                return false;
            } else {
                bool ok = dbManager.addStudentWithoutId(student);
                if (!ok) {
                    showErrorMessage("Can't add student to database.");
                    return false;
                }
                return true;
            }
        }

        private bool modifyStudentInDatabase() {
            if (student == null) {
                showErrorMessage("Internal error. No student selected.");
                return false;
            }
            student.name = NameTextBox.Text;
            student.birthDate = birthdayTimePicker.Value;
            student.adress = AdressTextBox.Text;
            if (!dbManager.updateStudentById(student)) {
                showErrorMessage("Can't update student into the database.");
                return false;
            }
            //MessageBox.Show("Student id=" + student.id.ToString());
            return true;
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Owner.Enabled = true;
            this.Hide();
        }

        private void StudentForm_FormClosing(object sender, FormClosingEventArgs e) {
            this.Owner.Enabled = true;
        }
    }
}
