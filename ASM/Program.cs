using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_____Caculator water bill application_____");
            string customerName = Customername();
            int customerType = Typecustomer();

            Console.Write("Last month’s water meter readings: ");
            double lastMonthReading = double.Parse(Console.ReadLine());
            Console.Write("This month’s water meter readings: ");
            double thisMonthReading = double.Parse(Console.ReadLine());
            double consumption = comsumption(thisMonthReading, lastMonthReading);
            double price = CalculatePrice(customerType ,consumption);
            double totalbill = Calculatetotalbill(price);

            Console.WriteLine("\n--- Water bill ---");
            Console.WriteLine($"Customer name: {customerName}");
            Console.WriteLine($"Last month’s water meter readings: {lastMonthReading}");
            Console.WriteLine($"This month’s water meter readings: {thisMonthReading}");
            Console.WriteLine($"Consumption: {consumption} m3");
            Console.WriteLine($"Total bill: {totalbill} VND");
        }
        static string Customername()
        {
            Console.Write("Customer name: ");
            string customername = Console.ReadLine();
            return customername;
        }
        static int Typecustomer()
        {
            Console.WriteLine("Type of customer ");
            Console.WriteLine("1: Household customer ");
            Console.WriteLine("2: Administrative agency, public services ");
            Console.WriteLine("3: Production units ");
            Console.WriteLine("4: Business services ");
            Console.Write("Your choice: ");

            int Customertype = int.Parse(Console.ReadLine());
            while (Customertype<0 || Customertype >4)
            {
                Console.WriteLine("Error, please re_enter ");
                Console.Write("Your choice: ");
                Customertype = int.Parse(Console.ReadLine());
            }
            int NumberofPeople = 0;
            if (Customertype == 1)
            {
                Console.Write("The number of people (if household customer): ");
                NumberofPeople = int.Parse(Console.ReadLine());
            }
            return Customertype;
        }
        static double comsumption(double thisMonthReading, double lastMonthReading)
        {
            // caculater consumption
            double consumption = thisMonthReading - lastMonthReading;

            while (consumption < 0 && consumption >4)
            {
                Console.WriteLine(" Error. Please re-enter: ");
                Console.WriteLine("Last month’s water meter readings: ");
                double LMW = double.Parse(Console.ReadLine());
                Console.WriteLine("This month’s water meter readings: ");
                double TMW = double.Parse(Console.ReadLine());
                consumption = thisMonthReading - lastMonthReading;
            }
            return consumption;
        }
        static double CalculatePrice(int customertype, double consumption)
        {
            double price = 0;           
            switch (customertype)
            {
                case 1: //gia dinh
                    if (consumption > 0 && consumption < 10)
                    {
                        price = consumption * 5.973;
                    }
                    else if (consumption >= 10 && consumption < 20)
                    {
                        price = (10 * 5.973) + (consumption - 10) * 7.052;
                    }
                    else if (consumption >= 20 && consumption < 30)
                    {
                        price = (10 * 5.973) + (10 * 7.052) + (consumption - 20) * 8.699;
                    }
                    else
                    {
                        price = (10 * 5.973) + (10 * 7.052) + (10 * 8.699) + (consumption - 30) * 15.929;
                    }                  
                    break;
                case 2: //hanh chinh
                    price = consumption * 9.955;
                    break;
                case 3: // don vi san xuat
                    price = consumption * 11.615;
                    break;
                case 4: // kinh doanh
                    price = consumption * 22.068;
                    break;

            }
            return price;
            
        }
        static double Calculatetotalbill(double price)
        {      
            double envFee = price * 0.1;
            double VAT = (price + envFee) * 0.1;
            double totalbill = price + envFee + VAT;
            return totalbill;
        }
    }   
}
     
