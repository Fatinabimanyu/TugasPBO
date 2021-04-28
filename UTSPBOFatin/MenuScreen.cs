using System;
using System.Collections.Generic;


namespace PesenMinum
{
    class MenuScreen
    {
        public static void ShowMenu1()
        {
                Console.WriteLine(" Selamat Datang... ");
                Console.WriteLine("1. Tambah pesanan ");
                Console.WriteLine("2. Tampilkan seluruh pesanan Customer");
                Console.WriteLine("3. Tampilkan pesanan yang sedang disiapkan");
                Console.WriteLine("4. Kurangi pesanan yang sudah selesai");
                Console.WriteLine("5. Exit");
                Console.Write("Masukan pilihan");
        }

        public static void ShowMenu2()
        {
            Console.WriteLine(" --------------------------------List Menu PesenMinum-------------------------------- ");
            Console.WriteLine("|    Kecil   |   Sedang  |   Jumbo    |");
            Console.WriteLine("| 1. Teh     | 4. Teh    | 7. Teh     |");
            Console.WriteLine("| 2. Kopi    | 5. Kopi   | 8. Kopi   |");
            Console.WriteLine("| 3. Susu    | 6. Susu   | 9. Susu  |");
            Console.WriteLine("\n Masukkan pesanan dengan angka : ");
        }
        public string Excecute1()
        {
            string drinkName = "";
            ShowMenu2();
            var opt1 = Console.ReadLine();
    
            switch(opt1)
            {
                case "1":
                    Kecil cup1 = new Kecil();
                    cup1.AddDrink(new DrinkFlavor(Flavor.Teh));
                    Console.WriteLine(cup1.Info());
                    drinkName = "Teh";
                    break;
                case "2":
                    Kecil cup2 = new Kecil();
                    cup2.AddDrink(new DrinkFlavor(Flavor.Kopi));
                    Console.WriteLine(cup2.Info());
                    drinkName = "Kopi";
                    break;              
                case "3":
                    Kecil cup3 = new Kecil();
                    cup3.AddDrink(new DrinkFlavor(Flavor.Susu));
                    Console.WriteLine(cup3.Info());
                    drinkName = "Susu   ";
                    break;
                case "4":
                    Sedang cup4 = new Sedang();
                    cup4.AddDrink(new DrinkFlavor(Flavor.Teh));
                    Console.WriteLine(cup4.Info());
                    drinkName = "Teh";
                    break;
                case "5":
                    Sedang cup5 = new Sedang();
                    cup5.AddDrink(new DrinkFlavor(Flavor.Kopi));
                    Console.WriteLine(cup5.Info());
                    drinkName = "Kopi";
                    break;
                case "6":
                    Sedang cup6 = new Sedang();
                    cup6.AddDrink(new DrinkFlavor(Flavor.Susu));
                    Console.WriteLine(cup6.Info());
                    drinkName = "Susu   ";                    
                    break;

                case "7":
                    Jumbo cup7 = new Jumbo();
                    cup7.AddDrink(new DrinkFlavor(Flavor.Teh));
                    Console.WriteLine(cup7.Info());
                    drinkName = "Teh";
                    break;

                case "8":
                    Jumbo cup8 = new Jumbo();
                    cup8.AddDrink(new DrinkFlavor(Flavor.Kopi));
                    Console.WriteLine(cup8.Info());
                    drinkName = "Kopi";                    
                    break;
                case "9":
                    Jumbo cup9 = new Jumbo();
                    cup9.AddDrink(new DrinkFlavor(Flavor.Susu));
                    Console.WriteLine(cup9.Info());
                    drinkName = "Susu   ";                    
                    break;
                default:
                    Console.WriteLine("Salah angka");
                    drinkName = "0";
                    break;

            }
            return drinkName;
        }
        public void Excecute2()
        {
            var queueCustomer = new Queue<Customer>();
            
            while(true)
            {
                ShowMenu1();

                var opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        var custOrder = new Customer();
                        Console.Write("Masukan nama :");
                        custOrder.Name = Console.ReadLine();

                        custOrder.DrinkName = Excecute1();
                        if(custOrder.DrinkName == "0")
                        {
                            Console.WriteLine("Gagal memasukkan pesanan Customer.");
                        }
                        else
                        {
                            queueCustomer.Enqueue(custOrder);
                            Console.WriteLine("Pesanan Customer sudah ditambahkan.");
                        }

                        break;
                    case "2":
                        if (queueCustomer.Count > 0)
                        {
                            foreach (var q in queueCustomer)
                            Console.WriteLine($"{q.Name} memesan {q.DrinkName}. Nomor antrian {q.Id}");
                        }
                        else
                        {
                            Console.WriteLine("Tidak ada yang memesan.");
                        }
                        break;
                    case "3":
                        if (queueCustomer.Count > 0)
                        {
                            Console.WriteLine($"Pesanan {queueCustomer.Peek().Name} sedang dipersiapkan.");
                        }
                        else
                        {
                            Console.WriteLine("Tidak ada yang memesan.");
                        }
                        break;
                    case "4":
                        if (queueCustomer.Count > 0)
                        {
                            Console.WriteLine($"Pesanan {queueCustomer.Peek().Name} sudah selesai.");
                            queueCustomer.Dequeue();
                        }
                        else
                        {
                            Console.WriteLine("Tidak ada yang memesan.");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Exiting program now.");
                        System.Environment.Exit(1);

                        break;
                    default:
                        Console.WriteLine("Salah pilihan");
                        break;
                }          
                Console.ReadKey();    
                Console.Clear();
            }
        }

    }
}