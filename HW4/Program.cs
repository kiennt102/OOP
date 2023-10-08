using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{

	class Account
	{
		protected string name;
		protected int id;
		protected int numberAccount ;
		protected double currentMoney, rate = 0.5;

		public double CurrentMoney 
		{ 
			get { return currentMoney;} 
			set { if (value > 0) { currentMoney = value; } }
		}

		public int NumberAccount
		{
			get { return numberAccount; }
			set { if(value>0) numberAccount = value ;  }
		}
		public int Id
		{
			get { return id; }
			set { if (value > 0) { id = value; } }
		}
		public double Rate
		{
			get { return rate; }
			set { if(value>0) rate = value; }
		}
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public Account() { }
		public Account (string name, int id,int numbrt )
		{
			this.name = name;
			this.id = id;
			this.NumberAccount = numbrt;
		}
	}

	class BankManagement
	{
		//protected Account ac;
		public List<Account> listAccount;
		public static int number = 900;
		public BankManagement()
		{
			listAccount = new List<Account>();
		}

		public void CreateNew()
		{
			int n,m;
			while(true)
			{
				Console.Write("So luong tai khoan muon tao moi :"); n = int.Parse(Console.ReadLine());
				if(n < 0)
				{
                    Console.WriteLine("So luong khong thich hop.");
				}
				else { break; }

			}

			while (n > 0)
			{
				Console.Write("Ho ten chu tai khoan  :"); string name = Console.ReadLine();
				Console.Write("So cmnd               :"); int id = int.Parse(Console.ReadLine());
				var account = new Account(name, id,number);
				listAccount.Add(account);
				number++;
				n--;
			}
        }

		public void Display()
		{
			foreach( Account account in listAccount )
			{
                Console.WriteLine($"\tThong tin tai khoan trong he thong: {account.NumberAccount}");
				Console.WriteLine($"+,So tai khoan : {account.NumberAccount}\n+,Chu tai khoan :{account.Name}\n+,So can cuoc :{account.Id}\n+,So tien hien co :{account.CurrentMoney}");
            }
		}

		public void AddMoney()
		{
			int flag = 0;
            Console.Write("Nhap so tai khoan muon them tien :"); number = int.Parse(Console.ReadLine());
			foreach(var s in listAccount)
			{
				if(s.NumberAccount == number) 
				{
					flag = 1;
					Console.Write("So tien muon them :");int money = int.Parse(Console.ReadLine());
					s.CurrentMoney = money;
					break;
				}
			}
			if(flag == 0)
			{				
				Console.WriteLine("So tai khoan khong ton tai.");
			}
			else { Console.WriteLine("Them tien thanh cong."); }
        }

		public void Take()
		{
			Console.Write("Nhap so tai khoan muon rut tien :");int number = int.Parse(Console.ReadLine());
			foreach (var s in listAccount)
			{
				if (s.NumberAccount == number)
				{
					Console.Write("So tien muon rut :");int money = int.Parse(Console.ReadLine());
					if(money < s.CurrentMoney)
					{
						s.CurrentMoney -= money;
						Console.WriteLine($"Rut thanh cong {money}Đ.");

					}
					else
					{
						Console.WriteLine("So tien trong tai khoan khong du.");
					}
				}
				else
				{
					Console.WriteLine("Khong tim thay tai khoan.");
				}
			}
		}

		public void DisplayAcc()
		{
            Console.Write("So tai khoan muon xem so du:");int num = int.Parse(Console.ReadLine());
			int flag = 0;
			foreach(var s in listAccount)
			{
				if(s.NumberAccount == num)
				{
					flag = 1;
                    Console.WriteLine($"So du tai khoan {s.Name}-{s.Id} la: {s.CurrentMoney}");
                }
			}
			if(flag ==0)
			{
                Console.WriteLine("Khong tim thay tai khoan.");
            }
        }

		public void UpdateAll(int year)
		{
            Console.Write("Thay doi lai suat (C/K) :");string a = Console.ReadLine();
           // Console.Write("So nam :");year = int.Parse(Console.ReadLine());
            if (a.ToLower() == "k" ) 
			{
				Console.WriteLine($"\tThong tin va so tien hien co sau {year} nam la");
				foreach(var s in listAccount)
				{
					Console.WriteLine($"+,So tai khoan : {s.NumberAccount}\n+,Chu tai khoan :{s.Name}\n+,So can cuoc :{s.Id}\n+,So tien hien co :{s.CurrentMoney=s.CurrentMoney + s.CurrentMoney *s.Rate}");
					Console.WriteLine();
				}

			}
			else if (a.ToLower() == "c")
			{
				Console.Write("Nhap lai suat moi :");double rate = int.Parse(Console.ReadLine());
				Console.WriteLine($"\tThong tin va so tien hien co sau {year} nam khi lai suat thay doi la:");
				foreach (var s in listAccount)
				{
					s.Rate = rate;
					Console.WriteLine($"+,So tai khoan : {s.NumberAccount}\n+,Chu tai khoan :{s.Name}\n+,So can cuoc :{s.Id}\n+,So tien hien co :{s.CurrentMoney = s.CurrentMoney+ s.CurrentMoney*s.Rate}");
                    Console.WriteLine();
                }
			}
			else
			{
				Console.WriteLine("Lua chon khong thich hop.");
			}
		}

		public void Tranfer(int currentAcc,int TranferAcc,int money)
		{
			//Console.Write("Tai khoan chuyen tien    :"); currentAcc = int.Parse(Console.ReadLine());
			//Console.Write("So tai khoan muon chuyen :"); TranferAcc = int.Parse(Console.ReadLine());
			//Console.Write("So tien muon chuyen      :"); money = int.Parse(Console.ReadLine());
			foreach (var s in listAccount)
			{
				if(s.NumberAccount == currentAcc)
				{
					if(money < s.CurrentMoney)
					{
						foreach(var s2 in listAccount)
						{
							if (s2.NumberAccount == TranferAcc)
							{
								s.CurrentMoney -= money;
								s2.CurrentMoney += money; 
								Console.WriteLine("Chuyen tien thanh cong");
							}
							else { Console.WriteLine("Khong ton tai tai khoan huong thu.");break; }
						}

					}
					Console.WriteLine("Khong du so du.");

				}
				else
				{
					Console.WriteLine("Khong tim thay tai khoan goc.");break;
				}
			}
		}
	}
	internal class Program
	{
		public static void Menu()
		{
            Console.WriteLine();
            Console.WriteLine("0: Hien thi tai khoan hien co trong he thong.");
            Console.WriteLine("1: Tao tai khoan moi.");
            Console.WriteLine("2: Nap tien vao tai khoan.");
            Console.WriteLine("3: Rut tien.");
            Console.WriteLine("4: Thong tin tai khoan.");
            Console.WriteLine("5: Tinh lai suat.");
            Console.WriteLine("6: Chuyen tien noi bo.");
			Console.WriteLine("7: Thoat he thong.");
			Console.WriteLine("----------------------------------------------");
        }
		static void Main(string[] args)
		{
			BankManagement mbbank = new BankManagement();
			int n;


			while (true)
			{

				Menu();
				#region
				//try
				//{
				//	Console.Write("Nhap lua chon :"); string nn = (Console.ReadLine());
				//	if (string.IsNullOrEmpty(nn))
				//	{
				//		throw new Exception("Chua lua chon.");
				//	}
				//	if(!int.TryParse(nn, out n))
				//	{
				//		throw new Exception("Lua chon khong dung.");
				//                }
				//	if(n < 0 || n > 6)
				//	{
				//		throw new Exception("Nhap lai lua chon");
				//	}
				//	break;
				//}
				//catch(Exception e)
				//{
				//                Console.WriteLine($"{e.Message}");
				//            }
				#endregion
				while (true)
				{
					Console.Write("Nhap lua chon :"); n = int.Parse(Console.ReadLine());
					if(n < 0 || n > 6)
					{
						Console.WriteLine("Lua chon khong thich hop.");
					}
					if(n.ToString().Length == 0)
					{
                        Console.WriteLine("Lua chon khong phu hop.");
                    }
					if(n >= 0 && n<= 6)
					{
						break;
					}
				}

				switch (n)
				{
					case 0:
						Console.Clear();
						if (mbbank.listAccount.Count() == 0)
						{
							Console.WriteLine("Chua ton tai tai khoan nao.");
						}
						else
						{
							mbbank.Display();
						}
						break;
					case 1:
						Console.Clear();
						mbbank.CreateNew();
						break;
					case 2:
						Console.Clear();
						mbbank.AddMoney();
						break;
					case 3:
						Console.Clear();
						mbbank.Take();
						break;
					case 4:
						Console.Clear();
						mbbank.DisplayAcc();
						break;
					case 5:
						Console.Clear();
                        Console.Write("Thoi gian gui tien :");int time = int.Parse(Console.ReadLine());
                        mbbank.UpdateAll(time);
						break;
					case 6:
						Console.Clear();
						Console.WriteLine("Chuyen tien noi bo");
                        Console.Write("So tai khoan huong thu :");int tanacc = int.Parse(Console.ReadLine());
                        Console.Write("Tai khoan chuyen tien  :");int curracc = int.Parse(Console.ReadLine());
                        Console.Write("So tien chuyen         :");int money1 = int.Parse(Console.ReadLine());
						mbbank.Tranfer(curracc,tanacc,money1);
						break;
                }
	

			}

			Console.ReadKey();
		}
	}
}
