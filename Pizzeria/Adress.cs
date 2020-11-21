using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Company {
	class Adress {
		private string street;
		private string house;
		private int apartment;

		public Adress(string street, string house, int apartment) {
			Street = street;
			House = house;
			Apartament = apartment;
		}
		public string Street {
			get { return street; }

			set { street = value.Trim(); }
		}

		public string House {
			get { return house; }

			set {
				string pattern = @"\D";
				if (Regex.IsMatch(value, pattern)) throw new Exception("House must contains some numbers!");
				house = value;
			}
		} 

		public int Apartament {
			get { return apartment; }

			set {
				if (value < 0) throw new Exception("Apartment cannot be less than zero!");
				apartment = value;
			}
		}
	}
}
