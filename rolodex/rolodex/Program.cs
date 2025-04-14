using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace rolodex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Choice 1: look at everything
            //Choice 2: add a new entry
            //Choice 3: Delete an entry
            //Choice 4: Select process
            //Choice 4: Exit application

            bool loop = true;
            while (loop)
            { 
                //Prompt user for choice
                Console.WriteLine("Please enter your Choice: ");
                Console.WriteLine("Enter 1 to view Rolodex entries:");
                Console.WriteLine("Enter 2 to enter new Rolodex Entry");
                Console.WriteLine("Enter 3 to Delete entry:");
                Console.WriteLine("Enter 4 to Update entry:");
                Console.WriteLine("Enter 5 to Exit application:");

                int choice = int.Parse(Console.ReadLine());

            //connection - where is the DB?
            SqlConnection connection = new SqlConnection
                (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Samuel\source\repos\Session16\ClassExcercises\rolodex\rolodex\Database1.mdf;Integrated Security=True");

                SqlCommand command = new SqlCommand();

                if (choice == 1)
                {
                    //Connection, Command (SELECT), Reader connection.Open()
                    command = new SqlCommand("SELECT * FROM Rolodek;", connection);

                   connection.Open();
                    //reader - actually run the command and look @ the results
                    SqlDataReader reader = command.ExecuteReader();
                 
                    while (reader.Read())
                    {
                        Console.WriteLine("Name: " + reader["Name"]);
                        Console.WriteLine("Street: " + reader   ["Street"]);
                        Console.WriteLine("State: " + reader["State"]);
                        Console.WriteLine("Zip: " + reader["Zip"]);
                        Console.WriteLine("Email: " + reader["Email"]);
                    }
                        Console.WriteLine();
                    //close our  reader?
                    reader.Close();
                    connection.Close();
                }         

                else if (choice == 2)
                {
                    connection.Open();
                    Console.WriteLine("Please enter your new information: "); //Prompt user for info for Rolodex 

                    Console.WriteLine("Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Street: ");
                    string street = Console.ReadLine();
                    Console.WriteLine("State: ");
                    string state = Console.ReadLine();
                    Console.WriteLine("Zip: ");
                    string zip = Console.ReadLine();
                    Console.WriteLine("Email: ");
                    string email = Console.ReadLine();

                    //Put saved info into Database
                    command = new SqlCommand($"INSERT INTO Rolodek (name, address, phone, email) \r\nVALUES ('{name}', '{street}', '{state}', '{zip}', '{email}');", connection);
                    //Running command issued above, Query command = Select, Insert = nonQuery
                    command.ExecuteNonQuery();
                    Console.WriteLine("New Data Added!");
                    connection.Close();
                }
                //delete entry from Rolodek
                else if (choice == 3)
                {
                    connection.Open();
                    Console.WriteLine("Please enter the Name of the Rolodek entry to Delete: (Warning this is Permanent)");
                    string selection = Console.ReadLine();


                }
                //Update Entry in Rolodek
                else if (choice == 4)
                {
                    //what to update

                }
                //Exit application
                else if (choice == 5)
                {
                    Console.WriteLine("Thanks for using Rolodek");
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Invalid Choice. Try Again");
                }
                
            }
                //reader.Close();
        }
    }
}