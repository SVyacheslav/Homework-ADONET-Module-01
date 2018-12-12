﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Configuration;




namespace Con_OracleClient
{
    class Program
    {
        static Program()
        {

            // Используется подключение "по умолчанию" определенного в файле App.config. Если используется подключение из строки в коде, нижеследующую строку нужно раскомментировать
            //connectionString = @"Data Source=Oracle11i;Integrated Security=yes";
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            OracleConnection con = new OracleConnection();

            // получаем строку подключения для App.config. Если используется подключение из строки в коде, нижеследующую строку нужно закомментировать
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con.ConnectionString = connectionString;

            try
            {
                con.Open();
                Console.WriteLine("Подключение открыто");
                Console.WriteLine("Свойства подключения:");
                Console.WriteLine("\tСтрока подключения: {0}", con.ConnectionString);
                Console.WriteLine("\tБаза данных: {0}", con.Database);
                Console.WriteLine("\tСервер: {0}", con.DataSource);
                Console.WriteLine("\tВерсия сервера: {0}", con.ServerVersion);
                Console.WriteLine("\tСостояние: {0}", con.State);
                Console.WriteLine("\tВремя ожидания: {0}", con.ConnectionTimeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Dispose();
            }
            Console.WriteLine("Подключение закрыто...");
            Console.Read();
        }
    }
    }
}
