using System;
using System.Collections.Generic;
using System.Linq;

namespace Bakery_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> water = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            List<double> flou = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            Dictionary<string, int> output = new Dictionary<string, int>();


            output.Add("Croissant", 0);
            output.Add("Muffin", 0);
            output.Add("Baguette", 0);
            output.Add("Bagel", 0);

            Queue<double> queueWater = new Queue<double>(water);
            Stack<double> stackFlou = new Stack<double>(flou);




            while (queueWater.Count > 0 && stackFlou.Count > 0)
            {
                double formel = queueWater.Peek() + stackFlou.Peek();
                double sum = (queueWater.Peek() * 100) / formel;
                double final = 100 - sum;


                if (sum == 40 && final == 60)
                {
                    output["Muffin"] += 1;

                    queueWater.Dequeue();
                    stackFlou.Pop();
                    
                }
                else if (sum == 50 && final == 50)
                {
                    output["Croissant"] += 1;
                    queueWater.Dequeue();
                    stackFlou.Pop();
                    continue;
                }

                else if (sum == 20 && final == 80)
                {
                    output["Bagel"] += 1;
                    queueWater.Dequeue();
                    stackFlou.Pop();
                    continue;
                }
                else if (sum == 30 && final == 70)
                {
                    output["Baguette"] += 1;
                    queueWater.Dequeue();
                    stackFlou.Pop();
                    continue;
                }
                else
                {
                    if (sum <= 50 && final >= 50)
                    {
                       
                        double differ = queueWater.Dequeue() - stackFlou.Pop();
                        output["Croissant"] += 1;
                        stackFlou.Push(differ);
                        
                      
                       
                        

                    }


                   



                }







            }
            foreach (var item in output.OrderBy(x => x.Key).OrderByDescending(x => x.Value).Where(x => x.Value > 0))
            {
                
               
                    Console.WriteLine($"{item.Key}: {item.Value}");
                

            }

            if (queueWater.Count > 0)
            {
                Console.WriteLine($"Water left: {string.Join(", ", queueWater)}");
            }
            if (queueWater.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            if (stackFlou.Count > 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ", stackFlou)}");
            }
            if (stackFlou.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
        }

    }
} 

