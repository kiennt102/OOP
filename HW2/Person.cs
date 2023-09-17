using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
	internal class Person
	{
		private	string name;
		private string address;
		private double salary;

		public Person(string n,string a,double s)
		{
			this.name = n;
			this.address = a;
			this.salary = s;	
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public string Address
		{
			get { return address; }
			set { address = value; }
		}

		public double Salary
		{
			get { return salary; }
			set { salary = value; }
		}

		public static Person inputPersonInfor()
		{
            Console.WriteLine("Information of Person");
            Console.Write("Please input name: "); string n = Console.ReadLine();
            Console.Write("Please input address: "); string a = Console.ReadLine();
			double s;
			while (true)
			{
				try
				{
					string ss;
					Console.Write("Please input salary: "); ss = Console.ReadLine();
					if (string.IsNullOrEmpty(ss))
					{
						throw new Exception("You must enter value for salary.");
					}
					if (!double.TryParse(ss,out s))
					{
						throw new Exception("You must enter valid number for salary.");
					}
					if (s < 0)
					{
						throw new Exception("Salary must be greater than zero.");
					}
					break;
				}
				catch(Exception ex) 
				{
					Console.WriteLine($"{ex.Message}");
				}			
			}
			return new Person(n, a, s);
        }

		public static void displayPerson(Person person)
		{
            Console.WriteLine("Information of Person you have entered: ");
            Console.WriteLine($"Name: {person.Name}");
			Console.WriteLine($"Address: {person.Address}");
			Console.WriteLine($"Salary: {person.Salary}");
			Console.WriteLine();
        }

		public static Person[] SortedBySala(Person[]p)
		{
			try
			{
				for(int i = 0; i < p.Length; i++)
				{
					for(int j = 0; j < p.Length; j++)
					{
						if (p[i].Salary < p[j].Salary)
						{
							Person temp = p[j];
							p[j] = p[i];
							p[i] = temp;
						}
					}
				}return p;
			}
			catch (Exception )
			{
				throw new Exception("Can't sort.");
			}
		}
	}
}
