using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Gem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerpoint = 0;

            bool isCoinTossDone = false;

            int playersum = 0;

            int dealerpoint = 0;

            float tieBreakerRand;

            string krona;

            string klave;

            int dealersum = 0;

            string answer = "empty";

            bool playerIsDone = false;

            bool dealerIsDone = false;

             Random rand = new Random();

            while (playerIsDone == false || dealerIsDone == false)
            {
                // player 
                if (playerIsDone == false)
                {
                    Console.WriteLine("Skriv 'slå' för att slå tärningen, eller 'stopp' för att stanna");

                    answer = Console.ReadLine();

                    if (answer == "slå")
                    {
                   
                        int randnum = rand.Next(1, 7);
                        playersum += randnum;
                        Console.WriteLine("du fick " + randnum + " Du har sammanlagt " + playersum);
                        if (playersum > 21)
                        {
                            Console.WriteLine("Du fick över 21 du förlorade");
                            playerIsDone = true;
                            dealerIsDone = true;
                            continue;
                        }
                    }
                    else if (answer == "stopp")
                    {
                        Console.WriteLine("Du stannar på " + playersum);
                        playerIsDone = true;
                    }
                    else
                    {
                        Console.WriteLine("Fel svar testa skriv slå för att slå tärningen");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Du står stilla på " + playersum);
                }
                // dealer
                if (dealerIsDone == false)
                {
                    if (dealersum < 17)
                    {
                        int dealerrand = rand.Next(1, 7);
                        dealersum += dealerrand;
                        Console.WriteLine("Jag fick " + dealerrand + " Jag har sammanlagt " + dealersum);

                        if (dealersum > 21)
                        {
                            Console.WriteLine("Jag fick över 21 jag förlorade");

                            dealerIsDone = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Jag stannar på " + dealersum);

                        dealerIsDone = true;
                    }
                }
            }
            // resultat
            if (playersum > 21)
            {
                Console.WriteLine("Du fick " + playersum + " Jag fick " + dealersum + " Jag vann");
            }
            
            else if (dealersum > playersum)
            {
                Console.WriteLine("Du fick " + playersum + " Jag fick " + dealersum + " Jag vann");
            }
            
            else if (dealersum > 21)
            {
                Console.WriteLine("Du fick " + playersum + " Jag fick " + dealersum + " Du vann");
            }
            
            else if (playersum > dealersum)
            {
                Console.WriteLine("Du fick " + playersum + " Jag fick " + dealersum + " Du vann");
            }
            
            else
            {
                while (isCoinTossDone == false)
                {
                    Console.WriteLine("oavgjort, välj krona eller klave för tiebreaker");
                    string coinChoice = Console.ReadLine();

                    if (coinChoice == "krona")
                    {
                        tieBreakerRand = tieBreakerRand = rand.NextSingle();

                        if (tieBreakerRand < 0.5)
                        {
                            Console.WriteLine("Det blev klave du förlorade");
                            break;
                        }
                        if (tieBreakerRand > 0.5)
                        {
                            Console.WriteLine("Det blev krona du vann");
                            break;
                        }
                    }
                    if (coinChoice == "klave")
                    {
                        tieBreakerRand = tieBreakerRand = rand.NextSingle();

                        if (tieBreakerRand < 0.5)
                        {
                            Console.WriteLine("Det blev krona du förlorade");
                            break;
                        }
                        if (tieBreakerRand > 0.5)
                        {
                            Console.WriteLine("Det blev klave du vann");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("fel svar försök svara med krona eller klave nästa gång");
                            continue;
                        }
                    }
                }
            }
        }
    }
}