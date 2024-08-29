using System;
using System.Threading;
using System.IO;

namespace Proyecto_Final
{
    public partial class Program
    {
        static void Menu1()//Menu Prinicpal
        {
            Console.Clear();
            Console.WriteLine("Bienvenido a la biblioteca");
            Console.WriteLine("\n\t\tMENÚ PRINCIPAL: Seleccione el tipo de usuario que es");
            Console.WriteLine("\n\t1.\tUsuario de la biblioteca");
            Console.WriteLine("\t2.\tBibliotecario o responsable");
            Console.WriteLine("\t3.\tSalir");
            Console.WriteLine("\t4.\tAcerca de");
            Console.Write("\n\n\tSeleccione su opción: ");
            Console.ForegroundColor = ConsoleColor.Red;
            int opc = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Black;
            Opcion1(opc);
        }
        static void Menu2()//Menu para el usuario común
        {
            Console.Clear();
            Console.WriteLine("\tBIENVENIDO A LA BIBLIOTECA, LECTOR\n\n\tSelccione una opción");
            Console.WriteLine("\t1.\tRegistrarse\n\t2.\tIniciar sesión\n\t3.\tVolver\n\t4.\tSalir");
            Console.Write("\n\n");
            Console.Write("\n\n\tSu opción es: ");
            int opc = int.Parse(Console.ReadLine());
            Opcion2(opc);
        }
        static void IngresoMenu()
        {
            Console.Write("\n\tIntroduzca su usuario de acceso: ");
            String UsAcceso = Console.ReadLine();
            Console.Write("\n\tIntroduzca el código de acceso: ");
            String access = Asterisk('*');
            if (access == "123456" && UsAcceso == "Bibliotecario 1")//la contraseña para ingresar es 123456
            {
                Menu3();
            }
            else
            {
                Console.Write("\n\n\tEl código de acceso o la contraseña son incorrectos!");
                Console.WriteLine("\n\tEsperoe 3 segundos para volver a intentarlo");
                Thread.Sleep(3000);
                Menu1();
            }
        }
        static void Menu3()//Menú para el bibliotecario
        {
            Console.Clear();
            Console.WriteLine("\tAcceso otorgado");
            Console.WriteLine("\n\tBienvenido Bibliotecario\n\tSeleccione una opción\n\n\t1.\tRegistrar un nuevo usuario");
            Console.WriteLine("\t2.\tRegistrar un nuevo libro\n\t3.\tVer usuarios registrados\n\t4.\tVer libros registrados\n\t5.\tVolver\n\t6.\tSalir");
            Console.Write("\n\n\tSu opción es: ");
            int opc = int.Parse(Console.ReadLine());
            Opcion3(opc);
        }
        static void Opcion1(int op)//switch general
        {
            switch (op)
            {
                case 1:
                    Menu2();
                    break;
                case 2:
                    IngresoMenu();
                    break;
                case 3:
                    Salir();
                    break;
                case 4:
                    About();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tEsa opción no está disponible. Por favor seleccione un número del 1 al 4");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Menu1();
                    break;
            }
        }
        static void Opcion2(int op)//switch usuario
        {
            switch (op)
            {
                case 1:
                    GetUser();
                    break;
                case 2:
                    Sesion();
                    break;
                case 3:
                    Menu1();
                    break;
                case 4:
                    Salir();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tEsa opción no está disponible. Por favor seleccione un número del 1 al 4");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Menu1();
                    break;
            }
        }
        static void Opcion3(int op)//switch bibliotecario
        {
            switch (op)
            {
                case 1:
                    GetUser();
                    break;
                case 2:
                    GetBook();
                    break;
                case 3:
                    DisplayUsers();
                    break;
                case 4:
                    DisplayBooks();
                    break;
                case 5:
                    Menu1();
                    break;
                case 6:
                    Salir();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tEsa opción no está disponible. Por favor seleccione un número del 1 al 6");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Menu1();
                    break;
            }
        }
    }
}