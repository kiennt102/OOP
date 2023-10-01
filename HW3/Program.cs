using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
	class Item
	{
		protected string name_item;
		protected int quantity, price;
		public Item() { }
		public Item(string name_item, int quantity, int price)
		{
			this.name_item = name_item;
			this.quantity = quantity;
			this.price = price;
		}
		public string N_Item
		{
			get { return name_item; }
			set { name_item = value; }
		}
	
		public int N_Quantity
		{
			get { return quantity; }
			set { if(value>=0) quantity = value; }
		}
		
		public int N_Price
		{
			get { return price; }
			set { if (value > 0) price = value; }
		}
		public double getDiscount()//take discount for each products
		{
			if(N_Quantity >= 20) { return 0.2; }
			if(N_Quantity >= 40) { return 0.5; }
			if (N_Quantity > 10)
			{
				return 0.1;
			}
			else { return 0.0; }
		}
		public double getPrice()// return total money by method PRICE =PRICE*QUANTITY 
		{						// TOTAL = PRICE - PRICE* DISCOUNT
			//double P = N_Price * N_Quantity;
			//return P - P*getDiscount();
			return N_Price *N_Quantity;
		}
	}
	class GroceryBill
	{
		protected string name_clerk;
		protected List<Item> listGrocery;
		public GroceryBill() 
		{
			listGrocery = new List<Item>();
		}
		public GroceryBill(string name_clerk)
		{
			this.name_clerk = name_clerk;
			listGrocery = new List<Item>();
		}

		public string N_clerk
		{
			get { return  name_clerk; } set { if(value != null) value = name_clerk; }	
		}
		public virtual void add(Item i)// add product into container
		{
			listGrocery.Add(i);
		}
		public virtual double getTotal()// get total price of all products bought
		{
			double total_price = 0;
			foreach(Item i in listGrocery)
			{
				total_price += i.getPrice();
			}
			return total_price;
		}
		public virtual void printReceipt()
		{
            Console.WriteLine($"Nhan vien thu ngan {N_clerk}");
			Console.WriteLine("Nhung san pham da mua:");
			foreach(Item i in listGrocery)
			{
                Console.WriteLine($"\t-,{i.N_Item}\n\t +,Don gia : {i.N_Price}\n\t +,So luong : {i.N_Quantity}\n\t Thanh tien : {i.getPrice()}");
            }
            Console.WriteLine("\t\t-------------------");
            Console.WriteLine($"Tong tien : {getTotal()}");
        }
	}
	class DiscountBill : GroceryBill
	{
		protected bool status;
		protected int discountCount ;
		protected double discountAmount ;

		
		public bool Status
		{
			get { return status; }
			set { status = value; }
		}
		public int DiscountCount
		{
			get { return discountCount; }
		}
		public double DiscountAmount
		{
			get { return discountAmount; }
		}
		public DiscountBill():base() { }
		public DiscountBill(string name, bool status) : base(name)
		{
			this.status = status;
			this.discountAmount = 0.0;
			this.discountCount = 0;
		}
		public override void add(Item i)
		{
			base.add(i);
			if(status && i.getDiscount()> 0.0)
			{
				discountCount++;
				discountAmount += i.getDiscount(); 
			}
		}
		public int getDiscountCount()
		{
			return	DiscountCount;
		}
		public double getDiscountAmount()
		{
			return DiscountAmount;
		}
		public override double getTotal()
		{
			double total = base.getTotal() - base.getTotal()*getDiscountAmount();
			return total;
		}
		public override void printReceipt()
		{
			if(status)
			{
				Console.WriteLine($"Nhan vien thu ngan {N_clerk}");
				Console.WriteLine("Nhung san pham da mua:");
				foreach (Item i in listGrocery)
				{
					Console.WriteLine($"\t-,{i.N_Item}\n\t +,Don gia : {i.N_Price}\n\t +,So luong : {i.N_Quantity}.\n\t Thanh tien : {i.getPrice()}");
				}
				Console.WriteLine($"(San pham duoc giam : {getDiscountCount()})");
				Console.WriteLine($"(So luong giam      : {getDiscountAmount() * 100}%)");
				Console.WriteLine("\t\t-------------------");
				Console.WriteLine($"Tong tien : {getTotal()}");
			}
			else
			{
				base.printReceipt();
			}       
        }
	}

	internal class Program
	{
		static bool Check(string a)
		{
			if (a.ToLower() == "y") { return true; }
			else if(a.ToLower() == "n") { return false; }
			else { return false; }
		}
		static void Main(string[] args)
		{
			//Console.Write("Nhap ten thu ngan :"); string clerk = Console.ReadLine();
			//GroceryBill bil = new GroceryBill();


			//Item candy = new Item();
			//Console.Write("Nhap ten san pham :"); candy.N_Item = Console.ReadLine();
			//Console.Write("Nhap so luong     :"); candy.N_Quantity = int.Parse(Console.ReadLine());
			//Console.Write("Nhap don gia      :"); candy.N_Price = int.Parse(Console.ReadLine());
			//Console.WriteLine($"\nThanh tien   : {candy.getPrice()}");
			//bil.add(candy);


			//bil.printReceipt();

			Console.Write("Nhap ten thu ngan :"); string clerk = Console.ReadLine();
           
			int a; string status;

			while(true)// check the valid of preferred clients
			{
				Console.Write("Khach thuoc dien giam gia (Y/N) :");
				status = Console.ReadLine();
				try
				{
					if (int.TryParse(status, out a))
					{
						throw new Exception("Khong duoc phep la so!");
					}
					if (string.IsNullOrEmpty(status))
					{
						throw new Exception("Chua nhap dien khach.");
					}
					if (status.ToLower() != "y" && status.ToLower() != "n")
					{
						throw new Exception("Nhap sai ki tu!");
					}
					break;
				}
				catch (Exception e)
				{
					Console.WriteLine($"{e.Message}");
				}
			}			

            DiscountBill discountBill = new DiscountBill(clerk,Check(status));

			while(true) // input values of items
			{
				//declaration
				string n_product;
				int p_quantity;
				int p_price;
                Console.WriteLine();
                Console.Write("Nhap ten san pham :");
				n_product = Console.ReadLine();
				if (string.IsNullOrEmpty(n_product)) { break; }

				while (true)
				{
					Console.Write("Nhap so luong     :"); string quan =(Console.ReadLine());
					try
					{
						if (string.IsNullOrEmpty(quan))
						{
							throw new Exception("Chua nhap so luong.");
						}
						if (!int.TryParse(quan, out p_quantity))
						{
							throw new Exception("Phai la so!");
						}
						if (p_quantity < 0)
						{
							throw new Exception("So vua nhap khonng thoa man");
						}
						break;
					}catch(Exception e)
					{
                        Console.WriteLine($"{e.Message}");
                    }
				}

				while (true) 
				{
					Console.Write("Nhap don gia      :"); string price = (Console.ReadLine());
					try
					{
						if (string.IsNullOrEmpty(price))
						{
							throw new Exception("Chua nhap so gia.");
						}
						if (!int.TryParse(price, out p_price))
						{
							throw new Exception("Phai la so!");
						}
						if (p_price < 0)
						{
							throw new Exception("So vua nhap khonng thoa man");
						}
						break;
					}
					catch (Exception e)
					{
						Console.WriteLine($"{e.Message}");
					}
				}
				var items = new Item(n_product, p_quantity, p_price);
				discountBill.add(items);
			}
			

			//Console.WriteLine($"\nThanh tien   : {candy.getPrice()}");
			//discountBill.add(candy);
			discountBill.printReceipt();


			Console.ReadKey();
		}
	}
}
