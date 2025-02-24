﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AdoNetConsoleAppCrud
{
    class Program
    {
        public static void CreateConnection(SqlConnection conn)
        {
            conn.Open();
            Console.WriteLine("Database Connected Successfully");
            conn.Close();
        }
        public static void CreateTable(SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("CREATE TABLE student(name nvarchar(100) NOT NULL,email nvarchar(100) NOT NULL, )", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }public static void InsertIntoTable(SqlConnection conn)
        {
            try
            {
                Console.Write("Enter your Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter your Email: ");
                string email = Console.ReadLine();
                SqlCommand cmd = new SqlCommand($"INSERT INTO student (name,email) VALUES ( '{name}', '{email}' )", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        
        public static void Retrieve(SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM student", conn);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine("Name: "+sdr["name"] + " Email: " + sdr["email"]);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        static void Main(string[] args)
        {
            string cs = "data source=.;database=AdoNetConsoleCrud;Integrated Security = true";
            SqlConnection conn = new SqlConnection(cs);
            //CreateConnection(conn);
            //CreateTable(conn);
            //InsertIntoTable(conn);
            Console.WriteLine("Retriving data from Database:");
            Retrieve(conn);
            Console.ReadLine();
        }
    }
}
