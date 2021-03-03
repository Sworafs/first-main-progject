using System;

namespace algorithm
{
    class MainClass
    {
        public static int xP = 30;
        public static int yP = 10;
        public static int Xe1 = 10;
        public static int Ye1 = 10;
        public static int Xe2 = 10;
        public static int Ye2 = 20;
        public static bool isEnemyMovingLeft = false;
        public static bool isPlayerColidingEnemy = false;
        public static void updateEnemy()
        {
            if (Xe1 == 50)
            {
                isEnemyMovingLeft = true;
            }
            else if (Xe1 == 0)
            {
                isEnemyMovingLeft = false;
            }
            if (isEnemyMovingLeft == true)
            {
                Console.SetCursorPosition(Xe1, Ye1);
                Console.Write(" ");
                Xe1--;
                Console.SetCursorPosition(Xe1, Ye1);
                Console.Write("E");
            }
            else if (isEnemyMovingLeft == false)
            {
                Console.SetCursorPosition(Xe1, Ye1);
                Console.Write(" ");
                Xe1++;
                Console.SetCursorPosition(Xe1, Ye1);
                Console.Write("E");
            }
            if (Xe2 == 0)
            {
                Console.SetCursorPosition(Xe2, Ye2);
                Console.Write(" ");
                Xe2 = 50;
                Random r = new Random();
                int randomNumber = r.Next(1, 20);
                Ye2 = randomNumber;
            }
            else
            {
                Console.SetCursorPosition(Xe2, Ye2);
                Console.Write(" ");
                Xe2--;
                Console.SetCursorPosition(Xe2, Ye2);
                Console.Write("E");
            }
        }
        public static void checkEnemy()
        {
            if (xP == Xe1 || xP == Xe2)
            {
                isPlayerColidingEnemy = true;
            }
            else if (xP == Ye1 || xP == Ye2)
            {
                isPlayerColidingEnemy = true;
            }
        }
        public static void checkKey()
        {
            //Check if the user is pressing any key
            if (Console.KeyAvailable)
            {
                //Assign the key to a variable so we can work with it
                ConsoleKeyInfo pressed = Console.ReadKey(true);
                //check if the key is W
                if (pressed.Key == ConsoleKey.W)
                {
                    moveUp();
                    checkEnemy();
                }
                else if (pressed.Key == ConsoleKey.S)
                {
                    moveDown();
                    checkEnemy();
                }
                else if (pressed.Key == ConsoleKey.D)
                {
                    moveRight();
                    checkEnemy();
                }
                else if (pressed.Key == ConsoleKey.A)
                {
                    moveLeft();
                    checkEnemy();
                }
            }
        }
        public static void moveUp()
        {
            if (yP == 0)
            {
                return;
            }
            Console.SetCursorPosition(xP, yP);
            Console.Write(" ");
            yP--;
            Console.SetCursorPosition(xP, yP);
            Console.Write("p");
        }
        public static void moveDown()
        {
            if (yP == 20)
            {
                return;
            }
            Console.SetCursorPosition(xP, yP);
            Console.Write(" ");
            yP++;
            Console.SetCursorPosition(xP, yP);
            Console.Write("p");
        }
        public static void moveLeft()
        {
            if (xP == 0)
            {
                return;
            }
            Console.SetCursorPosition(xP, yP);
            Console.Write(" ");
            xP--;
            Console.SetCursorPosition(xP, yP);
            Console.Write("p");
        }
        public static void moveRight()
        {
            if (xP == 50)
            {
                return;
            }
            Console.SetCursorPosition(xP, yP);
            Console.Write(" ");
            xP++;
            Console.SetCursorPosition(xP, yP);
            Console.Write("p");
        }
        public static void Main(string[] args)
        {
            Console.SetCursorPosition(xP, yP);
            Console.Write("p");
            Console.SetCursorPosition(Xe1, Ye1);
            Console.Write("E");
            Console.SetCursorPosition(Xe2, Ye2);
            Console.Write("E");
            while (true)
            {
                checkKey();
                updateEnemy();
                if (isPlayerColidingEnemy == true)
                {
                    return;
                }
            }
        }
    }
}
