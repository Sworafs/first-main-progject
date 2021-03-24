using System;

namespace algorithm
{
    class MainClass
    {
        #region globals
        public static int borderWidth = 50;

        public static int borderHieght = 18;

        public static int gamesCounter = 1;

        public static int winCounter = 0;

        public static int looseCounter = 0;

        public static int difficulty = 0;

        public static string[] nE = new string[16];

        public static int[] dE = new int[16];

        public static int[] xE = new int[16];

        public static int[] yE = new int[16];

        public static int xP = borderWidth/2;
        public static int yP = 1;


        public static bool isPlayerColidingEnemy = false;
        #endregion
        public static void initEnemies()
        {
            Random r = new Random();
            int randomNumber = r.Next(1, borderWidth);

            xE[0] = randomNumber;
            yE[0] = 2;
            nE[0] = "A";
            randomNumber = r.Next(1, borderWidth);
            xE[1] = randomNumber;
            yE[1] = 3;
            nE[1] = "B";
            randomNumber = r.Next(1, borderWidth);
            xE[2] = randomNumber;
            yE[2] = 4;
            nE[2] = "C";

            if (winCounter == 1)
            {
                randomNumber = r.Next(1, borderWidth);
                xE[3] = randomNumber;
                yE[3] = 5;
                nE[3] = "D";
            }
            if (winCounter > 1)
            {
                randomNumber = r.Next(1, borderWidth);
                xE[4] = randomNumber;
                yE[4] = 6;
                nE[4] = "E";
            }
            if (winCounter > 2)
            {
                randomNumber = r.Next(1, borderWidth);
                xE[5] = randomNumber;
                yE[5] = 7;
                nE[5] = "F";
            }
            if (winCounter > 3)
            {
                randomNumber = r.Next(1, borderWidth);
                xE[6] = randomNumber;
                yE[6] = 8;
                nE[6] = "G";
            }
            if (winCounter > 4)
            {
                randomNumber = r.Next(1, borderWidth);
                xE[7] = randomNumber;
                yE[7] = 9;
                nE[7] = "H";
            }
            if (winCounter > 5)
            {
                randomNumber = r.Next(1, borderWidth);
                xE[8] = randomNumber;
                yE[8] = 10;
                nE[8] = "I";
            }
            if (winCounter > 6)
            {
                randomNumber = r.Next(1, borderWidth);
                xE[9] = randomNumber;
                yE[9] = 11;
                nE[9] = "J";
            }
            if (winCounter > 7)
            {
                randomNumber = r.Next(1, borderWidth);
                xE[10] = randomNumber;
                yE[10] = 12;
                nE[10] = "K";
            }
            if (winCounter > 8)
            {
                randomNumber = r.Next(1, borderWidth);
                xE[11] = randomNumber;
                yE[11] = 13;
                nE[11] = "L";
            }
            if (winCounter > 9)
            {
                randomNumber = r.Next(1, borderWidth);
                xE[12] = randomNumber;
                yE[12] = 14;
                nE[13] = "N";
            }
            if (winCounter > 10)
            {
                randomNumber = r.Next(1, borderWidth);
                xE[13] = randomNumber;
                yE[13] = 15;
                nE[14] = "O";
            }
            if (winCounter > 11)
            {
                randomNumber = r.Next(1, borderWidth);
                xE[14] = randomNumber;
                yE[14] = 16;
                nE[14] = "Q";
            }
            if (winCounter > 12)
            {
                randomNumber = r.Next(1, borderWidth);
                xE[15] = randomNumber;
                yE[15] = 16;
                nE[15] = "R";
            }
        }

        public static void drawBorder()
        {
            for(int lineNumber = 0; lineNumber < borderHieght; lineNumber++)
            {
                Console.SetCursorPosition(0, lineNumber);
                Console.Write("|");
                Console.SetCursorPosition(borderWidth, lineNumber) ;
                Console.Write("|");
            }
            for (int i = 0; i < borderWidth; i++)
            {
                Console.SetCursorPosition(i, borderHieght-1);
                Console.Write("-");
                Console.SetCursorPosition(i, 0);
                Console.Write("-");
            }
        }
        
        public static void updateEnemy()
        {
            //0 = left 1 = right
            for (int i = 0; i < (winCounter+3); i++)
            {
                if (xE[i] == borderWidth-1)
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
            drawBorder();
            xP = borderWidth/2;
            yP = 1;
            Console.SetCursorPosition(xP, yP);
            Console.Write("p");
            Console.SetCursorPosition(0, borderHieght);
            Console.Write("Games: " + gamesCounter + ". Wins: " + winCounter + ". Losses: " + looseCounter + ".");
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
            if (yP == borderHieght)
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
            if (xP == borderWidth)
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
            Console.SetCursorPosition(0, borderHieght);
            Console.Write("Games: " + gamesCounter + ". Wins: " + winCounter + ". Losses: " + looseCounter + ".");
            while (true)
            {
                updateEnemy();
                //wait here for 0.09 seconds = 90ms
                System.Threading.Thread.Sleep(80);
                uptadePlayer();
                checkPlayerDeath();
                if (isPlayerColidingEnemy == true)
                {
                    gamesCounter++;
                    looseCounter++;
                    Console.Clear();
                    Console.WriteLine("Number of games played: " + gamesCounter + ". Number of times won: " + winCounter + ". Number of times lost: " + looseCounter + ".");
                    Console.WriteLine("You fialed, try agian by pressing any key loser!");
                    Console.ReadKey();
                    Console.Clear();
                    resetGame();
                }
                else if (yP == 17)
                {
                    borderWidth--;
                    gamesCounter++;
                    winCounter++;
                    Console.Clear();
                    Console.WriteLine("Number of games played: " + gamesCounter + ". Number of times won: " + winCounter + ". Number of times lost: " + looseCounter + ".");
                    Console.WriteLine("Congradtulations, you won! Press any key to try agian");
                    Console.ReadKey();
                    Console.Clear();
                    resetGame();
                }
            }

        }
    }
}
