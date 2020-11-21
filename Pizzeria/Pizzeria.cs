using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Company {
    class Pizzeria {
        private List<Client> clients = new List<Client>();
        private Kitchen kitch = new Kitchen();
        private Storage stor = new Storage();
        private CashRegister cR = new CashRegister();
        private string adminLogin;
        private string adminPass;

        public Pizzeria() {
            adminLogin = "admin";
            adminPass = "admin";
            stor.Users.Add(adminLogin, adminPass);
        }

        public Pizzeria(string admLog, string admPass) {
            adminLogin = admLog;
            adminPass = admPass;
            stor.Users.Add(adminLogin, adminPass);
        }

        public Pizzeria(Kitchen kitch, Storage stor, CashRegister cR) {
            Kitch = kitch;
            Stor = stor;
            CR = cR;
            adminLogin = "admin";
            adminPass = "admin";
            stor.Users.Add(adminLogin, adminPass);
        }

        public Pizzeria(string admLog, string admPass, Kitchen kitch, Storage stor, CashRegister cR) {
            Kitch = kitch;
            Stor = stor;
            CR = cR;
            adminLogin = admLog;
            adminPass = admPass;
            stor.Users.Add(adminLogin, adminPass);
        }
        public Kitchen Kitch {
            get { return kitch; }

            private set {
                if (value == null) throw new Exception("Kitchen cannot be empty");
                kitch = value;
            }
        }
        public Storage Stor {
            get { return stor; }

            private set {
                if (value == null) throw new Exception("Storage cannot be empty");
                stor = value;
            }
        }
        public CashRegister CR {
            get { return cR; }

            private set {
                if (value == null) throw new Exception("Cash Register cannot be empty");
                cR = value;
            }
        }

        public void AddPizzaToMenu(params Pizza[] pizzas) {
            stor.Menu.AddRange(pizzas);
		}
        private void MakeOrder() {
            ShowPizzas();
            Console.Write("Select pizza: ");
            int ans = Convert.ToInt32(Console.ReadLine());
            cR.MakeOrder(stor.Menu[ans], Kitch);
            ShowMenu();
        }

        private void Login() {
            Console.Write("Login:");
            string login = Console.ReadLine().Trim();

            while (!stor.Users.ContainsKey(login)) {
                Console.WriteLine("Incorrect login. Try again");
                Console.Write("Login:");
                login = Console.ReadLine().Trim();
            }

            Console.Write("Password:");
            string pass = Console.ReadLine().Trim();

            while (stor.Users[login] != pass) {
                Console.WriteLine("Incorrect password. Try again");
                Console.Write("Password:");
                pass = Console.ReadLine().Trim();
            }
            cR.WorkingClient = stor.Clients[login];
            ShowMenu();
        }

        private void Registration() {
            Console.Write("Login:");
            string login = Console.ReadLine().Trim();

            while (stor.Users.ContainsKey(login)) {
                Console.WriteLine("This login is busy. Try another!");
                Console.Write("Login:");
                login = Console.ReadLine().Trim();
            }

            Console.Write("Password:");
            string pass = Console.ReadLine().Trim();

            Console.Write("Repeat password:");
            string repPass = Console.ReadLine().Trim();

            while (pass != repPass) {
                Console.WriteLine("Passwords do not match! Try again!");
                Console.Write("Repeat password:");
                repPass = Console.ReadLine().Trim();
            }

            Console.WriteLine("How can we call you?");
            Console.Write("Name: ");
            string name = Console.ReadLine().Trim();
            stor.AddClient(login, pass, new Client(name, 1000));
            cR.WorkingClient = stor.Clients[login];
            Console.WriteLine("Hello " + name + ", your balance: 1000");
            ShowMenu();
        }

        private void ShowMenu() {
            Console.WriteLine("------MENU-----" +
                "\n1) Show all pizzas" +
                "\n2) Make order" +
                "\n3) Balance" +
                "\n4) Top up balance" +
                "\n5) Exit from account" +
                "\n6) Exit" +
                "\n----------------");
            

            switch (Console.ReadLine()) {
                case "1":
                    ShowPizzas();
                    ShowMenu();
                    break;
                case "2":
                    MakeOrder();
                    break;
                case "3":
                    ShowBalance();
                    break;
                case "4":
                    TopUpBalance();
                    break;
                case "5":
                    cR.WorkingClient = null;
                    Start();
                    break;
                case "6":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Incorrect answer, try again...");
                    ShowMenu();
                    break;
            }
        }

        public void Start() {
            Console.WriteLine("Welcome! Are you registered?" +
                "\n1) Yes " +
                "\n2) No " +
                "\n3) Exit ");
         
            switch (Console.ReadLine()) {
                case "1":
                    Login();
                    break;
                case "2":
                    Registration();
                    break;
                case "3":
                    Exit();
                    break;
            }
        }

        public void Exit() {
            Process.GetCurrentProcess().Kill();
        }

        private void ShowPizzas() {
            Console.WriteLine("------Pizzas Menu ------");
            for (int i = 0; i < stor.Menu.Count; i++) { Console.WriteLine(i + 1 + ") " + stor.Menu[i]); }
            Console.WriteLine("------------------------");
        }

        private void TopUpBalance() {
            Console.Write("Input replenishment amount: ");
            int money = Convert.ToInt32(Console.ReadLine());
            while ( money < 0 ) {
                Console.Write("Replenishment amount cannot be less than zero, try again: ");
                money = Convert.ToInt32(Console.ReadLine());
            }
            cR.WorkingClient.Cash += money;
            Console.WriteLine("Now your blance: " + cR.WorkingClient.Cash);
            ShowMenu();
        }

        private void ShowBalance() {
            Console.WriteLine("Your balance: " + cR.WorkingClient.Cash);
            ShowMenu();
		}

        private void ShowAdminMenu() {
            Console.WriteLine("------ADMIN MENU-----" +
                "\n1) Add pizza to menu" +
                "\n2) Check sales" +
                "\n3) Show all users" +
                "\n4) Top up balance some user" +
                "\n5) Exit from account" +
                "\n6) Exit" +
                "\n----------------------");


            switch (Console.ReadLine()) {
                case "1":
                    
                    break;
                case "2":
                    MakeOrder();
                    break;
                case "3":
                    ShowBalance();
                    break;
                case "4":
                    TopUpBalance();
                    break;
                case "5":
                    cR.WorkingClient = null;
                    Start();
                    break;
                case "6":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Incorrect answer, try again...");
                    ShowMenu();
                    break;
            }
        }

        private void AddPizza() {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            while (!CheckPizza(name)) {
                Console.Write("This pizza already contains in the menu, try another: ");
                name = Console.ReadLine();
            }

            Console.WriteLine("Price: ");
            int price = Convert.ToInt32(Console.Read());
            while (price < 0) {
                Console.Write("Price cannot be less than zero, try again: ");
                price = Convert.ToInt32(Console.Read());
            }

            Console.WriteLine("Time of cooking: ");
            int timeCooking = Convert.ToInt32(Console.Read());

            while (timeCooking <= 0) {
                Console.Write("Time of cooking cannot be less than zero, try again: ");
                timeCooking = Convert.ToInt32(Console.Read());
            }

            AddPizzaToMenu(new Pizza(name, price, timeCooking));
        }

        private void ChangePizza() {
            ShowPizzas();
            Console.WriteLine("Select the pizza: ");
            int ans = Convert.ToInt32(Console.Read());
        }

        private bool CheckPizza(string name) {
            bool check = true;
            stor.Menu.ForEach(pizza => {
                if (pizza.Name == name) {
                    check = false;
                    return;
				}
            });

            return check;
		}
    }
}
