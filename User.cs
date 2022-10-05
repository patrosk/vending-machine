using System;
	public class User
	{
		public string Name { get; set; }
		public Bank Money { get; set; }
		public List<Item> Inventory { get; set; }

		public User(string name, Bank money)
		{
			Name = name;
			Money = money;
			Inventory = new List<Item>();
		}
	}


