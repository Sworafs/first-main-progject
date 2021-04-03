using System;

namespace algorithm
{
    #region structs
    public struct Point
    {
        public int x;
        public int y;
    }
    public struct Enemey
    {
        public string name;
        public int direction;
        public Point position;
    }
    public enum Directions
    {
        left = 0,
        right = 1
    }
    public struct GameData
    {
        public int borderWidth;

        public int borderHieght;

        public int gamesCounter;

        public int winCounter;

        public int looseCounter;

        public Difficulty difficulty;
    }
    public enum Difficulty
    {
        Easy,
        Hard
    }
    #endregion

    class MainClass
    {
        #region globals

        public static Enemey[] enemies = new Enemey[16];

        public static Point pP;

        public static GameData game;

        public static bool isPlayerColidingEnemy = false;
        #endregion
        public static void initAll()
        {
            Random r = new Random();
            for (int i = 0; i < enemies.Length; i++)
            {
                int randomNumber = r.Next(1, game.borderWidth);
                enemies[i].position.x = randomNumber;
                enemies[i].position.y = i + 2;
                enemies[i].direction = i % 2;
                if (i % 2 == 0)
                    enemies[i].name = "<";
                else
                    enemies[i].name = ">";
            }

            pP = new Point
            {
                x = game.borderWidth / 2,
                y = 1
            };
            
        }

        public static void drawBorder()
        {
            for(int lineNumber = 0; lineNumber < game.borderHieght; lineNumber++)
            {
                Console.SetCursorPosition(0, lineNumber);
                Console.Write("|");
                Console.SetCursorPosition(game.borderWidth, lineNumber) ;
                Console.Write("|");
            }
            for (int i = 0; i < game.borderWidth; i++)
            {
                Console.SetCursorPosition(i, game.borderHieght -1);
                Console.Write("-");
                Console.SetCursorPosition(i, 0);
                Console.Write("-");
            }
        }
        
        public static void updateEnemy()
        {
            //0 = left 1 = right
            for (int i = 0; i < (game.winCounter +3); i++)
            {
                if (enemies[i].position.x == game.borderWidth -1)
                {
                    enemies[i].direction = (int)Directions.left;
                    enemies[i].name = "<";
                }
                else if (enemies[i].position.x == 1)
                {
                    enemies[i].direction = (int)Directions.right;
                    enemies[i].name = ">";
                }
                Console.SetCursorPosition(enemies[i].position.x, enemies[i].position.y);
                Console.Write(" ");
                if (enemies[i].direction == (int)Directions.left)
                {
                    enemies[i].position.x--;
                }
                else if (enemies[i].direction == (int)Directions.right)
                {
                    enemies[i].position.x++;
                }
                Console.SetCursorPosition(enemies[i].position.x, enemies[i].position.y);
                Console.Write(enemies[i].name);
            }
        }

        public static void titleScreen()
        {
            Console.WriteLine("Would you like hard mode or easy mode? Q = easy A = hard");
            string input = Console.ReadLine();
            input = input.ToUpper();
            if (input == "Q")
            {
                game.difficulty = Difficulty.Easy;
                Console.WriteLine("You picked the easy difficulty! When you are ready to start press any key!");
            }
            else if (input == "A")
            {
                game.difficulty = Difficulty.Hard;
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
            initAll();
            isPlayerColidingEnemy = false;
            drawBorder();
            pP.x = game.borderWidth /2;
            pP.y = 1;
            Console.SetCursorPosition(pP.x, pP.y);
            Console.Write("p");
            Console.SetCursorPosition(0, game.borderHieght);
            Console.Write("Games: " + game.gamesCounter + ". Wins: " + game.winCounter + ". Losses: " + game.looseCounter + ".");
        }

        #region checks
        public static void checkPlayerDeath()
        {
            //Checking if player position = enemys position
            for (int i = 0; i < 16; i++)
            {
                if (enemies[i].position.x == pP.x && pP.y == enemies[i].position.y)
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
                    if (game.difficulty == Difficulty.Easy)
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
            if (pP.y == game.borderHieght)
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
            if (pP.x == game.borderWidth)
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
            game = new GameData
            {
                borderWidth = 50,
                borderHieght = 18,
                gamesCounter = 1,
                winCounter = 0,
                looseCounter = 0,
                difficulty = 0,
            };
            //Console.BackgroundColor = ConsoleColor.Blue;
            titleScreen();
            drawBorder();
            initAll();
            Console.SetCursorPosition(0, game.borderHieght);
            Console.Write("Games: " + game.gamesCounter + ". Wins: " + game.winCounter + ". Losses: " + game.looseCounter + ".");
            while (true)
            {
                updateEnemy();
                //wait here for 0.09 seconds = 90ms
                System.Threading.Thread.Sleep(80);
                uptadePlayer();
                checkPlayerDeath();
                if (isPlayerColidingEnemy == true)
                {
                    game.gamesCounter++;
                    game.looseCounter++;
                    Console.Clear();
                    Console.WriteLine("Number of games played: " + game.gamesCounter + ". Number of times won: " + game.winCounter + ". Number of times lost: " + game.looseCounter + ".");
                    Console.WriteLine("You fialed, try agian by pressing any key loser!");
                    Console.ReadKey();
                    Console.Clear();
                    resetGame();
                }
                else if (pP.y == 17)
                {
                    game.borderWidth--;
                    game.gamesCounter++;
                    game.winCounter++;
                    Console.Clear();
                    Console.WriteLine("Number of games played: " + game.gamesCounter + ". Number of times won: " + game.winCounter + ". Number of times lost: " + game.looseCounter + ".");
                    Console.WriteLine("Congradtulations, you won! Press any key to try agian");
                    Console.ReadKey();
                    Console.Clear();
                    resetGame();
                }
            }

        }
    }
}
