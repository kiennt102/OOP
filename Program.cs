using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("===== Management Person Programe =====");
            Console.Write("The number of person: ");int n = int.Parse(Console.ReadLine());
			Person[] per = new Person[n];
			for(int i = 0; i < n; i++)
			{
                Console.WriteLine($"Enter information for person {i+1}:");
                per[i] = Person.inputPersonInfor();
			}
			Person per1 = new Person("alex","St 19",8);
			Person.displayPerson(per1);

			per= Person.SortedBySala(per);
			foreach(var s in per)
			{
				Person.displayPerson(s);
			}


            Console.ReadKey();
		}
	}
}
