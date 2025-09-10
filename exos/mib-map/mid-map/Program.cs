using System.Text;
using static mid_map.Program;

namespace mid_map
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var i18n = new Dictionary<string, string>()
{
    { "Pommes","Apples"},
    { "Poires","Pears"},
    { "Pastèques","Watermelons"},
    { "Melons","Melons"},
    { "Noix","Nuts"},
    { "Raisin","Grapes"},
    { "Pruneaux","Plums"},
    { "Myrtilles","Blueberries"},
    { "Groseilles","Berries"},
    { "Tomates","Tomatoes"},
    { "Courges","Pumpkins"},
    { "Pêches","Peaches"},
    { "Haricots","Beans"}
};


            List<Product> products = new List<Product>
            {
                new Product { Location = 1, Producer = "Bornand", ProductName = "Pommes", Quantity = 20, Unit = "kg", PricePerUnit = 5.50 },
                new Product { Location = 1, Producer = "Bornand", ProductName = "Poires", Quantity = 16, Unit = "kg", PricePerUnit = 5.50 },
                new Product { Location = 1, Producer = "Bornand", ProductName = "Pastèques", Quantity = 14, Unit = "pièce", PricePerUnit = 5.50 },
                new Product { Location = 1, Producer = "Bornand", ProductName = "Melons", Quantity = 5, Unit = "kg", PricePerUnit = 5.50 },
                new Product { Location = 2, Producer = "Dumont", ProductName = "Noix", Quantity = 20, Unit = "sac", PricePerUnit = 5.50 },
                new Product { Location = 2, Producer = "Dumont", ProductName = "Raisin", Quantity = 6, Unit = "kg", PricePerUnit = 5.50 },
                new Product { Location = 2, Producer = "Dumont", ProductName = "Pruneaux", Quantity = 13, Unit = "kg", PricePerUnit = 5.50 },
                new Product { Location = 2, Producer = "Dumont", ProductName = "Myrtilles", Quantity = 12, Unit = "kg", PricePerUnit = 5.50 },
            };

            //to console string
            Console.WriteLine(string.Join('\n',

                products.Select(product =>
                    (
                        product.Producer.Substring(0, 3) + "..." + product.Producer[product.Producer.Length - 1],
                        i18n[product.ProductName],
                        product.Quantity * product.PricePerUnit

                    )).ToArray().ToList()

                ));


            //too csvvvvvvv
            var csv = new StringBuilder();
            csv.Append(string.Join('\n', products.Select(product =>

                        product.Producer.Substring(0, 3) + "..." + product.Producer[product.Producer.Length - 1].ToString() + "," +
                        i18n[product.ProductName] + "," +
                        (product.Quantity * product.PricePerUnit) + ","

                    )

                ));
            File.WriteAllText("C:\\Users\\px25twk\\Desktop\\test.csv", csv.ToString());


            Func<int, string> category = quantity => quantity < 10 ? "Stock faible" : quantity < 15 ? "Sock normal" : "Stock élevé";
            Func<int, double> multiplier = quantity => quantity < 10 ? 1.15 : quantity < 15 ? 1.05 : 1;

            //2
            Console.WriteLine(string.Join('\n',

                products.Select(product =>
                    (
                        product.Producer.Substring(0, 1) + product.Producer.Length + product.Producer[^1],
                        category(product.Quantity),
                        product.PricePerUnit * multiplier(product.Quantity),
                        (product.PricePerUnit * product.Quantity) > 100 ? "Premium" : "Standard"

                )).ToArray().ToList()

            ));

            //export json
            var json = new StringBuilder();
            json.Append("[\n" + string.Join("",

                products.Select(product =>
                    
                        "\t{\n\t\t\"producer\":\"" + (product.Producer.Substring(0, 1) + product.Producer.Length + product.Producer[^1]) + "\",\n" +
                        "\t\t\"category\":\"" + (category(product.Quantity)) + "\",\n" +
                        "\t\t\"price\":" + (product.PricePerUnit * multiplier(product.Quantity)) + ",\n" +
                        "\t\t\"rent\":\"" + ((product.PricePerUnit * product.Quantity) > 100 ? "Premium" : "Standard") + "\",\n\t}," +
                        "\n"

                )

            )+ "\n]");
            File.WriteAllText("C:\\Users\\px25twk\\Desktop\\test.json", json.ToString());



            Console.ReadKey();

        }
        public class Product
        {

            public int Location { get; set; }
            public string Producer { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public string Unit { get; set; }
            public double PricePerUnit { get; set; }
        }

    }
}
