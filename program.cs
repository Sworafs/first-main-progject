using System;

namespace bit_space_pirate_trianer_VR
{
    class MainClass
    {
        public static int xP = 30;
        public static int yP = 10;
        public static int xE = 10;
        public static int yE = 10;
        public static bool isEnemyMovingLeft = false;
        public static void updateEnemy ()
        {
            if (xE == 50)
            {
                isEnemyMovingLeft = true;
            }
            else if (xE == 0)
            {
                isEnemyMovingLeft = false;
            }
            if (isEnemyMovingLeft == true)
            {
                Console.SetCursorPosition(xE, yE);
                Console.Write(" ");
                xE--;
                Console.SetCursorPosition(xE, yE);
                Console.Write("E");
            }
            else if (isEnemyMovingLeft == false)
            {
                Console.SetCursorPosition(xE, yE);
                Console.Write(" ");
                xE++;
                Console.SetCursorPosition(xE, yE);
                Console.Write("E");
            }
        }
        public static void checkKey ()
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
                }
                else if (pressed.Key == ConsoleKey.S)
                {
                    moveDown();
                }
                else if (pressed.Key == ConsoleKey.D)
                {
                    moveRight();
                }
                else if (pressed.Key == ConsoleKey.A)
                {
                    moveLeft();
                }
            }
        }
        public static void moveUp ()
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
            Console.SetCursorPosition(xE, yE);
            Console.Write("E");
            while (true)
            {
                updateEnemy();
                checkKey();
            }
        }
    }
}

