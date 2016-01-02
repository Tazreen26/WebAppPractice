namespace StudentInformationWebApp.Models {
    public class Student {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentRegNo { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Student() {
        }
        public Student( string studentName, string studentRegNo, string studentPhone, string studentAddress ) {
            StudentName = studentName;
            StudentRegNo = studentRegNo;
            Phone = studentPhone;
            Address = studentAddress;
        }
        public Student( int id,string studentName, string studentRegNo, string studentPhone, string studentAddress ) : this(studentName, studentRegNo, studentPhone, studentAddress) {
            Id = id;
        }
    }
}