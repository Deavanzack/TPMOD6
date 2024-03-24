using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPmodul6
{
    internal class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            Contract.Requires(title.Length <= 100);
            Contract.Requires(title.Length > 0); 
            this.title = title;
            this.playCount = 0;
            Random random = new Random();
            this.id = random.Next(10000, 99999);
        }

        public void IncreasePlayCount(int angka)
        {
            Contract.Requires(angka <= 10000000);
            this.playCount = this.playCount + angka;

            try
            {
                checked
                {
                    this.playCount += angka;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error: jumlah penambahan play count tidak melebihi batas tertinggi integer");
                Console.WriteLine(ex.Message);
            }
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine(this.id);
            Console.WriteLine(this.title); 
            Console.WriteLine(this.playCount);  
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Menguji prekondisi
            Console.WriteLine("Menguji prekondisi:");
            try
            {
                SayaTubeVideo video1 = new SayaTubeVideo(""); // Melebihi batas minimum panjang judul
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            // Menguji exception dengan for loop untuk mempercepat proses overflow
            Console.WriteLine("\nMenguji exception (overflow):");
            SayaTubeVideo video2 = new SayaTubeVideo("Tutorial Design By Contract – Daffa Fadillah");
            for (int i = 0; i < 100; i++)
            {
                video2.IncreasePlayCount(1000000); // Menambah play count sebanyak 100 juta (overflow)
            }
            video2.PrintVideoDetails(); // Menampilkan detail video setelah exception (overflow)

            Console.ReadKey();
        }
    }
}
