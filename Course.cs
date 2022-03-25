namespace studentmanagementsystem
{

    using System;
    public abstract class Course
    {
        int id;
        string name;
        int duration;
        int fees;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Duration { get => duration; set => duration = value; }
        public int Fees { get => fees; set => fees = value; }

        public Course()
        {
        }

        public Course(int id, string name, int duration, int fees)
        {
            this.Id = id;
            this.Name = name;
            this.Duration = duration;
            this.Fees = fees;
        }

        public override string ToString()
        {
            return this.id + "\t\t" + this.name + "\t\t" + this.duration + "\t" + this.fees;
        }
        public abstract double calculateMonthlyFee();

    }

    public class DegreeCourse : Course
    {
        public bool isplacementavailable;
        public Boolean Isplacementavailable { get => isplacementavailable; set => isplacementavailable = value; }
        public enum Level
        {
            bachelors = 1,
            masters = 2
        }
        public Level level { get; set; }
        public DegreeCourse()
        {
        }

        public DegreeCourse(int id, string name, int duration, int fees, int Level, bool isplacementavailable) : base(id, name, duration, fees)
        {
            this.level = (Level)Level;
            this.Isplacementavailable = isplacementavailable;
        }
        public override double calculateMonthlyFee()
        {
            if (isplacementavailable)
            {
                return (double)(((0.1 * Fees) + Fees) / Duration); 
            }
            else
            {
                return (double)Fees;
            }
        }
        public override string ToString()
        {
            return this.Id + "\t" + this.Name + "\t\t" + this.Duration + "\t" + this.calculateMonthlyFee() + "\t" + this.level + "\t" + this.isplacementavailable;
        }
    }

    public class DiplomaCourse : Course
    {
        public Type type { get; set; }
        public enum Type
        {
            professional = 1,
            academic = 2
        }
        public DiplomaCourse()
        {

        }
        public DiplomaCourse(int id, string name, int duration, int fees, int Type) : base(id, name, duration, fees)
        {
            this.type = (Type)Type;
        }

        public override double calculateMonthlyFee()
        {
            if (type == Type.professional)
            {
                return (double)(((0.1 * Fees) + Fees) / Duration);
            }
            else if (type == Type.academic)
            {
                return (double)(((0.05 * Fees) + Fees) / Duration);
            }

            return (double)Fees;
        }
        public override string ToString()
        {
            return "CourseId: " + this.Id + "\t\t" + "CourseName: " + this.Name + "\t\t" + "Duration: " + this.Duration + "\t" + "CalculateMonthlyFee: " + this.calculateMonthlyFee() + "\t" + "Type: " + this.type;
        }
    }
}
