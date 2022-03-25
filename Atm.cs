using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public static class Atm
    {
        public static Dictionary<int, User> users { get; private set; }

        public static void Initialize()
        {
            LoadUsers();
            Login();
        }

        static void Login()
        {
            Console.Clear();
            Console.WriteLine("**** BIENVENIDO ****");
            Console.WriteLine("Ingrese su numero de identificacion: ");
            int searchIdentification = int.Parse(Console.ReadLine());
            if (users.ContainsKey(searchIdentification))
            {
                User user = users[searchIdentification];
                Console.WriteLine("Ingrese su contraseña: ");
                ushort guessPassword = ushort.Parse(Console.ReadLine());
                if (guessPassword == user.Password)
                {
                    Console.Clear();
                    Console.WriteLine($"**** BIENVENIDO {user.Name.ToUpper()} ****");
                    Console.WriteLine("**** CUENTAS ****");
                    Console.WriteLine("Seleccione la cuenta por su indice");
                    user.ShowAccounts();
                    Console.Write("Opcion: ");
                    int accountIndex = int.Parse(Console.ReadLine());
                    if (user.Accounts.ContainsKey(accountIndex))
                    {
                        Account account = user.Accounts[accountIndex];
                        ShowMenu(account, user);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Cuenta no encontrada");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Contraseña incorrecta");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Usuario no encontrado");
            }

            
        }

        public static void ShowMenu(Account account,User user)
        {
            byte option = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("**** MENU ****");
                Console.WriteLine();
                Console.WriteLine("Seleccione una opcion");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. Consulta de Saldo");
                Console.WriteLine("2. Retiro");
                Console.WriteLine("3. Deposito");
                Console.WriteLine("4. Cambio de contraseña");
                Console.WriteLine();
                Console.WriteLine("5. Salir");
                Console.Write("Opcion: ");
                option = byte.Parse(Console.ReadLine());
                Console.WriteLine();
                switch(option)
                {
                    case 1:
                        ShowBalance(account);
                        break;
                    case 2:
                        TryWithdraw(account);
                        break;
                    case 3:
                        TryDeposit(account);
                        break;
                    case 4:
                        ChangePassword(user);
                        break;
                    case 5:
                        Console.WriteLine("Muchas gracias por elegirnos");
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
            } while (option != 5);
        }

        private static void ChangePassword(User user)
        {
            Console.WriteLine("**** Cambio de contraseña ****");
            Console.Write("Nueva contraseña: ");
            ushort newPassword=ushort.Parse(Console.ReadLine());
            user.Password = newPassword;
            Console.WriteLine("Contraseña guardada con exito");
            CheckPassword(user);
        }

        private static void TryDeposit(Account account)
        {
            Console.WriteLine("**** Deposito ****");
            Console.Write("Valor a depositar: $");
            ulong amount = ulong.Parse(Console.ReadLine());
            Console.Write($"Nuevo saldo disponible: {account.Deposit(amount)}");
        }

        private static void TryWithdraw(Account account)
        {
            Console.WriteLine("**** Retiro ****");
            Console.Write("Valor a retirar: $");
            ulong amount = ulong.Parse(Console.ReadLine());
            if (amount > account.Balance) {
                Console.WriteLine("No tiene saldo suficiente");
            }
            else
            {
                Console.Write($"Nuevo saldo disponible: {account.Withdraw(amount)}");
            }
        }

        private static void CheckPassword(User user)
        {
            Console.WriteLine("Ingrese su contraseña: ");
            ushort guessPassword = ushort.Parse(Console.ReadLine());
            if (guessPassword == user.Password)
            {
                Console.Clear();
                Console.WriteLine("Contraseña correcta");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Contraseña incorrecta");
            }
        }

        static void ShowBalance(Account account)
        {
            Console.WriteLine("**** Consulta de Saldo ****");
            Console.WriteLine($"Su saldo es: ${account.Balance}");
        }

        static Dictionary<int,User> LoadUsers()
        {
            users = new Dictionary<int, User>() 
            {
                { 1234567890,new("Davis Ayus", 0000) },
                { 0987654321,new("Juan Rodriguez", 1992) },
                { 1001920380,new("Dolcey Mendoza", 9999) },
            };
            return users;
        }
    }
}
