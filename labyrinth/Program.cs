using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map =
            {
                {'█', '█', '█', '█', '█', '█', '█', '█', '█', '█', '█', '█', '█', '█', '█'},
                {'█', ' ', ' ', '█', 'k', ' ', 'G', ' ', ' ', ' ', '█', ' ', ' ', 'G', '█'},
                {'█', '█', ' ', '█', '█', '█', '█', '█', '█', ' ', '█', ' ', '█', '█', '█'},
                {'█', 'G', ' ', ' ', 'G', ' ', '█', ' ', ' ', ' ', ' ', ' ', '█', 'G', '█'},
                {'█', '█', '█', '█', '█', ' ', '█', ' ', '█', ' ', '█', ' ', '█', ' ', '█'},
                {'█', ' ', ' ', ' ', '█', ' ', '█', 'G', '█', ' ', '█', ' ', ' ', ' ', '█'},
                {'█', ' ', '█', '█', '█', 'G', '█', '█', '█', '█', '█', '█', '█', ' ', '█'},
                {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', '█'},
                {'█', '█', '█', ' ', '█', '█', '█', '█', ' ', '█', '█', ' ', '█', ' ', '█'},
                {'█', ' ', ' ', ' ', '█', ' ', 'G', ' ', ' ', ' ', ' ', ' ', '█', ' ', '█'},
                {'█', '█', '█', ' ', '█', ' ', '█', '█', '█', '█', '█', 'G', '█', '█', '█'},
                {'█', 'G', '█', 'G', '█', ' ', '█', 'G', ' ', ' ', '█', ' ', ' ', ' ', '█'},
                {'█', ' ', '█', '█', '█', ' ', '█', '█', '█', ' ', '█', '█', '█', 'G', '█'},
                {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', '█'},
                {'█', '█', '█', '█', '█', '█', '█', '█', '█', '█', '█', '█', '█', '#', '█'},

            };

            int playerX = 1;
            int playerY = 1;

            char[] inventory = new char[1];
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Игрок это - '@', что бы выйграть, необходимо пройти лабиринт, но выход - '#' заперт, сначало нужно найти ключ - 'k'\n" +
                "для продолжения нажмите любую кнопку . . .");
            Console.ReadKey();
            Console.Clear();

            Console.CursorVisible = false;
            while(true)
            {
                Console.SetCursorPosition(0, 15);
                Console.Write("Инвентарь: ");
                for (int i = 0; i < inventory.Length; i++)
                {
                    Console.Write(inventory[i] + " ");
                }
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }

                Console.SetCursorPosition(playerX, playerY);
                Console.WriteLine('@');
                ConsoleKeyInfo charKey = Console.ReadKey();
                switch (charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (map[playerY - 1, playerX] != '█' && map[playerY - 1, playerX] != '#')
                        {
                            playerY--;
                            break;
                        }
                        if (map[playerY - 1, playerX] == '#' && inventory.Any(str => str == 'k'))
                        {
                            playerY--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (map[playerY + 1, playerX] != '█' && map[playerY + 1, playerX] != '#')
                        {
                            playerY++;
                            break;
                        }
                        if (map[playerY + 1, playerX] == '#' && inventory.Any(str => str == 'k'))
                        {
                            playerY++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (map[playerY, playerX - 1] != '█' && map[playerY, playerX - 1] != '#')
                        {
                            playerX--;
                            break;
                        }
                        if (map[playerY, playerX - 1] == '#' && inventory.Any(str => str == 'k'))
                        {
                            playerX--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[playerY, playerX + 1] != '█' && map[playerY, playerX + 1] != '#')
                        {
                            playerX++;
                            break;
                        }
                        if (map[playerY, playerX + 1] == '#' && inventory.Any(str => str == 'k'))
                        {
                            playerX++;
                        }
                        break;
                }

                if (map[playerY, playerX] == 'k')
                {
                    map[playerY, playerX] = ' ';
                    char[] tempInventory = new char[inventory.Length + 1];
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        tempInventory[i] = inventory[i];
                    }
                    tempInventory[tempInventory.Length - 1] = 'k';
                    inventory = tempInventory;
                }

                if (map[playerY, playerX] == 'G')
                {
                    map[playerY, playerX] = ' ';
                    char[] tempInventory = new char[inventory.Length + 1];
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        tempInventory[i] = inventory[i];
                    }
                    tempInventory[tempInventory.Length - 1] = 'G';
                    inventory = tempInventory;
                }

                if (map[playerY, playerX] == '#')
                {
                    break;
                }

            }
            Console.Clear();
            Console.WriteLine($"Ты прошёл лабиринт, и вынес с собой {inventory.Length - 2} букв G... Ты же не думал, что это золото?");
        }
    }
}
