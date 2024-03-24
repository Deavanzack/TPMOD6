using System;
using System.Diagnostics.Contracts;

namespace TPmodul6
{
    internal class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            if (title.Length > 100 || title.Length <= 0)
            {
                throw new ArgumentException("Panjang judul harus di antara 1 dan 100 karakter.");
            }

            this.title = title;
            this.playCount = 0;
            Random random = new Random();
            this.id = random.Next(10000, 99999);
        }

        public void IncreasePlayCount(int angka)
        {
            if (angka > 10000000)
            {
                throw new ArgumentException("Error: Masukan melebihi batas maksimum (10.000.000).");
            }

            this.playCount += angka;
            try
            {
                checked
                {
                    this.playCount += angka;
                }
            }
            catch (OverflowException ex)
            {
                
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
                SayaTubeVideo video1 = new SayaTubeVideo(""); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            // Menguji exception dengan for loop untuk mempercepat proses overflow
            Console.WriteLine("\nMenguji exception (overflow):");
            SayaTubeVideo video2 = new SayaTubeVideo("Tutorial Design By Contract - Daffa Fadillah");
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    video2.IncreasePlayCount(i+10000000); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("masukan melebihi batas ");
            }
            video2.PrintVideoDetails(); 
        }
    }
}
