using System;
using System.Collections.Generic;

string heroName = "Andrei";
int health = 70;
int maxHealth = 100;
int gold = 15;
int strength = 6;
int weaponDamage = 3;
bool isRunning = true;

List<string> inventory = new List<string> { "miecz", "mikstura", "łuk" };

while (isRunning)
{
    ShowStatus(heroName, health, maxHealth, gold);
    ShowMenu();
    string command = ReadCommand();

    if (command == "1")
    {
        int damage = CalculateDamage(strength, weaponDamage);
        Console.WriteLine($"Przeciwnik trafiony zades mu {damage} obrazen.");
    }
    else if (command == "2")
    {
        health = Heal(health, 10, maxHealth);
        Console.WriteLine($"Leczenie wykonane, masz teraz {health} HP.");
    }
    else if (command == "3")
    {
        isRunning = false;
    }

    if (IsGameOver(health))
    {
        Console.WriteLine("no i kipnales XD... KONIEC GRY");
        isRunning = false;
    }
}

void ShowPanelTitle(string title, ConsoleColor backgroundColor)
{
    Console.BackgroundColor = backgroundColor;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"  {title.ToUpper()}  ");
    Console.ResetColor();
}

void ShowStatus(string name, int hp, int maxHp, int money)
{
    ShowPanelTitle("Status Bohatera", ConsoleColor.DarkBlue);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Bohater:  ");
    Console.ResetColor();
    Console.WriteLine(name);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Zdrowie:  ");
    Console.ResetColor();
    Console.WriteLine($"{hp}/{maxHp} HP");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Złoto:    ");
    Console.ResetColor();
    Console.WriteLine(money);
}

void ShowMenu()
{
    Console.WriteLine("+++++++++++++++++++++++++++++");
    ShowPanelTitle("Co robimy?", ConsoleColor.DarkCyan);
    Console.WriteLine("[1] Bitka testowa (atak)");
    Console.WriteLine("[2] odpocznij (leczenie)");
    Console.WriteLine("[3] deez nuts (finito)");
}

string ReadCommand()
{
    while (true) // menu wyboru
    {
        Console.Write("Co wybierasz?: ");
        string? choice = Console.ReadLine();

        if (choice == "1" || choice == "2" || choice == "3")
        {
            return choice;
        }

        Console.WriteLine("ale nie ma takiej opcji, sprobuj jeszcze raz.");
    }
}
// lambda
int CalculateDamage(int heroStrength, int weaponBonus) => heroStrength + weaponBonus;

int Heal(int currentHp, int healAmount, int maxHp)
{
    int newHp = currentHp + healAmount;
    return newHp > maxHp ? maxHp : newHp;
}

bool IsGameOver(int hp) => hp <= 0;