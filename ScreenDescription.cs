namespace studentmanagementsystem
{
    class ScreenDescription : UserInterface
    {
		InMemoryAppEngine IAE = new InMemoryAppEngine();
		Student s = new Student();
		Course c;
		Enroll e=new Enroll();
		public void showFirstScreen()
        {
			Console.WriteLine("Welcome to SMS(Student Mgmt. System) v1.0");
			Console.WriteLine("Tell us who you are : \n1.Student \n2.Admin \n3.Exit");
			Console.WriteLine("Enter your choice ( 1 or 2 ) : ");
			try
			{
				int op = Convert.ToInt32(Console.ReadLine());
				switch (op)
				{
					case 1:
						showStudentScreen();
						break;
					case 2:
						showAdminScreen();
						break;
					case 3:
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("\nPlease enter the correct choice\n");
						break;
				}
			}
			catch(FormatException ex)
            {
				Console.WriteLine("Please enter any of the choice");
            }
		}

		public void showStudentScreen()
        {
			Console.WriteLine("-------------You are in student screen------------------");
			Console.WriteLine("Choose any of the option: \n1.Registration \n2.List of students \n3.List of courses \n4.Enroll \n5.List Of Enrollments");
			try
			{
				int choice = Convert.ToInt32(Console.ReadLine());
				switch (choice)
				{
					case 1:
						showStudentRegistrationScreen();
						break;
					case 2:
						showAllStudentsScreen();
						break;
					case 3:
						showAllCoursesScreen();
						break;
					case 4:
						IAE.addEnrollment(s,c);
						break;
					case 5:
						IAE.listOfEnrollments();
						break;
					default:
						Console.WriteLine("Please enter the correct choice");
						break;
				}
			}
			catch(FormatException ex)
            {
				Console.WriteLine("Please enter either 1 or 2 or 3 or 4");
            }

        }
		public void showAdminScreen()
        {
			Console.WriteLine("-------------You are in Admin screen------------------");
			Console.WriteLine("Choose any of the option: \n1.Introduce \n2.List Of Students \n3.List of enrollments \n4.List of courses \n5.Display student details by Id \n6.Display course details by Id");
			try
			{
				int choice = Convert.ToInt32(Console.ReadLine());
				switch (choice)
				{
					case 1:
						introduceNewCourseScreen();
						break;
					case 2:
						showAllStudentsScreen();
						break;
					case 3:
						IAE.listOfEnrollments();
						break;
					case 4:
						showAllCoursesScreen();
						break;
					case 5:
						IAE.displaystudentbyid();
						break;
					case 6:
						IAE.displaycoursebyid();
						break;
					default:
						Console.WriteLine("Please enter the correct choice");
						break;
				}
			}
			catch (FormatException ex)
			{
				Console.WriteLine("Please enter either 1 or 2 or 3 or 4");
			}
		}

		public void showStudentRegistrationScreen()
		{
			Console.WriteLine("----------------You are in student registration screen---------------------");
			addStudent();
		}
		public void showAllStudentsScreen()
        {
			IAE.listOfStudents();
		}
		public void introduceNewCourseScreen()
        {
			Console.WriteLine("------------------You are in introduce new course screen---------------------------");
			addcourse();
        }
		public void showAllCoursesScreen()
        {
			Console.WriteLine("Enter your choice\n1.Degree \n2.Diploma");
			string choice = Console.ReadLine();
			IAE.listOfCourses(choice);
		}

		public void addStudent()
		{
			try
			{
				Console.WriteLine("Enter student id: ");
				int Id = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Enter student name: ");
				string Name = Console.ReadLine();
				Console.WriteLine("Enter student dob: ");
				DateTime Dob = Convert.ToDateTime(Console.ReadLine());
				IAE.register(new Student(Id, Name, Dob));
			}
			catch (FormatException ex)
			{
				Console.WriteLine("Please enter valid input");
			}
		}

		public void addcourse()
		{

			Console.WriteLine("Enter course id: ");
			int courseid = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter course Name: ");
			string coursename = Console.ReadLine();
			Console.WriteLine("Enter the duration: ");
			int duration = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter fees: ");
			int fees = Convert.ToInt32(Console.ReadLine());
			//double fees = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Enter your choice\n1.Degree\n2.Diploma");
			string choice = Console.ReadLine();
			if (choice == "1")
			{
				Console.WriteLine("Enter your degree level:\n1.Bachelors\n2.Masters");
				int level = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Placement Available:\n1.True\n2.False");
				bool isplacementavailable = Convert.ToBoolean(Console.ReadLine());
				IAE.introduce(new DegreeCourse(courseid, coursename, duration, fees, level, isplacementavailable));
				Console.WriteLine("Course added successfully");
			}
			else if (choice == "2")
			{
				Console.WriteLine("Enter your diploma type:\n1.Professional\n2.Academic");
				int diplomatype = Convert.ToInt32(Console.ReadLine());
				IAE.introduce(new DiplomaCourse(courseid, coursename, duration, fees, diplomatype));
				Console.WriteLine("Course added successfully");
			}
            else
            {
				Console.WriteLine("Please enter the correct choice");
            }
		}
	}
}