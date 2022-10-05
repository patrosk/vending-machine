// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

var money = new Bank(50);
var customer = new User("Leia", money);

var products = new List<Item>() {
	new Item("Mars", 25),
	new Item("Croissant", 35),
	new Item("Snickers", 25),
	new Item("Apple", 5),
	new Item("Banana", 5),
	new Item("Coke", 15),
};

var vendingMachine = new VendingMachine(customer, products);
vendingMachine.Start();

