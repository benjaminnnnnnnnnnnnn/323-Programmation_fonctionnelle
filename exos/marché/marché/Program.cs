using IronXL;
using System;
using System.Linq;

namespace marché
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkBook workBook = WorkBook.Load("C:\\Users\\px25twk\\Documents\\github\\323-Programmation_fonctionnelle\\exos\\marché\\Placedumarché.xlsx");
            WorkSheet workSheet = workBook.WorkSheets[0];

            int numPeches = 0;
            string standpastèque = "";
            int numpastèque = 0;
            string nom = "";

            List<marchand> marchands = new List<marchand>();


            foreach (var cell in workSheet["A2:A75"])
            {
                marchands.Add(new marchand(workSheet[$"B{cell.Address.FirstRow + 1}"].First().Text,
                                            cell.Text, 
                                            workSheet[$"C{cell.Address.FirstRow + 1}"].First().Text,
                                            Convert.ToInt32(workSheet[$"D{cell.Address.FirstRow + 1}"].First().Text)));
            }



            //LINQ 
            int Marchandpeche = (from cell in marchands
                            where cell.produit == "Pêches"
                            select 1).Count();

              var marchandpasteque = (from cell in marchands
                                          where cell.produit == "Pastèques" && cell.num == marchands.Max(x => x.num)
                                          select cell).First();
            

            foreach (var cell in workSheet["C2:C75"])
            {

                if (cell.Text == "Pêches")
                    numPeches++;



                if (cell.Text == "Pastèques" && numpastèque < Convert.ToInt32(workSheet[$"D{cell.Address.FirstRow + 1}"].First().Text))
                {
                    standpastèque = workSheet[$"A{cell.Address.FirstRow + 1}"].First().Text;
                    numpastèque = Convert.ToInt32(workSheet[$"D{cell.Address.FirstRow + 1}"].First().Text);
                    nom = workSheet[$"B{cell.Address.FirstRow + 1}"].First().Text;
                }
            }




            Console.WriteLine($"Il y {Marchandpeche} vendeurs de pêches");
            Console.WriteLine($"C'est {marchandpasteque.nom} qui a le plus de pastèques (stand {marchandpasteque.place}, {marchandpasteque.num} pièces)");



            Console.ReadKey(true);

        }

        public class marchand
        {


            public marchand(string nom, string place, string produit, int num)
            {
                this.nom = nom;
                this.place = place;
                this.produit = produit;
                this.num = num;
            }

            public string nom {  get; set; }
            public string place {  get; set; }
            public string produit { get; set; }
            public int num {  get; set; }
        }
    }
}
