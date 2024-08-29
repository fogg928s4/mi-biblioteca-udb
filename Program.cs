using System;
using System.Threading;
using System.IO;

namespace Proyecto_Final
{
    public partial class Program
    {
        public struct InfoSesion
        {
            public int nlinea;
            public bool chequeo;
        }
        public struct Usuario
        {
            public String name, lastname, address, email, phone, code, password;
            public StreamReader LeerUsuarios;
            public StreamWriter EscUsuarios;
        }
        public struct Prestamo
        {
            public String usercode, bookcode;
            public int copyn;
            public Double mora;
            public DateTime[] fechas;
            public StreamReader LeerPrestamos;
            public StreamWriter EscPrestamos;
        }
        public struct Book
        {
            public String code, title, author;
            public int NumCopia, location;
            public StreamReader LeerLibros;
            public StreamWriter EscLibros;
        }
        static void StartPage()
        {
            Console.WriteLine("\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t             ███████████████████████████████████████");
            Console.WriteLine("\t         ███████████████████████████████████████████████");
            Console.WriteLine("\t      ███████████████████████████████████████████████████████");
            Console.WriteLine("\t   ██████████████████████████████████████████████████████████████");
            Console.WriteLine("\t█████████████████████████████████████████████████████████████████████");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\n\t\t\t\tLA BIBLIOTECA UDB");
            Console.WriteLine("\t\t\t\t     v1.2");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n\t  ████████████████████████████████████████████████████████████████");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t█████████████████████████████████████████████████████████████████████");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\n\n\tCargando");
            for (int i = 0; i <= 3; i++)
            {
                Console.Write(" .");
                Thread.Sleep(1000);
            }
            Thread.Sleep(2000);//va solo a dormirse 500 milisegundos antes de que pase 
        }
        static void Main(string[] args)
        {
            Console.WindowHeight = 30;
            Console.WindowWidth = 100;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "UDB Biblioteca";
            StartPage();
            Menu1();
        }
        static void Salir()
        {
            Console.Beep(440, 225);
            Console.Beep(392, 225);
            Console.WriteLine("\n\n-->> FIN DEL PROGRAMA");
            Console.WriteLine("\n\n\t¡ADIÓS!");
            Console.ReadKey();
        }
        static void About()
        {
            Console.Clear();
            Console.WriteLine("\t\tACERCA DE: ");
            Console.WriteLine("\n\tDesarrollado por:");
            Console.WriteLine("\n\tRoberto Melgares\n\t\temail: rjmzelaya@gmail.com\n\t\tTeléfono: +503 7722-5528");
  
            Console.WriteLine("\n\n\n\n\tv. Alfa: 1.1");
            Console.WriteLine("\n\n\n\n\tCopyright ©  2022.\tTodos los derechos reservados");
            Console.ReadKey();
            Menu1();
        }
    }
}