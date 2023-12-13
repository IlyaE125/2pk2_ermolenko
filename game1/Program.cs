using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1
{
    internal class Program
    {
        static int mapSize = 25; //размер карты
        static char[,] map; //карта
                            //координаты на карте игрока
        static int playerY = mapSize / 2;
        static int playerX = mapSize / 2;
        static byte enemies = 10; //количество врагов
        static byte countEnemies = 10;
        static byte buffs = 5; //количество усилений
        static int health = 5; // количество аптечек

        public static int healthPlayer = 50; //количество здоровья игрока
        static int healthEnemies = 30; //количество здоровья врага
        static int damagePlayer = 10; //дмг игрока
        static int damageEnemies = 5; //дмг врага

        static int maxHealth = 50;

        static int countStep = 0;
        static int countBuffStep = 0;



        static void Main(string[] args)
        {
            Prewie();
            Move();
        }

        // начальный экран
        static void Prewie()
        {

            Console.Clear();
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("N - начать новую игру");
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("L - загрузить последнее сохранение");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.L: //запуск последнего сохранения
                    break;
                case ConsoleKey.N: //запуск новой игры

                    countStep = 0;
                    healthPlayer = 50;
                    damagePlayer = 10;
                    enemies = 10; //количество врагов
                    countEnemies = 10;
                    buffs = 5; //количество усилений
                    health = 5; // количество аптечек
                    GenerationMap();
                    break;
                default: //если игрок нажимает на другие клавиши то стартовый экран не пропадает
                    Prewie();
                    break;
            }


        }


        static void GenerationMap()
        {
            Random random = new Random();
            map = new char[mapSize, mapSize];
            //создание пустой карты
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = '_';
                }
            }


            map[playerY, playerX] = 'P'; // в cередину карты ставится игрок



            //добавление врагов
            AddEnemies();
            //добавление баффов
            AddBuffs();
            //добавление аптечек
            AddHealth();

            UpdateMap(); //отображение заполненной карты на консоли

        }

        static void AddEnemies()
        {
            Random random = new Random();
            while (enemies > 0)
            {
                int x = random.Next(1, mapSize);
                int y = random.Next(1, mapSize);

                //если ячейка пуста - туда добавляется враг
                if (map[x, y] == '_')
                {
                    map[x, y] = 'E';
                    enemies--; //при добавлении врагов уменьшается количество нерасставленных врагов

                }
            }
        }

        static void AddBuffs()
        {
            Random random = new Random();
            while (buffs > 0)
            {
                int x = random.Next(1, mapSize);
                int y = random.Next(1, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'B';
                    buffs--;
                }
            }
        }

        static void AddHealth()
        {
            Random random = new Random();
            while (health > 0)
            {
                int x = random.Next(1, mapSize);
                int y = random.Next(1, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'H';
                    health--;
                }
            }
        }

        static void UpdateMap()
        {
            Console.Clear();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    switch (map[i, j])
                    {
                        case 'H':
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'E':
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'B':
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'P':
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;

                        default:
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;

                    }
                }
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(map[i, 0]);
                Console.ResetColor();
            }
        }

        static void Move()
        {
            while (true)
            {

                //предыдущие координаты игрока
                int playerOldY;
                int playerOldX;

                while (true)
                {
                    CheckBuffsStep();

                    Text();

                    playerOldX = playerX;
                    playerOldY = playerY;



                    //смена координат в зависимости от нажатия клавиш
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.UpArrow:
                            playerX--;
                            countStep++;
                            Text();
                            break;
                        case ConsoleKey.DownArrow:
                            playerX++;
                            countStep++;
                            Text();
                            break;
                        case ConsoleKey.LeftArrow:
                            playerY--;
                            countStep++;
                            Text();
                            break;
                        case ConsoleKey.RightArrow:
                            Text();
                            playerY++;
                            countStep++;
                            break;
                        case ConsoleKey.Q:
                            Prewie();
                            break;
                    }

                    if (playerY == mapSize)
                    {
                        playerY = mapSize - 1;
                        countStep--;
                    }
                    else if (playerX == mapSize)
                    {
                        playerX = mapSize - 1;
                        countStep--;
                    }
                    else if (playerX == -1)
                    {
                        playerX = 0;
                        countStep--;
                    }
                    else if (playerY == -1)
                    {
                        playerY = 0;
                        countStep--;
                    }


                    switch (map[playerX, playerY])
                    {
                        case 'B':
                            CheckBuff();
                            break;
                        case 'H':

                            CheckHealth();
                            break;
                        case 'E':
                            CheckEnemies();
                            break;
                    }





                    Console.CursorVisible = false; //скрытный курсов

                    //предыдущее положение игрока затирается
                    map[playerOldY, playerOldX] = '_';

                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(playerOldY, playerOldX);
                    Console.Write('_');
                    Console.ResetColor();


                    //обновленное положение игрока
                    map[playerY, playerX] = 'P';
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(playerY, playerX);
                    Console.Write('P');
                    Console.ResetColor();



                    Text();


                }
            }

        }

        static void Teleport()
        {
            if (playerY == mapSize - 1)
            {
                playerY = 0;
                countStep--;
            }
            else if (playerX == mapSize - 1)
            {
                playerX = 0;
                countStep--;
            }
        }

        static void CheckHealth()
        {

            healthPlayer = maxHealth;
            map[playerX, playerY] = '_';
            Text();

        }

        static void CheckBuff()
        {
            if (map[playerX, playerY] == 'B')
            {
                countBuffStep = 21;
                damagePlayer = 20;
            }

        }

        //Время действия баффа
        static void CheckBuffsStep()
        {
            if (damagePlayer >= 20) //если урон игрока уже увеличен
            {
                countBuffStep -= 1;

                if (countBuffStep <= 0) //если время действия баффа закончилось
                {
                    damagePlayer = 10; //дефолтное значение дамага игрока

                }

            }

        }

        static void CheckEnemies()
        {
            if (map[playerX, playerY] == 'E')
            {
                while (healthPlayer > 0 && healthEnemies > 0)
                {
                    healthEnemies -= damagePlayer;
                    if (healthEnemies <= 0)
                    {
                        countEnemies--;

                        if (countEnemies == 0)
                        {
                            WinText();
                        }
                        break;
                    }
                    healthPlayer -= damageEnemies;
                    if (healthPlayer <= 0)
                    {
                        Console.Clear();
                        countEnemies = 10;
                        EndText();
                    }

                }
                healthEnemies = 30;
                map[playerX, playerY] = '_';
            }

        }


        static void Text()
        {
            Console.SetCursorPosition(0, mapSize);
            Console.WriteLine($"Жизни игрока: {healthPlayer}" + " ");
            Console.WriteLine($"Количество шагов: {countStep}");
            Console.WriteLine($"Урон игрока: {damagePlayer}");
            Console.WriteLine($"Количество врагов: {countEnemies}" + " ");
        }

        static void WinText()
        {
            Console.Clear();
            Console.SetCursorPosition(40, 15);
            Console.Write("ПОБЕДА!");
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("N - начать новую игру");
            Console.SetCursorPosition(40, 17);
            Console.WriteLine("L - загрузить последнее сохранение");
            switch (Console.ReadKey().Key)
            {

                case ConsoleKey.N: //запуск новой игры
                    playerY = mapSize / 2;
                    playerX = mapSize / 2;
                    countStep = 0;
                    healthPlayer = 50;
                    damagePlayer = 10;
                    enemies = 10; //количество врагов
                    countEnemies = 11;
                    buffs = 5; //количество усилений
                    health = 5; // количество аптечек
                    GenerationMap();
                    break;
                default:
                    WinText();
                    break;
            }






        }

        static void EndText()
        {
            Console.Clear();
            Console.SetCursorPosition(40, 15);
            Console.Write("ПОРАЖЕНИЕ");
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("N - начать новую игру");
            Console.SetCursorPosition(40, 17);
            Console.WriteLine("L - загрузить последнее сохранение");
            switch (Console.ReadKey().Key)
            {

                case ConsoleKey.N: //запуск новой игры
                    playerY = mapSize / 2;
                    playerX = mapSize / 2;
                    countStep = 0;
                    healthPlayer = 50;
                    damagePlayer = 10;
                    enemies = 10; //количество врагов
                    countEnemies = 11;
                    buffs = 5; //количество усилений
                    health = 5; // количество аптечек
                    GenerationMap();
                    break;
                default:
                    WinText();
                    break;
            }
        }

    }




}