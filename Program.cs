using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			profile Kiennt = new profile();
			Kiennt.Show();
            Console.WriteLine(Kiennt.Introduce());
            Console.ReadKey();
		}
	}
}
