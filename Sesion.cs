using System;
using System.Threading;
using System.IO;

namespace Proyecto_Final
{
    public partial class Program
    {
        static void Sesion()//pantalla inicio de sesión
        {
            Console.Clear();
            Usuario user = new Usuario();
            InfoSesion sesion = new InfoSesion();
            user.LeerUsuarios = new StreamReader("usuarios.txt", true);
            FileInfo arch = new FileInfo("usuarios.txt");
            if (arch.Length == 0) {
                Console.WriteLine("\tAun no hay usuarios registrados");
                Console.WriteLine("\tPresione cualquier tecla para volver...");
                Console.ReadKey();
                Menu2();
            }
            else {
                Console.WriteLine("\tIniciar Sesion...");
                Console.Write("\n\tIngrese su usuario: ");
                string usuario = "Codigo: " + Console.ReadLine();
                Console.Write("\n\tIngrese su contraseña: ");
                string contra = "@Contra: " + Asterisk('*');
                sesion = VerificarSesion(usuario, contra);
                if (sesion.chequeo == true)
                {
                    user.LeerUsuarios.Close();
                    ProfileScreen(sesion.nlinea);
                }
                else
                {
                    Console.Write("\n\n\n\tLa contraseña o usuario ingresado son incorrectos\n\tPresione 1 para intentarlo de nuevo o 0 para salir: ");
                    int opc = int.Parse(Console.ReadLine());
                    if (opc == 1)
                    {
                        Console.WriteLine("\tPor favor espere...");
                        Thread.Sleep(2000);
                        Sesion();
                    }
                    else
                        Menu2();
                }
            }
        }
        static InfoSesion VerificarSesion(string usuario, string contra)
        {
            Usuario check = new Usuario();
            InfoSesion sesion = new InfoSesion();
            check.LeerUsuarios = new StreamReader("usuarios.txt");
            string[] lineas = File.ReadAllLines("usuarios.txt");
            for (int i = 0; i < lineas.Length; i++)//verifica cada linea del archivo/vector
            {
                if (lineas[i] == usuario && VerificarContra(contra, i + 1) == true)
                {
                    sesion.nlinea = i;//guarda la linea donde encontro el usuario i+1 donde esta la contra
                    sesion.chequeo = true;
                    break;
                }
                else
                {
                    sesion.chequeo = false;
                }
            }
            return sesion;
        }
        static bool VerificarContra(String contra, int nlinea)
        {
            string[] lineas = File.ReadAllLines("usuarios.txt");
            if (lineas[nlinea] == contra)
            {
                return true;
            }
            else
            {
                return false;
            }  
        }
        static void ProfileScreen(int nlinea)
        {
            Console.Clear();
            string[] lineas = File.ReadAllLines("usuarios.txt");
            string nombre = lineas[nlinea - 2];
            Console.WriteLine("\n\t¡Sesión iniciada con éxito!");
            Console.WriteLine("\n\tCargando...");
            Thread.Sleep(5000);
            Console.Clear();
            Console.WriteLine("\n\t¡Bienvenido a su perfil " + nombre);
            Console.WriteLine("\tElija que desea hacer: ");
            Console.WriteLine("\n\t1.\tVer mis datos\n\t2.\tRegistrar un préstamo\n\t3.\tVer préstamos pendientes\n\t4.\tDevolver libro\n\t5.\tSalir");
            Console.Write("\n\t\tSu opción: ");
            int opc = int.Parse(Console.ReadLine());
            OptProfile(opc, nlinea);
        }
        static void OptProfile(int option, int nlinea)
        {
            switch (option)
            {
                case 1:
                    PersonalInfo(nlinea);
                    break;
                case 2:
                    GetBorrow();
                    break;
                case 3:
                    DisplayBorrow();
                    break;
                case 4:
                    ReturnedBook();
                    break;
                case 5:
                    Menu1();
                    break;
            }
        }
        static void PersonalInfo(int nlinea)
        {
            String[] lineas = File.ReadAllLines("usuarios.txt");
            Console.WriteLine("\tSus datos son: ");
            Console.WriteLine("\n\t" + lineas[nlinea - 1] );
            Thread.Sleep(5000);
            ProfileScreen(nlinea);
        }
    }
}