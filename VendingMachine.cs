using System;
using System.Collections.Generic;

	public class VendingMachine
	{

		public User Customer { get; set; }
		public List<Item> Inventory { get; set; }
		public List<string> Options { get; } = new List<string>
        {
			"buy",
			"balance",
			"inventory",
			"exit"
        };

		public VendingMachine(User customer, List<Item> inventory)
		{
		Customer = customer;
		Inventory = inventory;

		Start();

		}

		public void Start()
		{
        Console.WriteLine("");
		Console.WriteLine($"Welcome to this awesome vending machine, {Customer.Name}!");

		string command;

		do
		{
			command = GetCommand();

			if (command == "buy")
			{
				Buy();
			}
            if (command == "balance")
            {
				ShowBalance();
            }
            if (command == "inventory")
            {
				ShowInventory();
            }

		} while (command != "exit");

        if (command == "exit")
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Thanks for stopping by. See you next time!");
            Console.ResetColor();
            return;
        }
    }

		public string GetCommand()
		{
			while (true)
			{
			Console.Write("Please input a command. Available commands:");
            Console.WriteLine("");
            foreach (var command in Options)
            {
                Console.WriteLine(command);
            }
				Console.WriteLine("");

				var input = Console.ReadLine()!;

				if (Options.Contains(input))
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("OK");
					Console.WriteLine();
					Console.ResetColor();

					return input;
				}

				Console.WriteLine("?");
				Console.WriteLine();
			}
		}
		
		public void List()
    {
        foreach (var Product in Inventory)
        {
            var i = Inventory.IndexOf(Product);
            Console.WriteLine($"ID: {i}: {Product.Name} -- {Product.Price} SEK");
        }
    }


		public void ShowBalance()
    {
        Console.WriteLine($"You have {Customer.Money.Money} SEK left.");
    }

	public void Buy()
    {
		Console.WriteLine("Let us show you what we have!");
		Console.WriteLine("");
		List();
		Console.WriteLine("");
		Console.WriteLine("Enter ID of item you wish to buy.");
		Console.WriteLine("");
		var select = Console.ReadLine();

		if (int.TryParse(select, out var number))
		{
			foreach (var Product in Inventory)
			{
				if (number == Inventory.IndexOf(Product))
				{
					Console.WriteLine($"You have selected {Product.Name} at the cost of {Product.Price} SEK. Proceed? (y/n)");
					var answer = Console.ReadLine();

					if (answer == "y" || answer == "Y")
					{
                        if (Customer.Money.Money >= Product.Price)
                        {
							Customer.Money.Money -= Product.Price;
							Console.WriteLine($"You have bought {Product.Name}. Enjoy!");
							Customer.Inventory.Add(Product);
                            Console.WriteLine();
							return;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, you don't have enough money. Choose something else.");
                            Console.WriteLine();
							return;
                        }
					}
					else
					{
						Console.WriteLine("Purchase cancelled.");
                        Console.WriteLine();
						return;
						
					}
				}

			}
            Console.WriteLine("That product does not exist. Try again.");
            Console.WriteLine();
					return;
		}
		else
		{
			Console.WriteLine("Invalid input. Try again.");
		}
	}

	public void ShowInventory()
    {
        Console.WriteLine("Here are your products!");
        foreach (var Product in Customer.Inventory)
        {
            Console.WriteLine(Product.Name);
        }
            Console.WriteLine();
    }

	}

	


