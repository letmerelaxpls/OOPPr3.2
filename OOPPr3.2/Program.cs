using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;



public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}


class Program
{
    static void Main(string[] args)
    {
        string pathToJsonFiles = @"C:\Users\larsu\Desktop\uchus\IT\prohacker\OOPPr3.2\OOPPr3.2\bin\Debug";
        List<Product> products = new List<Product>();

        
        Predicate<Product> filterCriteria = p => p.Price < 10.0 && p.Stock >= 5;
        Action<Product> displayAction = p => Console.WriteLine($"Product {p.Name} - Price: {p.Price}, Stock: {p.Stock}");

        
        for (int i = 1; i <= 10; i++)
        {
            string fileName = Path.Combine(pathToJsonFiles, $"{i}.json");
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                var productsFromFile = JsonConvert.DeserializeObject<List<Product>>(json);
                products.AddRange(productsFromFile);
            }
        }
        Console.WriteLine("Result: ");

        foreach (var product in products)
        {
            if (filterCriteria(product))
            {
                displayAction(product);
            }
        }
    }
}


