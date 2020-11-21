using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Company {
	class Kitchen {
		private Dictionary<int, Pizza> orderList = new Dictionary<int, Pizza>();

		public Kitchen() {}

		public Kitchen AddOrder(Pizza pz) {
			orderList.Add(orderList.Count, pz);
			return this;
		}

		public Kitchen RemoveOrder(int id) {
			orderList.Remove(id);
			return this;
		}

		public Pizza MakePizza(Pizza pz) {
			Console.WriteLine("Your pizza is cooking, wait please...");
			Thread.Sleep(pz.TimeCooking);
			Console.WriteLine("Your pizza is ready!");
			return pz.Copy();
		}
	}
}
