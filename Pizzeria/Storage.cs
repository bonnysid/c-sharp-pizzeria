using System;
using System.Collections.Generic;
using System.Text;

namespace Company {
	class Storage {
		private Dictionary<string, string> users = new Dictionary<string, string>();
		private Dictionary<string, Client> clients = new Dictionary<string, Client>();
		private List<Pizza> menu = new List<Pizza>();

		public List<Pizza> Menu {
			get {
				return menu;
			}

			private set {
				if (value == null) throw new Exception("Menu cannot be empty");
				menu = value;
			}
		}

		public Dictionary<string, Client> Clients {
			get {
				return clients;
			}

			private set {
				if (value == null) throw new Exception("Menu cannot be empty");
				clients = value;
			}
		}
		public Dictionary<string, string> Users {
			get {
				return users;
			}

			private set {
				if (value == null) throw new Exception("Clients cannot be empty");
				users = value;
			}
		}

		public bool AddClient(string login, string pass, Client client) {
			clients.Add(login, client);
			users.Add(login, pass);
			return true;
		}
	}
}
