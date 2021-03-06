using System;

namespace algorithm
{
    class MainClass
    {
        public static double counter = 0;

        public static int xP = 30;
        public static int yP = 11;

        public static int Xe1 = 6;
        public static int Ye1 = 2;

        public static int Xe2 = 7;
        public static int Ye2 = 3;

        public static int Xe3 = 9;
        public static int Ye3 = 6;

        public static int Xe4 = 8;
        public static int Ye4 = 4;

        public static int Xe5 = 10;
        public static int Ye5 = 6;

        public static bool isEnemyMovingLeft = false;
        public static bool isPlayerColidingEnemy = false;

        public static void drawBorder()
        {
            Console.Write("---------------------- " + "it has been " + counter + " seconds " + "-----");
            for(int i = 0; i < 16; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
            }
            Console.SetCursorPosition(0, 15);
            Console.Write("--------------------------------------------------");
            for (int i = 0; i < 16; i++)
            {
                Console.SetCursorPosition(50, i);
                Console.Write("|");
            } 
        }

        public static void updateEnemy()
        {
            E1();
            E2();
            E3();
            E4();
            E5();
        }

        public static void E1()
        {
            if (Xe1 == 49)
            {
                isEnemyMovingLeft = true;
            }
            else if (Xe1 == 1)
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
        }
        public static void E2()
        {
            if (Xe2 == 49)
            {
                isEnemyMovingLeft = true;
            }
            else if (Xe2 == 1)
            {
                isEnemyMovingLeft = false;
            }
            if (isEnemyMovingLeft == true)
            {
                Console.SetCursorPosition(Xe2, Ye2);
                Console.Write(" ");
                Xe2--;
                Console.SetCursorPosition(Xe2, Ye2);
                Console.Write("E");
            }
            else if (isEnemyMovingLeft == false)
            {
                Console.SetCursorPosition(Xe2, Ye2);
                Console.Write(" ");
                Xe2++;
                Console.SetCursorPosition(Xe2, Ye2);
                Console.Write("E");
            }
        }
        public static void E3()
        {
            if (Ye3 == 14)
            {
                isEnemyMovingLeft = true;
            }
            else if (Ye3 == 1)
            {
                isEnemyMovingLeft = false;
            }
            if (isEnemyMovingLeft == true)
            {
                Console.SetCursorPosition(Xe3, Ye3);
                Console.Write(" ");
                Ye3--;
                Console.SetCursorPosition(Xe5, Ye3);
                Console.Write("E");
            }
            else if (isEnemyMovingLeft == false)
            {
                Console.SetCursorPosition(Xe3, Ye3);
                Console.Write(" ");
                Ye3++;
                Console.SetCursorPosition(Xe3, Ye3);
                Console.Write("E");
            }
        }
        public static void E4()
        {
            if (Xe4 == 49)
            {
                isEnemyMovingLeft = true;
            }
            else if (Xe4 == 1)
            {
                isEnemyMovingLeft = false;
            }
            if (isEnemyMovingLeft == true)
            {
                Console.SetCursorPosition(Xe4, Ye4);
                Console.Write(" ");
                Xe4--;
                Console.SetCursorPosition(Xe4, Ye4);
                Console.Write("E");
            }
            else if (isEnemyMovingLeft == false)
            {
                Console.SetCursorPosition(Xe4, Ye4);
                Console.Write(" ");
                Xe4++;
                Console.SetCursorPosition(Xe4, Ye4);
                Console.Write("E");
            }
        }
        public static void E5()
        {
            if (Ye5 == 14)
            {
                isEnemyMovingLeft = true;
            }
            else if (Ye5 == 1)
            {
                isEnemyMovingLeft = false;
            }
            if (isEnemyMovingLeft == true)
            {
                Console.SetCursorPosition(Xe5, Ye5);
                Console.Write(" ");
                Ye5--;
                Console.SetCursorPosition(Xe5, Ye5);
                Console.Write("E");
            }
            else if (isEnemyMovingLeft == false)
            {
                Console.SetCursorPosition(Xe5, Ye5);
                Console.Write(" ");
                Ye5++;
                Console.SetCursorPosition(Xe5, Ye5);
                Console.Write("E");
            }
        }

        public static void checkEnemy()
        {
            //Checking if player position = enemys position
            if ((xP == Xe1 && yP == Ye1 )||
               ( xP == Xe2 && yP == Ye2) ||
               ( xP == Xe3 && yP == Ye3) ||
               ( xP == Xe4 && yP == Ye4) ||
               ( xP == Xe5 && yP == Ye5))
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
        public static void moveUp()
        {
            if (yP == 1)
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
            if (yP == 14)
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
            if (xP == 1)
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
            if (xP == 49)
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
            drawBorder();
            Console.SetCursorPosition(xP, yP);
            Console.Write("p");
            while (true)
            {
                counter = counter + 0.09;
                updateEnemy();
                //wait here for 0.09 seconds = 90ms
                System.Threading.Thread.Sleep(90);
                checkKey();
                checkEnemy();
                if (isPlayerColidingEnemy == true)
                {
                    return;
                }
            }
        }
    }
}
