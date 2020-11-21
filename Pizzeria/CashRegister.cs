using System;
using System.Collections.Generic;
using System.Text;

namespace Company {
	class CashRegister {
		private int cash;
		private Storage db;
		private Client workingClient;



		public CashRegister() {}
		public CashRegister(int cash) {Cash = cash;}

		public int Cash {
			get {
				return cash;
			}

			private set {
				cash = value;
			}
		}

		public Storage DB {
			get {
				return db;
			}

			private set {
				if (value == null) throw new Exception("Storage cannot be empty");
				db = value;
			}
		}

		public Client WorkingClient {
			get {
				return workingClient;
			}

			set {
				workingClient = value;
			}
		}

		public bool MakeOrder(Pizza pizza, Kitchen kitchen) {
			if(pizza.Price > workingClient.Cash) {
				Console.WriteLine("You dont have money for this pizza, you should top up your balance.");
				return false;
			}
			workingClient.Cash -= pizza.Price;
			workingClient.GetPizza(kitchen.MakePizza(pizza));
			Console.WriteLine(workingClient.Name + " taked the pizza.");
			return true;

		}
	}
}
