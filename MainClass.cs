namespace studentmanagementsystem
{
    using System;

    public class MainClass
    {
        static void Main()
        {
            UserInterface sd = new ScreenDescription();
            do
            {
                sd.showFirstScreen();
            } while (true);
        }
    }
}