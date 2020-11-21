using System;
using System.Collections.Generic;
using System.Text;

namespace Company {
	class Starter {

		public static void Main(String[] args) {
			Pizzeria pizzeria = new Pizzeria();
			pizzeria.AddPizzaToMenu(new Pizza("Paperoni", 100, 2000), new Pizza("Gavai", 200, 5));
			pizzeria.Start();

		}

	}
}
