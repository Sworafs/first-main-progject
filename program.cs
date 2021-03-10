using System;

namespace algorithm
{
    class MainClass
    {
        #region globals
        public static int difficulty = 0;

        public static string[] nE = new string[16];

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
            nE[0] = "A";

            xE[1] = 20;
            yE[1] = 3;
            nE[1] = "B";

            xE[2] = 1;
            yE[2] = 4;
            nE[2] = "C";

            xE[3] = 40;
            yE[3] = 5;
            nE[3] = "D";

            xE[4] = 48;
            yE[4] = 6;
            nE[4] = "E";

            xE[5] = 29;
            yE[5] = 7;
            nE[5] = "F";

            xE[6] = 29;
            yE[6] = 8;
            nE[6] = "G";

            xE[7] = 2;
            yE[7] = 9;
            nE[7] = "H";

            xE[8] = 45;
            yE[8] = 10;
            nE[8] = "I";

            xE[9] = 15;
            yE[9] = 11;
            nE[9] = "J";

            xE[10] = 16;
            yE[10] = 12;
            nE[10] = "K";

            xE[11] = 1;
            yE[11] = 13;
            nE[11] = "L";

            xE[12] = 5;
            yE[12] = 14;
            nE[13] = "N";

            xE[13] = 48;
            yE[13] = 15;
            nE[14] = "O";

            xE[14] = 20;
            yE[14] = 16;
            nE[14] = "Q";

            xE[15] = 3;
            yE[15] = 16;
            nE[15] = "R";
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
            for (int i = 0; i < 16; i++)
            {
                if (xE[i] == 49)
                {
                    dE[i] = 0;
                }
                else if (xE[i] == 1)
                {
                    dE[i] = 1;
                }
                Console.SetCursorPosition(xE[i], yE[i]);
                Console.Write(" ");
                if (dE[i] == 0)
                {
                    xE[i]--;
                }
                else if (dE[i] == 1)
                {
                    xE[i]++;
                }
                Console.SetCursorPosition(xE[i], yE[i]);
                Console.Write(nE[i]);
            }
        }

        public static void titleScreen()
        {
            Console.WriteLine("Would you like hard mode or easy mode? Q = easy A = hard");
            string input = Console.ReadLine();
            if (input == "Q")
            {
                difficulty = 0;
                Console.WriteLine("You picked the easy difficulty! When you are ready to start press any key!");
            }
            else if (input == "A")
            {
                difficulty = 1;
                Console.WriteLine("You picked the hard difficulty! When you are ready to start press any key!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You have picked an invalid input!");
                titleScreen();
                return;
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static void resetGame()
        {
            initEnemies();
            isPlayerColidingEnemy = false;
            counter = 0f;
            drawBorder();
            xP = 23;
            yP = 1;
            Console.SetCursorPosition(xP, yP);
            Console.Write("p");
        }

        #region checks
        public static void checkPlayerDeath()
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
        public static void uptadePlayer()
        {
            //Check if the user is pressing any key
            if (Console.KeyAvailable)
            {
                //Assign the key to a variable so we can work with it
                ConsoleKeyInfo pressed = Console.ReadKey(true);
                //check if the key is W
                if (pressed.Key == ConsoleKey.W)
                {
                    if (difficulty == 0)
                    {
                        moveUp();
                    }   
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
            titleScreen();
            drawBorder();
            Console.SetCursorPosition(xP, yP);
            Console.Write("p");
            initEnemies();
            while (true)
            {
                counter = counter + 0.09f;
                Console.SetCursorPosition("---------------------- it has been ".Length, 0);
                Console.Write(counter.ToString("#.##"));
                updateEnemy();
                //wait here for 0.09 seconds = 90ms
                System.Threading.Thread.Sleep(90);
                uptadePlayer();
                checkPlayerDeath();
                if (isPlayerColidingEnemy == true)
                {
                    Console.Clear();
                    Console.WriteLine("You fialed, try agian by pressing any key loser!");
                    Console.ReadKey();
                    Console.Clear();
                    resetGame();
                }
                else if (yP == 17)
                {
                    Console.Clear();
                    Console.WriteLine("Congradtulations, you won! Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    resetGame();
                }
            }
        }
    }
}
