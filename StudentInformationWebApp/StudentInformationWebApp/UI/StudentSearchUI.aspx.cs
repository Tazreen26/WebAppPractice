using System;
using StudentInformationWebApp.Business_Logic;
using StudentInformationWebApp.Models;

namespace StudentInformationWebApp.UI {
    public partial class StudentSearchUI : System.Web.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {

        }

        protected void redirectToHomeButton_Click( object sender, EventArgs e ) {
            Response.Redirect("StudentInfoUI.aspx");
        }

        protected void searchStudentButton_Click( object sender, EventArgs e ) {
            ClearAllTextField();
            string studentRegNo = regNoTextBox.Text;
            if (studentRegNo!="") {
                StudentManager objManager = new StudentManager();
                Student objStudent = objManager.GetStudentByRegNo(studentRegNo);
                if (objStudent != null) {
                    nameTextBox.Text = objStudent.StudentName;
                    addressTextBox.Text = objStudent.Address;
                    phoneTextBox.Text = objStudent.Phone;
                    messageLabel.Text = "Student Found";
                }
                else {
                    messageLabel.Text = "Student Not Found";
                }
            }
            else {
                messageLabel.Text = "Registration Number Field is Empty";
            }
        }

        private void ClearAllTextField() {
            nameTextBox.Text = string.Empty;
            addressTextBox.Text = string.Empty;
            phoneTextBox.Text = string.Empty;
        }
    }
}