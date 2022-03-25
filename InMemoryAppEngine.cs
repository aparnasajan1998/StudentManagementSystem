namespace studentmanagementsystem
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    

    class InMemoryAppEngine : AppEngine
    {
        Student student;
        Course course;
        DateTime endate;

        info info = new info();
        Course c;
        public List<Student> studentslist = new List<Student>();
        public List<Course> courseslist = new List<Course>();
        public List<Enroll> enrolllist = new List<Enroll>();
        //static int count = 0;

        public static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        public void introduce(Course course)
        {
            courseslist.Add(course);
            int rows = 0;
            if (course.Id != 0 && course.Name != " " && course.Duration != 0 && course.Fees != 0)
            {
                //string strconnection = @"Data Source=LAPTOP-AQTGOHKD\SQLEXPRESS;integrated security=true;initial catalog=StudentManagementSystem";
                //SqlConnection con = new SqlConnection(strconnection);
                SqlCommand cmd = new SqlCommand("InsertCourseDet", con);
                try
                {
                    con.Open();
                    Console.WriteLine("Connected successfully");
                    if (course.GetType() == typeof(DegreeCourse))
                    {
                        DegreeCourse dec = new DegreeCourse();
                        DegreeCourse degreec = (DegreeCourse)course;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Cid", degreec.Id);
                        cmd.Parameters.AddWithValue("@Cname", degreec.Name);
                        cmd.Parameters.AddWithValue("@Cduration", degreec.Duration);
                        cmd.Parameters.AddWithValue("@Cfees", degreec.Fees);
                        cmd.Parameters.AddWithValue("@Ccourse", "Degree");
                        cmd.Parameters.AddWithValue("@clevel", degreec.level.ToString());
                        cmd.Parameters.AddWithValue("@Cplacement", degreec.Isplacementavailable.ToString());
                        cmd.Parameters.AddWithValue("@Ctype", "NA");
                        cmd.Parameters.AddWithValue("@choice", 1);
                        cmd.Parameters.AddWithValue("@Monthlyfee", degreec.calculateMonthlyFee().ToString());
                        try
                        {
                            rows = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Console.WriteLine(rows + " rows added!");
                        Console.WriteLine("------------------------------");
                        con.Close();
                    }
                    else if (course.GetType() == typeof(DiplomaCourse))
                    {
                        DiplomaCourse diplomac = (DiplomaCourse)course;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Cid", diplomac.Id);
                        cmd.Parameters.AddWithValue("@Cname", diplomac.Name);
                        cmd.Parameters.AddWithValue("@Cduration", diplomac.Duration);
                        cmd.Parameters.AddWithValue("@Cfees", diplomac.Fees);
                        cmd.Parameters.AddWithValue("@Ccourse", "Diploma");
                        cmd.Parameters.AddWithValue("@clevel", "NA");
                        cmd.Parameters.AddWithValue("@Cplacement", "NA");
                        cmd.Parameters.AddWithValue("@Ctype", diplomac.type.ToString());
                        cmd.Parameters.AddWithValue("@choice", 2);
                        cmd.Parameters.AddWithValue("@Monthlyfee", diplomac.calculateMonthlyFee().ToString());
                        try
                        {
                            rows = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Console.WriteLine(rows + " rows added!");
                        Console.WriteLine("----------------------------");
                        con.Close();
                    }
                    else
                    {
                        Console.WriteLine("Invalid course name");
                    }
                }
                 catch (Exception e)
                {
                    Console.WriteLine("cannot connect to the database");
                }
            }
        }
        public void register(Student student)
        {
            //string strconnection = @"Data Source=LAPTOP-AQTGOHKD\SQLEXPRESS;integrated security=true;initial catalog=StudentManagementSystem";
            //SqlConnection con = new SqlConnection(strconnection);
            try
            {
                con.Open();
                Console.WriteLine("Connected successfully");
                SqlCommand cmd = new SqlCommand();
                int rows = 0;
                cmd = new SqlCommand("insert Student values(@Sid,@Sname,@Sdob)", con);
                cmd.Parameters.AddWithValue("Sid", student.Id);
                cmd.Parameters.AddWithValue("Sname", student.Name);
                cmd.Parameters.AddWithValue("Sdob", student.Dob);
                try
                {
                    rows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(rows + " rows added!");
                Console.WriteLine("------------------------------");
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            studentslist.Add(student);
        }
        public List<Student> listOfStudents()
        {
            //Console.WriteLine("Displaying from the list");
            //if (studentslist.Count() > 0)
            //{
            //    foreach (var student in studentslist)
            //    {
            //        info.display(student);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No student details to display from the list");
            //}
            //string strconnection = @"Data Source=LAPTOP-AQTGOHKD\SQLEXPRESS;integrated security=true;initial catalog=StudentManagementSystem";
            //SqlConnection con = new SqlConnection(strconnection);
            try
            {
                con.Open();
                Console.WriteLine("Connected successfully");
                Console.WriteLine("Displaying students from the database");
                Console.WriteLine("-------------------------------------------");
                SqlCommand cmd = new SqlCommand("select * from Student", con);
                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine("Records inserted into the database are: ");
                if (dr.HasRows)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t\t{2}", dr.GetName(0), dr.GetName(1), dr.GetName(2));
                    Console.WriteLine("-------------------------------------------");
                    while (dr.Read())
                    {
                        Console.WriteLine(dr.GetInt32(0) + "\t\t" + dr.GetString(1) + "\t\t" + dr.GetDateTime(2).ToShortDateString());
                    }
                    dr.NextResult();
                }
                else
                {
                    Console.WriteLine("There are no rows inserted into the database");
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public List<Course> listOfCourses(string choice)
        {

            //string strconnection = @"Data Source=LAPTOP-AQTGOHKD\SQLEXPRESS;integrated security=true;initial catalog=StudentManagementSystem";
            //SqlConnection con = new SqlConnection(strconnection);
            try
            {
                con.Open();
                Console.WriteLine("Connected successfully");
                Console.WriteLine("Displaying courses from the database");
                SqlCommand cmd = new SqlCommand("Select * from Course_Details where Ccourse=@Ccourse", con);
                cmd.CommandType = CommandType.Text;

                SqlParameter param = new SqlParameter("@Ccourse", choice);
                cmd.Parameters.Add(param);

                SqlDataReader dr = cmd.ExecuteReader();
                try
                {
                    if (dr.HasRows)
                    {
                        Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t\t {6} \t {7}", dr.GetName(0), dr.GetName(1), dr.GetName(2), dr.GetName(3), dr.GetName(4), dr.GetName(5), dr.GetName(6), dr.GetName(7));
                        while (dr.Read())
                        {
                            Console.WriteLine(dr[0] + "\t" + dr[1] + "\t" + dr[2] + "\t\t" + dr[3] + "\t\t" + dr[4] + "\t\t" + dr[5] + "\t\t" + dr[6] + "\t\t" + dr[7]);
                            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public void addEnrollment(Student student, Course course)
        {
            //string strconnection = @"Data Source=LAPTOP-AQTGOHKD\SQLEXPRESS;integrated security=true;initial catalog=StudentManagementSystem";
            //SqlConnection con = new SqlConnection(strconnection);
            try
            {
                con.Open();
                Console.WriteLine("Connected successfully");
                SqlCommand cmd = new SqlCommand();
                int rows = 0;
                Console.WriteLine("Enter student Id:");
                int id = Convert.ToInt32(Console.ReadLine());
                cmd = new SqlCommand("select @studentid from Student where " + id + " = @Sid", con);
                Console.WriteLine("Enter your choice\n1.Degree \n2.Diploma");
                string choice = Console.ReadLine();
                listOfCourses(choice);
                Console.WriteLine("Enter Course Id:");
                int courseid = Convert.ToInt32(Console.ReadLine());
                cmd = new SqlCommand("select @Cid from course where " + courseid + " = @Cid AND '" + choice + "' = @Ccourse", con);
                
                DateTime enrollmentdate = DateTime.UtcNow;
                
                cmd = new SqlCommand("insert EnrollDet values(@Sid,@Cid,@endate)", con);
                cmd.Parameters.AddWithValue("Sid", id);
                cmd.Parameters.AddWithValue("Cid", courseid);
                cmd.Parameters.AddWithValue("endate", enrollmentdate);
                try
                {
                    rows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(rows + " rows added!");
                Console.WriteLine("You have successfully enrolled");
                enrolllist.Add(new Enroll(student, course, endate));
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }




        public List<Enroll> listOfEnrollments()
        {

            //string strconnection = @"Data Source=LAPTOP-AQTGOHKD\SQLEXPRESS;integrated security=true;initial catalog=StudentManagementSystem";
            //SqlConnection con = new SqlConnection(strconnection);
            try
            {
                con.Open();
                Console.WriteLine("Connected successfully");
                Console.WriteLine("Displaying enrollments from the database");
                SqlCommand cmd = new SqlCommand("select * from EnrollDet", con);
                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine("Records inserted into the database are: ");
                if (dr.HasRows)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", dr.GetName(0), dr.GetName(1), dr.GetName(2));
                    Console.WriteLine("-----------------------------------------------------------------------");
                    while (dr.Read())
                    {
                        Console.WriteLine(dr.GetInt32(0) + "\t\t" + dr.GetInt32(1) + "\t\t" + dr.GetDateTime(2));
                    }
                    Console.WriteLine("-----------------------------------------------------------------------");
                    dr.NextResult();
                }
                else
                {
                    Console.WriteLine("There are no rows inserted into the database");
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public void displaystudentbyid()
        {
            //string strconnection = @"Data Source=LAPTOP-AQTGOHKD\SQLEXPRESS;integrated security=true;initial catalog=StudentManagementSystem";
            //SqlConnection con = new SqlConnection(strconnection);
            try
            {
                con.Open();
                Console.WriteLine("Connected successfully");
                Console.WriteLine("Enter the id you want to filter");
                int id = Convert.ToInt32(Console.ReadLine());
                SqlCommand cmd = new SqlCommand("Select * from Student where id=@Sid", con);
                cmd.CommandType = CommandType.Text;
                SqlParameter param = new SqlParameter("@Sid", id);
                cmd.Parameters.Add(param);
                SqlDataReader dr = cmd.ExecuteReader();
                try
                {
                    Console.WriteLine("{0}\t{1}\t{2}", dr.GetName(0), dr.GetName(1), dr.GetName(2));
                    Console.WriteLine("-------------------------------------------------------------");
                    if (dr.Read())
                    {
                        Console.WriteLine(dr[0] + "\t " + dr[1] + " " + dr[2]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void displaycoursebyid()
        {
            //string strconnection = @"Data Source=LAPTOP-AQTGOHKD\SQLEXPRESS;integrated security=true;initial catalog=StudentManagementSystem";
            //SqlConnection con = new SqlConnection(strconnection);
            try
            {
                con.Open();
                Console.WriteLine("Connected successfully");
                Console.WriteLine("Enter the id you want to filter");
                int id = Convert.ToInt32(Console.ReadLine());
                SqlCommand cmd = new SqlCommand("Select * from Course_Details where Cid=@Cid", con);
                cmd.CommandType = CommandType.Text;
                SqlParameter param = new SqlParameter("@Cid", id);
                cmd.Parameters.Add(param);
                SqlDataReader dr = cmd.ExecuteReader();
                try
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}", dr.GetName(0), dr.GetName(1), dr.GetName(2), dr.GetName(3), dr.GetName(4), dr.GetName(5), dr.GetName(6), dr.GetName(7), dr.GetName(8));
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                    if (dr.Read())
                    {
                        Console.WriteLine(dr[0] + "\t " + dr[1] + " \t" + dr[2] + "\t \t" + dr[3] + " " + dr[4] + "\t " + dr[5] + "\t " + dr[6] + "\t " + dr[7] + " \t" + dr[8]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}