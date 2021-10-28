using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;

namespace Homework16
{
    /*1.    Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.

Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), 
    «Название товара» (строка), «Цена товара» (вещественное число).
Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».

2.    Необходимо разработать программу для получения информации о товаре из json-файла.
Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.


*/
    class Program
    {
        static async Task Main(string[] args)
        {

            const int n = 5;


            Goods[] product = new Goods[n];
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
                
            };

            using (FileStream fs = new FileStream("Product.json", FileMode.Create))
             {
                 for (int i = 0; i < n; i++)
                 {
                     product[i] = new Goods();
                     Console.Write("Введите код товара: ");
                     
                    product[i].idProduct = Convert.ToInt32(Console.ReadLine());
                     Console.Write("Введите наименование товара: ");
                     product[i].nameProduct = Console.ReadLine();
                     Console.Write("Цена товара: ");
                     product[i].priceProduct = Convert.ToDouble(Console.ReadLine());
                 }
                 JsonSerializer.Serialize(fs, product, options);
             }

           string jsonString = File.ReadAllText("Product.json");
           Goods[] Getproduct = JsonSerializer.Deserialize<Goods[]>(jsonString);
            double price = 0;
            for (int i = 0; i < n-1; i++)
            {

                if (Getproduct[i].priceProduct > Getproduct[i + 1].priceProduct)
                {
                    price = Getproduct[i].priceProduct;
                }
                else
                {
                    price = Getproduct[i + 1].priceProduct;
                }
            }
            for (int i = 0; i < n - 1; i++)
            {

                if (price == Getproduct[i].priceProduct)
                {
                    Console.WriteLine($"Самый дорогой товар: {Getproduct[i].nameProduct}. Цена товара: {price}");
                    Console.ReadKey();
                    return;
                }
                
            }
            
            Console.WriteLine(price);
                Console.ReadKey();
        }
        class Goods
        {
            public int idProduct { get; set; }
            public string nameProduct { get; set; }
            public double priceProduct { get; set; }
        }
    }
}


