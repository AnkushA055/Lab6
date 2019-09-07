using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Lab6_ExceptionHandling
{
    class LimitException : Exception
    {
        public LimitException(string message) : base(message) { }
    }
    class Customer
    {
        private string _customerId;
        private string _customerName;
        private string _address;
        private string _city;
        private string _phone;
        private int _creditLimit;

        public string CustomerId { get => _customerId; set => _customerId = value; }
        public string CustomerName { get => _customerName; set => _customerName = value; }
        public string Address { get => _address; set => _address = value; }
        public string City { get => _city; set => _city = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public int CreditLimit {
            get
            {
                return _creditLimit;
            }
            set
            {
                if (value < 5000)
                {
                    _creditLimit = value;
                }
                else
                {
                    throw new LimitException("Credit Limit Exceeded");
                }

            }
        }

        public Customer()
        {                 }

        public Customer(string customerId, string customerName, string address, string city,string phone, int creditLimit)
        {
            this.CustomerId = customerId;
            this.CustomerName = customerName;
            this.Address = address;
            this.City = city;
            this.Phone = phone;
            this.CreditLimit = creditLimit;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer customer;
            customer = new Customer();
            try
            {
                Console.WriteLine("Enter Name :");
                customer.CustomerName = Console.ReadLine();
                Console.WriteLine("Enter Customer Id :");
                customer.CustomerId = Console.ReadLine();
                Console.WriteLine("Enter Mobile :");
                customer.Phone = Console.ReadLine();
                Console.WriteLine("Enter Address :");
                customer.Address = Console.ReadLine();
                Console.WriteLine("Enter City :");
                customer.CreditLimit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Thanks");
            }

            catch(Exception ex)
            {
                FileInfo fi = new FileInfo(@"c:\Capg\Limit.txt");
                FileStream fs = new FileStream(@"c:\Capg\Limit.txt", FileMode.Append, FileAccess.Write);
                string content = $"(DateTime.Now)" +
                    $"\nMessage(ex.Message)" +
                    $"\nstack trace(ex.StackTrace)" +
                    $"\nInnerException(ex.InnerException.Message)" +
                    $"\ntype(ex.GetType().ToString())";

                byte[] barray = System.Text.Encoding.ASCII.GetBytes(content);
                fs.Write(barray, 0, barray.Length);
                fs.Close();
                System.Console.WriteLine("Unexpected Error");

            }

            finally
            {
                System.Console.WriteLine("thanks");
            }
            System.Console.ReadKey();
        }

    }
}
