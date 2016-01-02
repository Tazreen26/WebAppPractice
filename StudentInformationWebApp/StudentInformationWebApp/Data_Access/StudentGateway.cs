using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Web.Configuration;
using StudentInformationWebApp.Models;

namespace StudentInformationWebApp.Data_Access {
    public class StudentGateway {
        private readonly string _connectionString = WebConfigurationManager.ConnectionStrings["StudentManagementConnection"].ConnectionString;

        public int InsertStudentInfo( Student objStudent ) {
            SqlConnection connection = new SqlConnection(_connectionString);
            string insertQuery = @"INSERT INTO Students VALUES ('" + objStudent.StudentRegNo + "', '" + objStudent.StudentName + "', '" + objStudent.Address + "', '" + objStudent.Phone + "' )";

            connection.Open();
            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
            int affectedRow = insertCommand.ExecuteNonQuery();
            connection.Close();

            return affectedRow;
        }

        public Student GetStudentByRegNo( string regNo ) {
            SqlConnection connection = new SqlConnection(_connectionString);
            string checkQuery = "SELECT * FROM Students WHERE RegNo = " + regNo;

            connection.Open();
            SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
            SqlDataReader objReader = checkCommand.ExecuteReader();

            if(objReader.Read()) {
                Student objStudent = new Student();
                objStudent.StudentName = Convert.ToString(objReader["Name"]);
                objStudent.StudentRegNo = Convert.ToString(objReader["RegNo"]);
                objStudent.Address = Convert.ToString(objReader["Address"]);
                objStudent.Phone = Convert.ToString(objReader["Phone"]);
                objStudent.Id = Convert.ToInt32(objReader["Id"]);
                connection.Close();
                return objStudent;
            }
            objReader.Close();
            connection.Close();
            return null;
        }

        public Student GetStudentById(int studentId) {
            SqlConnection connection = new SqlConnection(_connectionString);
            string getQuery = "SELECT * FROM Students WHERE Id="+studentId;

            connection.Open();
            SqlCommand getCommand = new SqlCommand(getQuery,connection);
            SqlDataReader objReader = getCommand.ExecuteReader();
            if (objReader.Read()) {
                Student objStudent=new Student();
                objStudent.StudentName = Convert.ToString(objReader["Name"]);
                objStudent.StudentRegNo = Convert.ToString(objReader["RegNo"]);
                objStudent.Address = Convert.ToString(objReader["Address"]);
                objStudent.Phone = Convert.ToString(objReader["Phone"]);
                objStudent.Id = Convert.ToInt32(objReader["Id"]);
                connection.Close();
                return objStudent;
            }
            objReader.Close();
            connection.Close();
            return null;
        }

        public List<Student> GetAllStudent() {
            SqlConnection connection = new SqlConnection(_connectionString);
            string selectAllQuery = "SELECT * FROM Students";
            SqlCommand selectCommand = new SqlCommand(selectAllQuery, connection);
            connection.Open();
            SqlDataReader objReader = selectCommand.ExecuteReader();
            List<Student> listOfStudents = new List<Student>();
            while(objReader.Read()) {
                Student objStudent = new Student();
                objStudent.Id = Convert.ToInt32(objReader["Id"]);
                objStudent.StudentName = Convert.ToString(objReader["Name"]);
                objStudent.StudentRegNo = Convert.ToString(objReader["RegNo"]);
                objStudent.Address = Convert.ToString(objReader["Address"]);
                objStudent.Phone = Convert.ToString(objReader["Phone"]);
                listOfStudents.Add(objStudent);

            }
            objReader.Close();
            connection.Close();
            return listOfStudents;
        }

        public int UpdateStudent( Student objStudent ) {
            SqlConnection connection = new SqlConnection(_connectionString);
            string updateQuery = "UPDATE Students SET Name='" + objStudent.StudentName + "', Address='" + objStudent.Address + " ', Phone='" + objStudent.Phone + "' WHERE Id="+objStudent.Id;
            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
            connection.Open();
            int affectedRowAfterUpdate = updateCommand.ExecuteNonQuery();
            return affectedRowAfterUpdate;
        }

        public int DeleteStudent(Student objStudent) {
            SqlConnection connection = new SqlConnection(_connectionString);
            string deleteQuery = "DELETE FROM Students WHERE Id="+objStudent.Id;
            SqlCommand deleteCommand = new SqlCommand(deleteQuery,connection);
            connection.Open();
            int affectedRowAfterDelete = deleteCommand.ExecuteNonQuery();
            return affectedRowAfterDelete;
        }
    }
}