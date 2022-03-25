using System;

namespace studentmanagementsystem
{
    public class Student
    {
         int id;
         string name;
         DateTime dob;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Dob { get => dob; set => dob = value; }

        public Student(int id, string name, DateTime dob)
        {
            this.Id = id;
            this.Name = name;
            this.Dob = dob;
        }

        public Student()
        {

        }

        public override string ToString()
        {
            return this.id + " " + this.name + " " + this.dob;
            // $"Student(Id: {this.id}, Name: {this.name},Dob: {this.dob})"; 
        }
    }
}
