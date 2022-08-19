namespace appHomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employee_1 = new List<Employee>();

            Employee.AddEmployee(employee_1);

            Console.WriteLine("Через статику");

            Employee.Print(employee_1);

            Console.WriteLine("Через делегата");

            Employee.Print2(employee_1);

            Console.WriteLine("Делегат в Main");

            PrintMain(employee_1, kfd);

            Console.WriteLine("Лямбда в Main");

            Employee.lyaKoef = kffLyambda;
            Employee.Print3(employee_1);    


            static void PrintMain(List<Employee> emp, KooeffDelegate kfd)
            {
                string s = String.Empty;

                foreach (var item in emp)
                {
                    if (s.Length > 0) { s += Environment.NewLine; }
                    s += $"{item.Name} {item.Surename} : {(item.ExperienceYear + 1)*kfd(item)}";
                   // s = ToPrint2(item, KooeffDelegate(item));
                }
                Console.WriteLine(s);
            }

            static int kfd(Employee emp)
            {
                if (emp.IsHigerEducation) { return 450; }
                 else { return 300; }
            }

            //static void PrintMainLyambda(List<Employee> emp)
            //{
            //    string s = String.Empty;

            //    foreach (var item in emp)
            //    {
            //        if (s.Length > 0) { s += Environment.NewLine; }
            //        s += $"{item.Name} {item.Surename} : {(item.ExperienceYear + 1) * kfd(item)}";
            //        // s = ToPrint2(item, KooeffDelegate(item));
            //    }
            //    Console.WriteLine(s);
            //}

            static int kffLyambda(Employee emp)
            {
                if (emp.IsHigerEducation) { return 2000; }
                else { return 1800; }
            }

        }
    }
}