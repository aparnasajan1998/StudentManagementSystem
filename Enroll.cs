namespace studentmanagementsystem
{
    using System;

    public class Enroll
    {
        private Student student;
        private Course course;
        private DateTime enrollmentDate = DateTime.Now;

        internal Student Student { get => student; set => student = value; }
        internal Course Course { get => course; set => course = value; }
        public DateTime EnrollmentDate { get => enrollmentDate; set => enrollmentDate = value; }

        public Enroll()
        {
        }
        public Enroll(Student student, Course course, DateTime enrollmentdate)
        {
            this.Student = student;
            this.Course = course;
            this.EnrollmentDate = enrollmentDate;
        }
        public override string ToString()
        {
            return "\t" + Student.Name + "\t" + Course.Name + "\t" + EnrollmentDate + "\n";
        }
    }


}