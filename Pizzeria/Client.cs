using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company {
    class Client {
        private string name;
        private int cash;
        private int amountBuys;
        private Adress adress;
        private List<Pizza> pizzas = new List<Pizza>();

        public Client (string name, int cash) {
            Name = name;
            Cash = cash;
		}

        public string Name {
            get {
                return name;
            }

            private set {
                if (value.Trim().Equals("")) throw new Exception("Name cannot be empty!");
                name = value;
            }
        }

        public int Cash {
            get {
                return cash;
            }

            set {
                cash = value;
            }
        }

        public Adress Adress {
            get {
                return adress;
			}

            set {
                adress = value;
			}
		}

        public void GetPizza(Pizza pz) {
            pizzas.Add(pz);
		}
		
    }
}
