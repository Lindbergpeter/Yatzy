namespace Forberedelse_til_tirsdag_27_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til spillet!");

            int numberOfPlayers;

            //spiller antal
            do
            {
                Console.Write("Skriv antal spillere (Minimum 2, maksimum 5): ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfPlayers) || numberOfPlayers < 2 || numberOfPlayers > 5);

            Console.WriteLine("Du har valgt " + numberOfPlayers + " spillere.");

            //Array til at gemme spillernavne
            string[] playerNames = new string[numberOfPlayers];

            //loop der beder hver spiller om deres navn, og gemmer i array
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Write($"Indtast navn for spiller {i + 1}: ");
                playerNames[i] = Console.ReadLine();
            }

            Console.WriteLine("\nSpillernavne:");  
            //Loop der udskriver navnene på spillerne
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine($"Spiller {i + 1}: {playerNames[i]}");
            }

            //loop der lader hver spiller udføre terningkast
             for (int playerIndex =  0; playerIndex < numberOfPlayers; playerIndex++)
            {
                Console.WriteLine($"\n{playerNames[playerIndex]}, tryk på en vilkårlig tast for at kaste terningerne! ");
                Console.ReadKey();
                int[] diceResults = RollDice(5);
                Console.WriteLine($"\nResultater af kast for {playerNames[playerIndex]}: ");
                foreach (var result in diceResults)
                {
                    Console.Write(result + " ");
                }
                // Loop til Ekstra kast
                for (int kast = 1; kast <= 2; kast++)
                {
                    Console.WriteLine($"\n{kast}. vil du kaste terninger igen? (Ja/Nej)");
                    string response = Console.ReadLine();
                    if (response.ToLower() == "ja")
                    {
                        Console.WriteLine("Hvilke terninger vil du kaste igen? skriv deres positioner adskildt af space: ");
                        string[] positions = Console.ReadLine().Split(' ');

                        //Loop der kaster valgte terninger
                        foreach (var pos in positions)
                        {
                            int position = int.Parse(pos);
                            diceResults[position - 1] = RollSingleDie();
                        }
                        Console.WriteLine($"Resultater af {kast}. kast for {playerNames[playerIndex]}: ");
                        foreach (var result in diceResults)
                        {
                            Console.Write(result + " ");
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        //terning
        static int[] RollDice(int numberOfDice)
            {
                Random r = new Random();
                int[] results = new int[numberOfDice];
                for (int i = 0; i < numberOfDice; i++)
                {
                    results[i] = RollSingleDie();
                }
                return results;
            }
            static int RollSingleDie()
            {
                Random r = new Random();
                return r.Next(1, 7);
            }
        }
    }
