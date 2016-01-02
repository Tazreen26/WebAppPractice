using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using StudentInformationWebApp.Business_Logic;
using StudentInformationWebApp.Models;

namespace StudentInformationWebApp.UI {
    public partial class StudentInfoUI : System.Web.UI.Page {
        StudentManager objStudentManager = new StudentManager();
        protected void Page_Load( object sender, EventArgs e ) {
            ShowAllStudents();
            messageLabel.Text = string.Empty;
        }

        protected void saveButton_Click( object sender, EventArgs e ) {
            string studentName = nameTextBox.Text;
            string studentRegNo = regNoTextBox.Text;
            string studentPhone = phoneNoTextBox.Text;
            string studentAddress = addressTextBox.Text;
            string saveMessage;
            if(saveButton.Text == "Save") {
                Student student = new Student(studentName, studentRegNo, studentPhone, studentAddress);
                saveMessage = objStudentManager.SaveStudentInfo(student);
                messageLabel.Text = saveMessage;
            }
            else if(saveButton.Text == "Update") {
                int idToChange = Convert.ToInt32(this.idToChange.Value);
                Student student = new Student(idToChange, studentName, studentRegNo, studentPhone, studentAddress);
                saveMessage = objStudentManager.UpdateStudent(student);
                messageLabel.Text = saveMessage;
                saveButton.Text = "Save";
            }
            else if(saveButton.Text == "Delete") {
                int idToChange = Convert.ToInt32(this.idToChange.Value);
                Student student = new Student(idToChange, studentName, studentRegNo, studentPhone, studentAddress);
                saveMessage = objStudentManager.DeleteStudentRecord(student);
                messageLabel.Text = saveMessage;
                saveButton.Text = "Save";
            }
            //Just to show the gridview Data
            ShowAllStudents();
        }

        protected void showButton_Click( object sender, EventArgs e ) {
            //ShowAllStudents();
        }

        protected void ShowAllStudents() {
            List<Student> objShowAllStudents = objStudentManager.GetAllStudents();
            showStudentInfoGridView.DataSource = objShowAllStudents;
            showStudentInfoGridView.DataBind();
        }
        protected void redirectToSearchButton_Click( object sender, EventArgs e ) {
            Response.Redirect("StudentSearchUI.aspx");
        }

        protected void updateButton_OnClick( object sender, EventArgs e ) {
            Student student = ButtonClickAction(sender);
            ShowInTextBoxes(student);
            saveButton.Text = "Update";
        }

        protected void ShowInTextBoxes( Student student ) {
            regNoTextBox.Text = student.StudentRegNo;
            regNoTextBox.Enabled = false;
            nameTextBox.Text = student.StudentName;
            addressTextBox.Text = student.Address;
            phoneNoTextBox.Text = student.Phone;
        }

        protected void deleteButton_OnClick( object sender, EventArgs e ) {
            Student student = ButtonClickAction(sender);
            ShowInTextBoxes(student);
            saveButton.Text = "Delete";
        }

        protected Student ButtonClickAction( object sender ) {
            GridViewRow objRow = (GridViewRow)((LinkButton)sender).Parent.Parent;
            HiddenField studentIdHiddenField = (HiddenField)objRow.FindControl("studentIdHiddenField");
            int studentId = Int32.Parse(studentIdHiddenField.Value);
            idToChange.Value = studentIdHiddenField.Value;
            Student objStudent = objStudentManager.GetStudentById(studentId);
            return objStudent;
        }
    }
}