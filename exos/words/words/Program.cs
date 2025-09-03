using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace words
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            string[] words = { "whatThe!!!", "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune", "My kingdom for a horse !", "Ooops I did it again" };
            string[] words3 = { "+++++", "<<<<<", ">>>>>", "bonjour", "hello", "@@@@", "vert", "rouge", "bleu", "jaune", "#####", "%%%%%%%" };
            string[] wordswin = { "i am the winner", "hello", "monde", "vert", "rouge", "bleu", "i am the looser" };

            //EXO2
            Func<string[], string[]> remove = wordss => wordss.Where(x => 
                                                x != words.First() &&
                                                x != words.Last() &&
                                                x != words.ElementAt(8)
                                                ).ToArray();

            //string[] wordsNo = remove.Invoke(words);


            var startsWithALetter = Regex.IsMatch("test", "^[a-zA-Z]");

            Func<string[], string[]> remove2 = wordss => wordss.Where(x =>
                                                                            Regex.IsMatch(x,"^[a-zA-Z]")
                                                                            ).ToArray();



            string[] wordsNo = remove2.Invoke(words3);



            string[] wordsX = wordsNo.Where(x => !x.Contains("x") &&
                                                x.Length >= 4 &&
                                                x.Length == wordsNo.Average(x => x.Length) &&
                                                words.First() != x &&
                                                words.Last() != x &&
                                                words.ElementAt(8) != x
                                                ).OrderByDescending(x => x).ToArray();



            string[] words4 = { "i am the winner", "hello", "monde", "vert", "rouge", "bleu", "i am the looser" };



            Action<string[]> Print = list => { foreach (string word in list) { Console.WriteLine(word); }  };

            Print(wordsNo);


            //  win/loose
            Func<string[],bool ,string> status = (wordss,win) => win ? wordss.First().ToString() : wordss.Last().ToString();
            Console.WriteLine("The winner is : " + status(wordswin, true));
            Console.WriteLine("The looser is : " + status(wordswin, false));



            Func<string, Dictionary<char, double>> Epsilon = letters =>
            {
                return letters
                .GroupBy(c => c)
                .ToDictionary(g => g.Key, g => Math.Round(((double)g.Count() / letters.Count()) * 100,2));
            };



            var directory = Epsilon("Fusce sed lacus nec augue finibus pretium sed fringilla augue. Sed vel tellus vitae ipsum maximus bibendum sit amet eu diam. Nam nibh augue, dictum in ex et, tempor imperdiet urna. Morbi et diam et ex tincidunt tincidunt et nec tellus. Praesent lobortis bibendum sem in consectetur. Nulla malesuada urna nec tincidunt pulvinar. Nunc imperdiet augue nisi, ac consectetur ex pharetra at. Morbi vitae tincidunt arcu, vel finibus leo. Duis porta nibh feugiat, posuere nibh facilisis, pulvinar erat. Sed vel nisl fermentum, blandit mi nec, egestas eros. Vivamus malesuada pellentesque ultricies. Donec eget dapibus neque. Donec aliquam quam ipsum, vel imperdiet leo auctor id. Sed ut nulla in nisl molestie imperdiet. Cras in lacus elit. Vivamus ac ante nec mi pulvinar ultricies. ");
            Console.WriteLine("Exo2 :");
            directory.ToList().ForEach(i => Console.WriteLine(i));






            List<string> frenchWords = new List<string>() {
    "Merci",
    "Hotdog",
    "Oui",
    "Non",
    "Désolé",
    "Réunion",
    "Manger",
    "Boire",
    "Téléphone",
    "Ordinateur",
    "Internet",
    "Email",
    "Sandwich",
    "Hello",
    "Taxi",
    "Hotel",
    "Gare",
    "Train",
    "Bus",
    "Métro",
    "Tramway",
    "Vélo",
    "Voiture",
    "Piéton",
    "Feu rouge",
    "Cédez",
    "Ralentir",
    "gauche",
    "droite",
    "Continuer",
    "Sandwich",
    "Retourner",
    "Arrêter",
    "Stationnement",
    "Parking",
    "Interdit",
    "Péage",
    "Trafic",
    "Route",
    "Rond-point",
    "Football",
    "Carrefour",
    "Feu",
    "Panneau",
    "Vitesse",
    "Tramway",
    "Aéroport",
    "Héliport",
    "Port",
    "Ferry",
    "Bateau",
    "Canot",
    "Kayak",
    "Paddle",
    "Surf",
    "Plage",
    "Mer",
    "Océan",
    "Rivière",
    "Lac",
    "Étang",
    "Marais",
    "Forêt",
    "Hello",
    "Montagne",
    "Vallée",
    "Plaine",
    "Désert",
    "Jungle",
    "Savane",
    "Volleyball",
    "Tundra",
    "Glacier",
    "Neige",
    "Pluie",
    "Soleil",
    "Nuage",
    "Vent",
    "Tempête",
    "Ouragan",
    "Tornade",
    "Séisme",
    "Tsunami",
    "Volcan",
    "Éruption",
    "Ciel"
};


            List<string> stringss = new List<string>();

            string line;
            using(StreamReader sr = new StreamReader("english.txt"))
            {
                line = sr.ReadLine();

                while (line != null)
                {
                    stringss.Add(line);
                    line = sr.ReadLine();

                }
            }


            string[] comun = frenchWords.Where(x => stringss.Any(s => s.ToLower() == x.ToLower())).ToArray();

            Console.WriteLine("Mots en commun :");
            comun.ToList().ForEach(i => Console.WriteLine(i));





            Console.ReadKey();



        }
    }
}
