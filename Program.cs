using System.Diagnostics.Metrics;
using System.Numerics;
using System.Xml.Linq;

namespace FinalProjectFundamental
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMessage("welcome please enter your info");
            // نام
            string firstName = string.Empty;
            firstName = GetName(nameof(firstName));
            if (firstName == "exit")
                return;
            //نام خانوادگی
            string lastName = string.Empty;
            lastName = GetName(nameof(lastName));
            if (lastName == "exit")
                return;
            //شماره همراه
            string phoneNumber = string.Empty;
            phoneNumber = GetPhoneNumber(nameof(phoneNumber));
            if (phoneNumber == "exit")
                return;
            // سن
            string age = string.Empty;
            age = GetAge(nameof(age));
            if (age == "exit")
                return;
            // نمایش همه 
            ShowProfile(firstName, lastName, phoneNumber, age);
        }
        //تعریف توابع خواسته شده
        static string GetName(string visibleName)
        {
            int counter = 0;
            while (true)
            {
                PrintIncom(visibleName);// اعلام برای مقادیر
                string Name = GetName();//تعریف برای دریافت مقادیر
                if (CheckName(name: Name))// بررسی مفادیر
                {
                    PrintMessage($"your {visibleName} is registerd");
                    return Name;
                    break;
                }
                else
                {
                    counter++;
                    PrintAllert(counter, nameof(visibleName));
                    if (counter == 5)
                    {
                        return "exit";
                        // دستور return اینجا کار ساز نیست
                    }

                }
            }
        }
        static string GetPhoneNumber(string visibleName)
        {
            PrintIncom(visibleName);// اعلام برای مقادیر
            string phoneStr = string.Empty;
            phoneStr = GetPhoneNumberStr(visibleName);
            return phoneStr;
        }
        static string GetPhoneNumberStr(string visibleName)
        {
            int counter = 0;
            string phone = string.Empty;
            while (true)
            {
                phone = Console.ReadLine() ?? "";
                phone = phone.Trim();
                phone = FixNumber(phone);
                if (!string.IsNullOrEmpty(phone) && phone.Length == 11 && phone.StartsWith("0"))
                {
                    PrintMessage($"your {visibleName} is registerd");
                    return phone;
                    break;
                }
                else
                {
                    counter++;
                    PrintAllert(counter, nameof(visibleName));
                    if (counter == 5)
                    {
                        return "exit";
                        // دستور return اینجا کار ساز نیست
                    }
                }
            }
        }
        static string FixNumber(string phone)
        {

            if (phone.StartsWith("+98"))
            {
                phone = phone.Replace("+98", "0");

            }
            else if (phone.StartsWith("0098"))
            {
                phone = phone.Replace("0098", "0");
            }
            else if (phone.StartsWith("98"))
            {
                phone = phone.Replace("98", "0");
            }
            return phone;
        }
        static string GetAge(string visibleName)
        {
            int counter = 0;
            while (true)
            {
                PrintIncom(visibleName);// اعلام برای مقادیر
                string age = Console.ReadLine() ?? "";
                age = age.Trim();
                if (!string.IsNullOrEmpty(age))
                {
                    PrintMessage($"your {visibleName} is registerd");
                    return age;
                    break;
                }
                else
                {
                    counter++;
                    PrintAllert(counter, nameof(visibleName));
                    if (counter == 5)
                    {
                        return "exit";
                        // دستور return اینجا کار ساز نیست
                    }
                }

            }
        }
        static void PrintMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
        }
        static void PrintAllert(int counter, string visibleName)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"please enter a valid {visibleName} (you entered {counter} time wrong you have {5 - counter}) time ");
        }
        static void PrintIncom(string incom)
        {
            Console.WriteLine($"please enter your {incom}");
        }
        static string GetName()
        {
            string name = Console.ReadLine() ?? "";
            name = name.Trim();
            return name;
        }
        static bool CheckName(string name)
            => !string.IsNullOrEmpty(name) && name.Length > 1 ? true : false;
        static void ShowProfile(string firstName,string lastName,string  phoneNumber,string age)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"your {nameof(firstName)} is {firstName}");
            Console.WriteLine($"your {nameof(lastName)} is {lastName}");
            Console.WriteLine($"your {nameof(phoneNumber)} is {phoneNumber}");
            Console.WriteLine($"your {nameof(age)} is {age}");
        }
    }
}
