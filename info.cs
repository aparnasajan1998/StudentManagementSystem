namespace studentmanagementsystem
{
    using System;

    public class info
    {
        public void display(Student student)
        {
            Console.WriteLine(student.Id + "\t" + student.Name + "\t" + student.Dob);
        }

        public void display(Course course)
        {
            if(course.GetType() == typeof(DegreeCourse))
            {
                DegreeCourse dec = (DegreeCourse)course;
                Console.WriteLine(course.Id + "\t" + course.Name + "\t" + course.Duration + "\t" + course.Fees + "\t" + dec.level + "\t" + dec.isplacementavailable + course.calculateMonthlyFee() + "\t");
            }
            else if (course.GetType() == typeof(DiplomaCourse))
            {
                DiplomaCourse dic = (DiplomaCourse)course;
                Console.WriteLine(course.Id + "\t" + course.Name + "\t" + course.Duration + "\t" + course.Fees + "\t" + dic.type + "\t" + course.calculateMonthlyFee() + "\t");
            }
        }

        public void display(Enroll enroll)
        {
            Console.WriteLine(enroll.Student.Id + "\t" + enroll.Student.Name + "\t" + enroll.EnrollmentDate);
        }
    }
}