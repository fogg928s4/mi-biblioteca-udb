using System;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace Proyecto_Final
{
    public partial class Program
    {
        static void GetUser()
        {            
            int contador = 0, continuar = 1;
            Usuario user = new Usuario();
            while (continuar == 1)
            {
                Console.Clear();
                Console.Write("\t¡BIENVENIDO AL REGISTRO DE USUARIOS!\n\n");
                Console.WriteLine("\tUsuarios registrados: {0}", contador);
                user.name = Name();
                user.lastname = LastName();
                user.email = Email();
                user.address = Address();
                user.phone = Phone();
                user.code = CodigoUser();
                user.password = Psswrd();
                user.EscUsuarios = new StreamWriter("usuarios.txt", true);
                user.EscUsuarios.WriteLine("\n" + user.name + " " + user.lastname);
                user.EscUsuarios.WriteLine("Correo: {0} Dirección: {1} Teléfono: {2}", user.email, user.address, user.phone);
                user.EscUsuarios.WriteLine(user.code);
                user.EscUsuarios.WriteLine("@Contra: " + user.password);
                Console.WriteLine("\n\n\t¡Escritura existosa!");
                Console.WriteLine("\n\t¿Desea registrar otro usuario?");
                Console.Write("\n\tDigite 1 para registrar otro usuario: ");
                continuar = int.Parse(Console.ReadLine());
                contador++;
            }
            user.EscUsuarios.Close();
            Console.WriteLine("\n\tPresione cualquier tecla para regresar al Menú principal");
            Console.ReadKey();
            Menu1();
        }
        static void GetBook()//aunque no hagan nada algunos parametros, es para llevarlos consigo para cuando se ocupen en otros metodos y como se comunican entre si
        {
            int i = 0, continuar = 1;
            Book Acceso = new Book();
            while (continuar == 1)
            {
                Console.Clear();
                Console.Write("\t¡BIENVENDIO AL REGISTRO DE LIBROS!\n\n");
                Console.WriteLine("\tLibros registrados: {0}", i);
                Acceso.title = Title();
                Acceso.author = Autor();
                Acceso.location = Ubicacion();
                Acceso.code = CodigoBook();
                Acceso.NumCopia = CopiaBook(Acceso.code);
                Acceso.EscLibros = new StreamWriter("libros.txt", true);
                Acceso.EscLibros.WriteLine("\nTitulo: {0} Autor: {1} Estanteria: {2}", Acceso.title, Acceso.author, Acceso.location);
                Acceso.EscLibros.WriteLine("Codigo: {0} Copia: {1}", Acceso.code, Acceso.NumCopia);
                Acceso.EscLibros.Close();
                Console.WriteLine("\n\n\t¡Escritura existosa!");
                Console.WriteLine("\n\t¿Desea registrar otro libro?");
                Console.Write("\n\tDigite 1 para registrar otro: ");
                continuar = int.Parse(Console.ReadLine());
                i++;
            }
            Console.WriteLine("\n");
            Console.Write("El total de ingresados fueron: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(i);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\tPresione cualquier tecla para regresar al Menú principal...");
            Console.ReadKey();
            Menu1();
        }
        static void GetBorrow()
        {
            int contador = 1, continuar = 1;
            Prestamo reg = new Prestamo();
            reg.fechas = new DateTime[3];
            while (contador == 1 && contador <= 3 && continuar == 1)
            {
                Console.Clear();
                Console.Write("\t¡BIENVENIDO AL REGISTRO DE PRÉSTAMOS!\n\n");
                Console.WriteLine("\tPrestamos registrados: {0}", contador);
                reg.usercode = UserCode();
                reg.bookcode = BookCode();
                reg.copyn = BookCopy();
                reg.fechas[0] = BorrowDate();
                reg.fechas[1] = ReturnDate();
                if (reg.fechas [0] < reg.fechas[1])
                {
                    reg.EscPrestamos = new StreamWriter("prestamos.txt", true);
                    reg.EscPrestamos.WriteLine("\nUsuario:{0}", reg.usercode);
                    reg.EscPrestamos.WriteLine("Libro: {0} Copia: {1}", reg.bookcode, reg.copyn);
                    reg.EscPrestamos.WriteLine("Fecha de prestamo: {0}", reg.fechas[0]);
                    reg.EscPrestamos.WriteLine("Fecha de entrega: {0}", reg.fechas[1]);
                    reg.EscPrestamos.Close();
                    Console.WriteLine("\n\n\t¡Escritura existosa!");
                    Console.WriteLine("\n\t¿Desea registrar otro prestamo?");
                    Console.Write("\n\tDigite 1 para registrar otro: ");
                    continuar = int.Parse(Console.ReadLine());
                    contador++;
                }
                else
                {
                    Console.WriteLine("\n\tLas fechas indicadas no son correctas\n\tPresione cualquier tecla para volver a registrar el préstamo");
                    Thread.Sleep(3000);
                    GetBorrow();
                }
            }
            Console.WriteLine("\n\tPresione cualquier tecla para regresar al Menú principal");
            Console.ReadKey();
            Menu1();
        }
        static void ReturnedBook()
        {
            Console.Clear();
            int continuar = 1, contador = 1;
            Prestamo reg = new Prestamo();
            reg.EscPrestamos.Close();
            reg.LeerPrestamos = new StreamReader("prestamos.txt", true);
            while (continuar == 1 && continuar <= 3)
            {
                Console.Clear();
                Console.WriteLine("Devoluciones: " + contador);
                Console.Write("\tIngrese los datos de su devolución\n\n");
                reg.usercode = "Usuario:" + UserCode();
                reg.bookcode = "Libro:" + BookCode();
                reg.copyn = BookCopy();
                reg.fechas[1] = ReturnDate();
                reg.fechas[2] = Entrega();
                String librodev = String.Join(" Codigo:", reg.bookcode, reg.copyn);
                if(CheckReturn(reg.usercode, librodev, reg.fechas) == true)
                {
                    Console.WriteLine("\n\tGracias por su devolución. Su mora  pagar es de $" + CalcMora(reg.fechas));
                    break;
                }
                else
                {
                    Console.WriteLine("\n\tEse préstamo no existe");
                    break;
                }
            }
            Console.WriteLine("\n\tPresione cualquier tecla para volver al Menu Princiapal...");
            Console.ReadKey();
            Menu1();
        }
        static bool CheckReturn(String user, String libro, DateTime[] fechas)
        {
            string[] lineas = File.ReadAllLines("prestamos.txt");
            for (int i = 0; i < lineas.Length; i++)
            {
                if(lineas[i] == user && lineas[i + 1] == libro && lineas[i+3] == Convert.ToString(fechas[1]))
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }
        static void DisplayUsers()
        {
            String Line;
            Usuario user = new Usuario();
            user.EscUsuarios = new StreamWriter("usuarios.txt", true);
            user.EscUsuarios.Close();
            user.LeerUsuarios = new StreamReader("usuarios.txt", true);
            int contador = 0;
            Console.WriteLine("\n\tUsuarios registrados: \n\n");
            while ((Line = user.LeerUsuarios.ReadLine()) != null)
            {
                if (Line.Contains("@Contra: ") == true)
                {
                    contador++;
                    Console.Write("\n");
                    continue;
                }
                else
                {
                    Console.WriteLine("\t" + Line);
                    contador++;
                    //evita que se muestre la contraseña del usuario
                }
            }
            user.LeerUsuarios.Close();
            Console.Write("\n\tDesea abrir el archivo que contiene los usuarios? Presione 1 para abrirlo: ");
            int opcion = int.Parse(Console.ReadLine());
            if (opcion == 1)
                Process.Start("usuarios.txt");
            Console.WriteLine("\n\tPresione cualquier tecla para volver al Menú Principal...\n");
            Console.ReadKey();
            Menu1();
        }
        static void DisplayBooks()
        {
            String Line;
            Book book = new Book();
            book.EscLibros = new StreamWriter("libros.txt", true);
            book.EscLibros.Close();
            book.LeerLibros = new StreamReader("libros.txt", true);
            int contador = 0;
            FileInfo arch = new FileInfo("libros.txt");
            if (arch.Length == 0)
            {
                Console.WriteLine("\nNo hay libros registrados aun\n\tPresione cualquier tecla para volver...");
                Console.ReadKey();
                Menu1();
            }
            else
            {
                Console.WriteLine("\n\tLibros registrados: \n\n");
                while ((Line = book.LeerLibros.ReadLine()) != null)
                {
                    contador++;
                    Console.WriteLine("\t" + Line);
                }
                book.LeerLibros.Close();
                Console.Write("\n\tDesea abrir el archivo que contiene los libro? Presione 1 para abrirlo: ");
                int opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                    Process.Start("libros.txt");
                Console.WriteLine("\n\tPresione cualquier tecla para volver al Menú Principal...\n");
                Console.ReadKey();
                Menu1();
            }
        }
        static void DisplayBorrow()
        {
            String Line;
            Prestamo prest = new Prestamo();
            prest.EscPrestamos = new StreamWriter("prestamos.txt", true);
            prest.EscPrestamos.Close();
            prest.LeerPrestamos = new StreamReader("prestamos.txt", true);
            int contador = 0;
            while ((Line = prest.LeerPrestamos.ReadLine()) != null)
            {
                Console.WriteLine(Line);
                contador++;
            }
            prest.LeerPrestamos.Close();
            Console.WriteLine("\n\tPresione cualquier tecla para volver al Menu Principal...");
            Console.ReadKey();
        }
    }
}