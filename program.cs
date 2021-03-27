using System;

namespace algorithm
{
    #region structs
    public struct Point
    {
        public int x;
        public int y;
    }
    #endregion

    class MainClass
    {
        #region globals
        public static int borderWidth = 50;

        public static int borderHieght = 18;

        public static int gamesCounter = 1;

        public static int winCounter = 0;

        public static int looseCounter = 0;

        public static int difficulty = 0;
        //#RONEN I could not figure out a way to usefully use a struct in a direction, and name since each enemy only hold one value for the direction or name. But I have changed all vairbles, and made the player position work.
        public static string[] nE = new string[16];
        
        public static int[] dE = new int[16];

        public static Point[] pE = new Point[16];

        public static Point pP = new Point();


        public static bool isPlayerColidingEnemy = false;
        #endregion
        public static void initEnemies()
        {
            Random r = new Random();
            int randomNumber = r.Next(1, borderWidth);

            pE[0].x = randomNumber;
            pE[0].y = 2;
            nE[0] = "A";
            randomNumber = r.Next(1, borderWidth);
            pE[1].x = randomNumber;
            pE[1].y = 3;
            nE[1] = "B";
            randomNumber = r.Next(1, borderWidth);
            pE[2].x = randomNumber;
            pE[2].y = 4;
            nE[2] = "C";

            if (winCounter == 1)
            {
                randomNumber = r.Next(1, borderWidth);
                pE[3].x = randomNumber;
                pE[3].y = 6;
                nE[3] = "D";
            }
            if (winCounter > 1)
            {
                randomNumber = r.Next(1, borderWidth);
                pE[4].x = randomNumber;
                pE[4].y = 6;
                nE[4] = "E";
            }
            if (winCounter > 2)
            {
                randomNumber = r.Next(1, borderWidth);
                pE[5].x = randomNumber;
                pE[5].y = 6;
                nE[5] = "F";
            }
            if (winCounter > 3)
            {
                randomNumber = r.Next(1, borderWidth);
                pE[6].x = randomNumber;
                pE[6].y = 6;
                nE[6] = "G";
            }
            if (winCounter > 4)
            {
                randomNumber = r.Next(1, borderWidth);
                pE[7].x = randomNumber;
                pE[7].y = 6;
                nE[7] = "H";
            }
            if (winCounter > 5)
            {
                randomNumber = r.Next(1, borderWidth);
                pE[8].x = randomNumber;
                pE[8].y = 6; ;
                nE[8] = "I";
            }
            if (winCounter > 6)
            {
                randomNumber = r.Next(1, borderWidth);
                pE[9].x = randomNumber;
                pE[9].y = 6;
                nE[9] = "J";
            }
            if (winCounter > 7)
            {
                randomNumber = r.Next(1, borderWidth);
                pE[10].x = randomNumber;
                pE[10].y = 6;
                nE[10] = "K";
            }
            if (winCounter > 8)
            {
                randomNumber = r.Next(1, borderWidth);
                pE[11].x = randomNumber;
                pE[11].y = 6; ;
                nE[11] = "L";
            }
            if (winCounter > 9)
            {
                randomNumber = r.Next(1, borderWidth);
                pE[12].x = randomNumber;
                pE[12].y = 6;
                nE[12] = "N";
            }
            if (winCounter > 10)
            {
                randomNumber = r.Next(1, borderWidth);
                pE[13].x = randomNumber;
                pE[13].y = 6;
                nE[13] = "O";
            }
            if (winCounter > 11)
            {
                randomNumber = r.Next(1, borderWidth);
                pE[14].x = randomNumber;
                pE[14].y = 6;
                nE[14] = "Q";
            }
            if (winCounter > 12)
            {
                randomNumber = r.Next(1, borderWidth);
                pE[15].x = randomNumber;
                pE[15].y = 6;
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
                if (pE[i].x == borderWidth-1)
                {
                    dE[i] = 0;
                }
                else if (pE[i].x == 1)
                {
                    dE[i] = 1;
                }
                Console.SetCursorPosition(pE[i].x, pE[i].y);
                Console.Write(" ");
                if (dE[i] == 0)
                {
                    pE[i].x--;
                }
                else if (dE[i] == 1)
                {
                    pE[i].x++;
                }
                Console.SetCursorPosition(pE[i].x, pE[i].y);
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
            pP.x = borderWidth/2;
            pP.y = 1;
            Console.SetCursorPosition(pP.x, pP.y);
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
                if (pE[i].x == pP.x && pP.y == pE[i].y)
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
            if (pP.y == 1)
            {
                return;
            }
            Console.SetCursorPosition(pP.x, pP.y);
            Console.Write(" ");
            pP.y--;
            Console.SetCursorPosition(pP.x, pP.y);
            Console.Write("p");
        }
        public static void moveDown()
        {
            if (pP.y == borderHieght)
            {
                return;
            }
            Console.SetCursorPosition(pP.x, pP.y);
            Console.Write(" ");
            pP.y++;
            Console.SetCursorPosition(pP.x, pP.y);
            Console.Write("p");
        }
        public static void moveLeft()
        {
            if (pP.x == 1)
            {
                return;
            }
            Console.SetCursorPosition(pP.x, pP.y);
            Console.Write(" ");
            pP.x--;
            Console.SetCursorPosition(pP.x, pP.y);
            Console.Write("p");
        }
        public static void moveRight()
        {
            if (pP.x == borderWidth)
            {
                return;
            }
            Console.SetCursorPosition(pP.x, pP.y);
            Console.Write(" ");
            pP.x++;
            Console.SetCursorPosition(pP.x, pP.y);
            Console.Write("p");
        }
        #endregion

        public static void Main(string[] args)
        {
            titleScreen();
            drawBorder();
            Console.SetCursorPosition(pP.x, pP.y);
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
                else if (pP.y == 17)
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
