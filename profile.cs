using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
	class profile
	{
		private string fullName;
		private int id;
		private string klass;
		private string github;
		private string email;

		public profile()
		{
			fullName = "Nguyen Trung Kien";
			id = 10122222;
			klass = "12422TN";
			github = "Kiennt102";
			email = "trungkien302004@gmail.com";
		}

		public string Introduce()
		{
			return $"Hello! My fullname is {fullName}, {id} is my id. Im student at {klass}. Contact me throught my github :{github} or email:{email}";
		}

		public void Show()
		{
            Console.WriteLine($"{fullName}\t{id}\t{klass}\t{github}\t{email}");
		}
	}
}
