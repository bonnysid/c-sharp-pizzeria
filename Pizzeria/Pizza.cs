using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Company {
	class Pizza {
		private string name;
		private int price;
		private int timeCooking;

		public Pizza (string name, int price, int timeCooking) {
			Name = name;
			Price = price;
			TimeCooking = timeCooking;
		}
		public string Name {
			get {
				return name;
			}

			private set {
				if (value.Trim().Equals("")) throw new Exception("Name of pizza cannot be empty!");
				name = value;
			}
		}

		public int Price {
			get {
				return price;
			}

			private set {
				if (value < 0) throw new Exception("Price cannot be less than zero!");
				price = value;
			}
		}

		public int TimeCooking {
			get { return timeCooking; }

			private set {
				if (value <= 0) throw new Exception("Time of cooking cannot be <= 0");
				timeCooking = value;
			}
		}

		public override string ToString() {
			return Name + " - " + price + ";";
		}

		public Pizza Copy() {
			return new Pizza(name, price, timeCooking);
		}

	}
}
