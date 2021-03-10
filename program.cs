using System;

namespace algorithm
{
    class MainClass
    {
        #region globals
        public static string input = "";

        public static int[] dE = new int[16];

        public static int[] xE = new int[16];

        public static int[] yE = new int[16];

        public static float counter = 0;

        public static int xP = 23;
        public static int yP = 1;


        public static bool isPlayerColidingEnemy = false;
        #endregion
        public static void initEnemies()
        {
            xE[0] = 6;
            yE[0] = 2;

            xE[1] = 20;
            yE[1] = 3;

            xE[2] = 1;
            yE[2] = 4;

            xE[3] = 40;
            yE[3] = 5;

            xE[4] = 48;
            yE[4] = 6;

            xE[5] = 29;
            yE[5] = 7;

            xE[6] = 29;
            yE[6] = 8;

            xE[7] = 2;
            yE[7] = 9;

            xE[7] = 45;
            yE[7] = 10;

            xE[8] = 15;
            yE[8] = 11;

            xE[8] = 16;
            yE[8] = 12;

            xE[9] = 1;
            yE[9] = 13;

            xE[10] = 5;
            yE[10] = 14;

            xE[11] = 48;
            yE[11] = 15;

            xE[12] = 20;
            yE[12] = 16;
        }

        public static void drawBorder()
        {
            Console.Write("---------------------- it has been 0.00  seconds --");
            for(int i = 0; i < 18; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
            }
            Console.SetCursorPosition(0, 17);
            Console.Write("--------------------------------------------------");
            for (int i = 0; i < 18; i++)
            {
                Console.SetCursorPosition(50, i);
                Console.Write("|");
            } 
        }

        public static void updateEnemy()
        {
            for (int i = 0; i < 13; i++)
            {
                if (xE[i] == 49)
                {
                    dE[i] = 0;
                }
                else if (xE[i] == 1)
                {
                    dE[i] = 1;
                }
                if (dE[i] == 0)
                {
                    Console.SetCursorPosition(xE[i], yE[i]);
                    Console.Write(" ");
                    xE[i]--;
                    Console.SetCursorPosition(xE[i], yE[i]);
                    //todo: make arr if you want names
                    Console.Write("E");
                }
                else if (dE[i] == 1)
                {
                    Console.SetCursorPosition(xE[i], yE[i]);
                    Console.Write(" ");
                    xE[i]++;
                    Console.SetCursorPosition(xE[i], yE[i]);
                    Console.Write("E");
                }
            }
        }

        public static void titleScreen()
        {
            Console.WriteLine("Would you like hard mode or easy mode? Q = easy A = hard");
            input = Console.ReadLine();
            Console.WriteLine("Nice choice! When you are ready to start press any key!");
            Console.ReadKey();
            Console.Clear();
        }

        #region checks
        public static void checkEnemy()
        {
            //Checking if player position = enemys position
            for (int i = 0; i < 16; i++)
            {
                if (xE[i] == xP && yP == yE[i])
                {
                    isPlayerColidingEnemy = true;
                }
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
        #endregion

        #region moves
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
            if (yP == 17)
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
        #endregion

        public static void Main(string[] args)
        {
            //titleScreen();
            drawBorder();
            Console.SetCursorPosition(xP, yP);
            Console.Write("p");
            initEnemies();
            bool loopCondition = true;
            while (loopCondition == true)
            {
                counter = counter + 0.09f;
                Console.SetCursorPosition("---------------------- it has been ".Length, 0);
                Console.Write(counter.ToString("#.##"));
                updateEnemy();
                //wait here for 0.09 seconds = 90ms
                System.Threading.Thread.Sleep(90);
                checkKey();
                checkEnemy();
                if (isPlayerColidingEnemy == true)
                {
                    Console.Clear();
                    loopCondition = false;
                }
                else if (yP == 17)
                {
                    Console.Clear();
                    Console.WriteLine("Congradtulations, you won!");
                    Console.ReadKey();
                    return;
                }
            }
            Console.Clear();
            Console.WriteLine("You fialed, try agian later loser!");
            Console.ReadKey();
            return;
        }
    }
}
