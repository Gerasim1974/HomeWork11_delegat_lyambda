using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHomeWork
{
    delegate int KooeffDelegate(Employee employee);

    internal class Employee
    {
        const int KoefHigerEducation = 1250;
        const int KoefNotHigerEducation = 1000;

        const int KoefHigerEducationSecond = 1400;
        const int KoefNotHigerEducationSecond = 1150;

        private string _name;
        private string _surename;
        private static int _experience_year;
        private bool _is_higer_education;
        static int kff;

       public static KooeffDelegate lyaKoef = (Employee employee) => { return kff; };
 

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                while (String.IsNullOrEmpty(_name))
                {
                    Console.Write("Имя не может быть пустым! Введите пожалуйста имя работника");
                    _name = Console.ReadLine();
                }
            }
        }

        public string Surename
        {
            get { return _surename; }
            set
            {
                _surename = value;
                while (String.IsNullOrEmpty(_surename))
                {
                    Console.Write("Имя не может быть пустым! Введите пожалуйста имя работника");
                    _surename = Console.ReadLine();
                }
            }
        }

        public int ExperienceYear
        {
            get { return _experience_year; }
            set
            {
                if (value < 0)
                {
                    _experience_year = 0;
                }
                else
                {
                    _experience_year = value;
                }
            }

        }

        public bool IsHigerEducation { get; set; }

        public double CalcSalary()
        {
            double salary = 0;
            switch (IsHigerEducation)
            {
                case true:
                    salary = Convert.ToDouble((ExperienceYear + 1) * KoefHigerEducation);
                    break;
                default:
                    salary = Convert.ToDouble((ExperienceYear + 1) * KoefNotHigerEducation);
                    break;
            }
            return salary;
        }

        public  string ToPrint()
        {
            string s;
            s = $"{Name} {Surename} : {CalcSalary()}";
            return s;
        }

        public static void Print(List<Employee> sl)
        {
            {
                string s = String.Empty;
                foreach (var item in sl)
                {
                    if (s.Length > 0)
                    {
                        s += Environment.NewLine;
                    }
                    s += item.ToPrint();
                }

                Console.WriteLine(s);
            }
        }

         //с делегатом
        public double CalcSalary2(int kof)
        {
            return Convert.ToDouble((ExperienceYear + 1) * kof);
        }

        public static int KooeffDelegate(Employee emp)
        {
            if (emp.IsHigerEducation) { return KoefHigerEducationSecond; }
            else { return KoefNotHigerEducationSecond; }
        }

        public static string ToPrint2(Employee sl, int kf)
        {
            string s  = $"{sl.Name} {sl.Surename} : {sl.CalcSalary2(kf)}";
            return s;
        }

        public static void Print2(List<Employee> sl)
        {
            string s = String.Empty;
            
            foreach (var item in sl)
            {
                if (s.Length > 0) { s += Environment.NewLine; }
                s += ToPrint2(item, KooeffDelegate(item));
            }
            Console.WriteLine(s);
        }

        public static string ToPrint3(Employee sl, int kff) 
        {
            string s  = $"{sl.Name} {sl.Surename} : {sl.CalcSalary2(kff)}";
            return s;
        }

        public static void Print3(List<Employee> sl)
        {
            string s = String.Empty;

            foreach (var item in sl)
            {
                if (s.Length > 0) { s += Environment.NewLine; }
                s += ToPrint3(item, lyaKoef(item));
            }
            Console.WriteLine(s);
        }

        //public int getKoeff2(Employee emp)
        //{
        //    if (emp.IsHigerEducation == true)
        //    {
        //        return KoefHigerEducationSecond;
        //    }
        //    else
        //    {
        //        return KoefNotHigerEducationSecond;
        //    }
        //}
        public static void AddEmployee(List<Employee> sl)
        {
            bool f = true;
            while (f)
            {
                Employee employee = new Employee();
                Console.WriteLine("Введите имя");
                employee.Name = Console.ReadLine();
                Console.WriteLine("Введите фамилию");
                employee.Surename = Console.ReadLine();
                Console.WriteLine("Введите стаж в годах");
                employee.ExperienceYear = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Если есть высшее образование: введите 1, иначе 0");
                if (Console.ReadKey().KeyChar == '1')
                {
                    employee.IsHigerEducation = true;
                }
                else
                {
                    employee.IsHigerEducation = false;
                }
                sl.Add(employee);
                Console.WriteLine();    

                Console.WriteLine("Чтобы продолжить ввод сотрудников нажмите 1, иначе любую кнопку");
                if (Console.ReadKey().KeyChar != '1') { f = false; };
                Console.WriteLine();
            }
        }
    }
}
