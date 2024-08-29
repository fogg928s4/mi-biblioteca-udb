using System;
using System.IO;
using System.Threading;

namespace Proyecto_Final
{
    public partial class Program
    {
        #region Items Usuario
        static String Name()
        {
            Console.Write("\n\tNombre(s): ");
            String nomb = Console.ReadLine();
            return nomb;
        }
        static String LastName()
        {
            Console.Write("\n\tApellido(s): ");
            String last = Console.ReadLine();
            return last;
        }
        static String Address()
        {
            Console.Write("\n\tDirección (municipio): ");
            String direccion = Console.ReadLine();
            return direccion;
        }
        static String Email()
        {
            Console.Write("\n\tDirección de e-mail: ");
            String correo = Console.ReadLine();
            if (correo.Contains("@") == false || correo.Contains(".") == false || correo.Length < 5 || correo.EndsWith(".") == true || correo.Contains(" ") == true || correo.EndsWith("@") == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\tLa direccion de email ingresada es invalida");
                Console.ForegroundColor = ConsoleColor.Black;
                Email();
            }
            return correo;
        }
        static String Phone()
        {
            Console.Write("\n\tNumero de teléfono (incluya el código de país): ");
            String telefono = Console.ReadLine();
            if (telefono.Length < 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tNúmero de teléfono inválido!");
                Console.ForegroundColor = ConsoleColor.Black;
                Phone();
            }
            return telefono;
        }
        static String CodigoUser()
        {
            Console.Write("\n\tCódigo de usuario (Debe de tener 8 caracteres): ");
            String codigo = ("Codigo: " + Console.ReadLine());
            if (codigo.Length != 16)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\tEl codigo ingresado no es valido");
                Console.ForegroundColor = ConsoleColor.Black;
                CodigoUser();
            }
            else
            {
                string[] lineas = File.ReadAllLines("usuarios.txt");
                for(int i = 0; i < lineas.Length; i++)
                {
                    if (lineas[i] == codigo)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\tEl codigo ingresado ya esta en uso");
                        Console.ForegroundColor = ConsoleColor.Black;
                        CodigoUser();
                    }
                    else
                        continue;
                }
            }
            return codigo;
        }
        static String Psswrd()
        {
            Console.Write("\n\tConstraseña: ");
            string contrasena = Asterisk('*');
            return contrasena;
        }
        static String Asterisk(char asterisco)//en el arg va un *, entronces el lo que muestra será *
        {
            int num = 0;
            string contra = "";//contra de contraseña, vacio para que le meta los datos
            while (true)//se va repetir
            {
                ConsoleKeyInfo info = Console.ReadKey(true);//lee lo que se pone
                if (info.Key == ConsoleKey.Enter)
                {
                    return contra;//al presionar enter devuelve ya lo mandado
                }
                if (info.Key == ConsoleKey.Backspace)
                {
                    if (num > 0)
                    {
                        contra = contra.Substring(0, contra.Length - 1);
                        Console.Write("\b \b");
                        num--;
                    }
                }
                else if ((info.KeyChar > ' ') && (info.KeyChar < '\x007f'))
                {
                    Console.Write(asterisco);
                    contra = contra + info.KeyChar.ToString();//convierte el char a string
                    num++;
                }
            }
        }
        #endregion
        #region Items libros
        static String Title()
        {
            Console.Write("\n\tTitulo del libro: ");
            String nomb = Console.ReadLine();
            return nomb;
        }
        static String Autor()
        {
            Console.Write("\n\tNombre del autor: ");
            String nomb = Console.ReadLine();
            return nomb;
        }
        static int Ubicacion()
        {
            Console.Write("\n\tNumero de estanteria donde se ubica el libro: ");
            int nomb = int.Parse(Console.ReadLine());
            return nomb;
        }
        static String CodigoBook()
        {
            Console.Write("\n\tCódigo de libro (Debe de tener 8 caracteres): ");
            String codigo = ("Codigo: " + Console.ReadLine());
            if (codigo.Length != 16)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\tEl codigo ingresado no es valido");
                Console.ForegroundColor = ConsoleColor.Black;
                CodigoUser();
            }
            else
            {
                string[] lineas = File.ReadAllLines("libros.txt");
                for (int i = 0; i < lineas.Length; i++)
                {
                    if (lineas[i] == codigo)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\tEl codigo ingresado ya esta en uso");
                        Console.ForegroundColor = ConsoleColor.Black;
                        CodigoBook();
                    }
                    else
                        continue;
                }
            }
            return codigo;
        }
        static int CopiaBook(String codigo)
        {
            Book libro = new Book();//un timbre
            //libro.EscLibros.Close();//cierra lo que se escribe para poder leer
            libro.LeerLibros = new StreamReader("libros.txt", true);
            Console.Write("\n\tNumero de copia (1-3): ");
            int ncopia = int.Parse((Console.ReadLine()));
            if (ncopia < 1 || ncopia > 3)//verifica numero de copia
            {
                Console.WriteLine("\tEl numero de copia ingresado no es valido\n\tPor favor ingrese un numero entre 1 y 3");
                CopiaBook(codigo);
                return ncopia;
            }
            else
            {
                String check = ("Codigo: {0}" + codigo + "Copia: " + ncopia), Linea;
                while((Linea = libro.LeerLibros.ReadLine())!= null)//verifica que el numero de copia de el libro no este en uso
                {
                    if (Linea == check)
                    {
                        Console.WriteLine("\tEl numero de copia de ese libro ya esta registrada");
                        CopiaBook(codigo);
                    }
                    else
                    {
                        continue;
                    }
                }
                libro.LeerLibros.Close();
                return ncopia;
            }
        }
        #endregion
        #region Items Prestamos
        static String UserCode()
        {
            Console.Write("\n\tIngrese su codigo de usuario: ");
            String codigo = ("Codigo: " + Console.ReadLine());
            if (codigo.Length != 16)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\tEl codigo ingresado no es valido");
                Console.ForegroundColor = ConsoleColor.Black;
                CodigoUser();
            }
            else
            {
                string[] lineas = File.ReadAllLines("usuarios.txt");
                for (int i = 0; i < lineas.Length; i++)
                {
                    if (lineas[i] == codigo)
                    {
                        return codigo;
                    }
                    else
                        continue;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\tEl codigo ingresado no existe");
            Console.ForegroundColor = ConsoleColor.Black;
            UserCode();
            return codigo;
        }
        static String BookCode()
        {
            Console.Write("\n\tEscriba el código del libro: ");
            String bcode = Console.ReadLine();
            return bcode;
        }
        static int BookCopy()
        {
            Console.Write("\n\tEscriba el número de copia del libro: ");
            int numb = int.Parse(Console.ReadLine());
            if (numb > 3 || numb <= 0)
            {
                Console.WriteLine("\tNúmero de copia inválido");
                Thread.Sleep(2000);
                BookCopy();
                return numb;
            }
            else
            {
                return numb;
            }
        }
        static DateTime BorrowDate()
        {
            Console.Write("\n\tEscriba la fecha del préstamo (DD/MM/AAAA): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            //DateTime date = DateTime.Now;
            return date;
        }
        static DateTime ReturnDate()
        {
            Console.Write("\n\tEscriba la fecha que se devolverá (DD/MM/AAAA): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine()); //esta es la variable capturada año,dia mes
            return date;
        }
        static DateTime Entrega()
        {
            Console.Write("\n\tEscriba la fecha de entrega (DD/MM/AAAA): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            return date;
        }
        static Double CalcMora(DateTime[] fechas)
        {
            Double mora = ((fechas[2] - fechas[1]).TotalDays) * 0.35;//1 es la de devolucion marcada y 2 es la entrega
            return mora;
        }
        #endregion
    }
}