
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using ConsolSERWER;

//DateTime dt = DateTime.Now; //  fragment wyrzyguje nam aktualną datę wraz z godziną.
//DateTime.Now.ToBinary();

/*foreach (var i in klienci)
{
    Console.Clear();
    Console.WriteLine(i); // Zwraca ilość zajętych gniazd - połączonych klientów
    Console.WriteLine(a + "       -----------------------");
    a++;
} */

namespace serwer
{
    class Serwer 
    {
        static List<Socket> klienci = new List<Socket>();
        static void Main(string[] args)
        {
            Console.WriteLine("Oto serwer czatu internetowego:  ");
            Console.WriteLine("     Aby pokazać połączonych klientów [1]");
            Console.WriteLine("     Aby zamknąć program              [2] ");
            //1.Utworzenie punktu nasluchiwania - IPEndPoint
            var serwer = new TcpListener(IPAddress.Any, 2000);
            serwer.Start();

            Thread oThread = new Thread(new ThreadStart(wyswtlpolcz));
            oThread.Start();


            while (true)
            {
                var polaczenieKlient = serwer.AcceptSocket();
                klienci.Add(polaczenieKlient);
                var watek = new Thread(obslugaKlienta);
                watek.Start(polaczenieKlient);

            }

            



        }
        static void wyswtlpolcz()  // nowy wątek do obsługi klawiszy
        {
           

            while (true)
            {


                switch (Console.ReadKey(true).KeyChar)
                {



                    case '1':
                        foreach (var klient in klienci)
                        {
                           //  Convert.ToString(klient.RemoteEndPoint); // sama konwersja do stringa adresu ip

                            Console.WriteLine(klient.RemoteEndPoint.ToString()); // wywala adres ip klienta

                        }
                        break;
                    case '2': //zamknij program
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                        break;
                    case '3': // Wyświetla klientów zalogowanych

                        
                        break;


                }
            }

          //  List<string> polaczeni = new List<string>();
          //  if (true)
         //   {
         //      // polaczeni.Add;
            //}


        }
        static void obslugaKlienta(object polaczenie)
        {
            string ncck;

            var polaczenieKlient = (Socket)polaczenie;
            polaczenieKlient.Send(Encoding.UTF8.GetBytes("------  Witaj na czacie  ------"));
            polaczenieKlient.Send(Encoding.UTF8.GetBytes(" Podaj nick, którym będziesz się identyfikował: "));

            zalogowani klient1 = new zalogowani(); // Tworzenie nowego obiektu.
            ncck = Console.ReadLine();
 
            klient1.DodajNick(ncck);

            polaczenieKlient.Send(Encoding.UTF8.GetBytes("Twoj nick to " + klient1.name));

            
            zalogowani asdasd = new zalogowani();
            asdasd.DodajNick("Blady koń");
            zalogowani qweee = new zalogowani();
            string zupa = Console.ReadLine();
            qweee.DodajNick(zupa);
            Console.WriteLine(qweee.nick);
            Console.WriteLine(asdasd.name + qweee.nick);






            // .GetStream().Read(dane, 0, dane.Length);
            // Console.WriteLine(Encoding.UTF8.GetString(dane));


            //var komunikat = Console.ReadLine();
            //var komunikatBinarnie = Encoding.UTF8.GetBytes(komunikat);
            //klientCzat.GetStream().Write(komunikatBinarnie, 0, komunikatBinarnie.Length);


            while (true)
                {
                var daneKlient = new byte[256]; // klient może wysłać maksymalnie 256 bitową wiadomosć

                try
                {
                    polaczenieKlient.Receive( daneKlient);
                }
                // #pragma warning disable 0168
                catch (SocketException e)
                //   #pragma warning disable 0168
                {
                    polaczenieKlient.Close();
                    break;

                }


                
                
                
                foreach (var klient in klienci)
                            {
                     
                   // polaczenieKlient.Send(daneKlient);
                   klient.Send( daneKlient);



                    

                             //na ocene wyzej, zeby nadawca nie dostawal swoich danych
                                                         // klient.Send(DateTime());
                                                         //klient.Send(Encoding.UTF8.GetBytes("awds"));
                            }

                
                // foreach (var i in klienci)
                // {
                // Console.Clear();
                //Console.WriteLine(i.polaczenieKlient); // Zwraca ilość zajętych gniazd - połączonych klientów
                //Console.WriteLine(a + "       -----------------------");
                //      a++;
                // }

            }
        }
       }
   }


/* GŁUPI TRY CATCH KTÓRY NIE DZIAŁA
 * 
 * try
                {
                                        polaczenieKlient.Receive(daneKlient);
                }
               // #pragma warning disable 0168
                catch (SocketException e)
             //   #pragma warning disable 0168
                {
                    polaczenieKlient.Close();   
                    break;
                    
                }

    */

