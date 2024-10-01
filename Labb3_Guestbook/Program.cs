/*******
 * Emmas gästbok version 1
 * Labb 3 i kursen DT071G Programmering med C# vid Mittuniversitetet
 * 
 * Kod skriven av Emma Lorensson, webbutvecklingsstudent
 *******/

namespace Labb3_Guestbook
{
    class Program
    {
        static void Main(string[] args)
        {
            //Skapa en ny instans av klassen Guestbook
            Guestbook guestbook = new Guestbook();
            int i = 0;

            // Oändlig loop som kör programmet till användaren väljer att avsluta
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("E M M A S  G Ä S T B O K\n\n");

                //Skriv ut alternativ
                Console.WriteLine("1. Skriv i gästbok");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("3. Avsluta\n");

                //Skriv ut alla inlägg i gästboken
                i = 0;
                foreach(Post post in guestbook.getPosts())
                {
                    Console.WriteLine("[" + i++ +"] " + post.Name + "\n" + post.Message + "\n");
                }

                //Invänta knapptryckning
                ConsoleKey input = Console.ReadKey(true).Key;
                //Kontrollera vilken knapp användaren trycker på och kör motsvarande funktion
                switch (input)
                {
                    case ConsoleKey.D1:
                        Console.CursorVisible = true;
                        Console.Write("\nAnge namn: "); 
                        string? name = Console.ReadLine();

                        Console.Write("Ange meddelande: ");
                        string? msg = Console.ReadLine();

                        if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(msg))
                        {
                            guestbook.addPost(name, msg);
                            Console.WriteLine("\nInlägg tillagt!");
                        }
                        else
                        {
                            Console.WriteLine("\nNamn och meddelandefälten får inte vara tomma.");
                        }
                        Console.WriteLine("Tryck på valfri tangent för att gå vidare. \n"); 
                        Console.ReadKey(); // Vänta på användarens tangenttryck
                        break;
                    case ConsoleKey.D2:
                        Console.CursorVisible = true;
                        Console.Write("Ange index att radera: ");
                        string? index = Console.ReadLine();
                        if (!String.IsNullOrEmpty(index))
                            try
                            {
                                guestbook.deletePost(Convert.ToInt32(index));
                            }
                            catch (Exception) 
                            {
                                Console.WriteLine("Index existerar inte! \nTryck på valfri knapp för att fortsätta");
                                Console.ReadKey();
                            }
                        Console.ReadKey(); // Vänta på användarens tangenttryck
                        break;
                    case ConsoleKey.D3:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}