using System.Collections.Generic;
using StudentInformationWebApp.Data_Access;
using StudentInformationWebApp.Models;

namespace StudentInformationWebApp.Business_Logic {
    public class StudentManager {
        StudentGateway objStudentGateway = new StudentGateway();

        public string SaveStudentInfo( Student objStudent ) {
            string message = null;
            bool isStudentExists = CheckStudentByRegNo(objStudent.StudentRegNo);
            if(isStudentExists) {
                message = "Student Already Exists";
                return message;
            }

            int affectedRow = objStudentGateway.InsertStudentInfo(objStudent);
            if(affectedRow > 0) {
                message = "Student Info Saved Successfully";
            }
            return message;
        }

        private bool CheckStudentByRegNo( string regNo ) {

            if(objStudentGateway.GetStudentByRegNo(regNo) != null) {
                return true;
            }
            return false;
        }

        public Student GetStudentByRegNo( string regNo ) {
            Student objStudent = objStudentGateway.GetStudentByRegNo(regNo);
            return objStudent;
        }
        public Student GetStudentById( int studentId ) {
            return objStudentGateway.GetStudentById(studentId);

        }

        public List<Student> GetAllStudents() {
            List<Student> studentList = objStudentGateway.GetAllStudent();
            return studentList;
        }

        public string UpdateStudent( Student objStudent ) {
            if(!(CheckStudentByRegNo(objStudent.StudentRegNo))) {
                return "Student record doesn't exist!";
            }
            int affectedRowAfterUpdate = objStudentGateway.UpdateStudent(objStudent);
            if(affectedRowAfterUpdate > 0) {
                return "Update Successfull";
            }
            return "Update Failed";
        }


        public string DeleteStudentRecord(Student objStudent) {
            int affectedRowAfterDelete = objStudentGateway.DeleteStudent(objStudent);
            if (affectedRowAfterDelete > 0) {
                return "Student Record Deleted";
            }
            return "Delete Failed!";
        }
    }
}