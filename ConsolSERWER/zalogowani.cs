using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;


namespace ConsolSERWER
{
    public class zalogowani 
    {
        
        public string nick { get; set; }
        public string adresIP { get; set; }

        public string name;
        // Constructor that takes no arguments.
        public zalogowani() // już wiem że mam problem, nie ma jakiejś biblioteki
        {
            name = "unknown";
        }

        public zalogowani(string nm)
        {
            name = nm;
        }


        // Metoda
        public void DodajNick(string newName)
        {
            name = newName;
        }

        /* public void zapis()
        {

           
            nick = Console.ReadLine();

            //  zap = ToString(Console.ReadLine())
            //  Console.ReadLine(zap);

        } */
        

        public void wypisz() // to nie zadziała
        {
            Console.WriteLine(nick + " " + adresIP); // !!!!!!!!!!!!!!!!!!!!!1
        }

        public void Ignition()
        {
            Console.WriteLine("Uruchomiono silnik!");
        }
    

    //  Console.WriteLine(TcpClient);
}
}

/*
  public class Person
    {
        // Field
        public string name;

        // Constructor that takes no arguments.
        public Person()
        {
            name = "unknown";
        }

        // Constructor that takes one argument.
        public Person(string nm)
        {
            name = nm;
        }

        // Method
        public void SetName(string newName)
        {
            name = newName;
        }
    }
    class TestPerson
    {
        static void Main()
        {
            // Call the constructor that has no parameters.
            Person person1 = new Person();
            Console.WriteLine(person1.name);

            person1.SetName("John Smith");
            Console.WriteLine(person1.name);

            // Call the constructor that has one parameter.
            Person person2 = new Person("Sarah Jones");
            Console.WriteLine(person2.name);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    // Output:
    // unknown
    // John Smith
    // Sarah Jones
    */