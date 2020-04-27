using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

namespace Bdd_Cooking
{
    class Program
    {
        static void ConnexionMySQL()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=root;PASSWORD=NacimaSql99;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
        }
        
        static void CreationTable()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=root;PASSWORD=NacimaSql99;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string createTable = " CREATE TABLE Valentin (nom VARCHAR(25));";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = createTable;
            try
            {
                command.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command.Dispose();
        }

        static void Affichageclient()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=root;PASSWORD=NacimaSql99;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT * FROM client ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string num;
            string nom;
            string prenom;
            string tel;
            string solde;
            while (reader.Read())
            {
                num = reader.GetString(0);
                nom = reader.GetString(1);
                prenom = reader.GetString(2);
                tel = reader.GetString(3);
                solde = reader.GetString(4);
                Console.WriteLine("Liste des clients : ");
                Console.WriteLine("\nNuméros de client : " + num + "\nNOM :" + nom.ToUpper() + "\nPrénom : " + prenom + "\nn° Telephone : " + tel + "\nSolde disponible : " + solde + "euros");
                Console.WriteLine("");
            }

            connection.Close();
        }

     
        static void Main(string[] args)
        {
            //ConnexionMySQL();

            //Affichageclient();
            //CreationTable();

            //Console.Clear();
            //Client c = new Client();
            //c.AffichageSoldeCook();
            //c.NouveauClient();
            //c.Identification();
            //Recette r = new Recette();
            //r.AffichageRecette();

            //r.AffichageListeRecette();
            //CreateurDeRecette cdr = new CreateurDeRecette();
            //cdr.AffichageListeCdr();
            //cdr.CreationRecette();
            //cdr.AffichageRecetteCree();

            //Console.WriteLine("Liste des clients : \n");
            //Affichageclient();

            Console.WriteLine("Bienvenue sur Cooking !");
            Console.WriteLine("\nVeuillez selectionner votre statut, \n1: Client \n2: Employé Cooking \n3 : Espace CdR");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (a == 1)//client, specific menu has to be called
            {
                Client c = new Client();
                Console.WriteLine("\n1: Connexion \n2: Inscription");
                int w = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (w == 1)
                {
                    if (c.identification())
                    {
                        c.showMenu();
                    }
                }
                if (w == 2)
                {
                    c.AjouterClient();
                    Console.WriteLine("\nCompte crée");
                    Console.WriteLine("\nIf you want to exit the program press E, return to the menu press R");

                    ConsoleKeyInfo l = Console.ReadKey();
                    if (l.Key == ConsoleKey.E)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nVeuillez à présent vous connecter");
                        if (c.identification())
                        {
                            c.showMenu();
                        }
                    }
                }
            }
            else if (a == 2)//Employee
            {
                Cooking e = new Cooking();
                if (e.identification())//checking if the loggin was successful
                {
                    Console.WriteLine("\nLogin Successfull");
                    Console.Clear();
                    Console.WriteLine("\nWELCOME COOKING EMPLOYEE");
                    Console.WriteLine();
                    e.showMenu();
                }
                else
                {
                    Console.WriteLine("\nLogin Unsuccessfull");
                    Console.Clear();
                }
                Console.ReadKey();
            }
            else if (a == 3)
            {
                Console.WriteLine("\n1: Connexion \n2:Inscription ");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (b == 1)
                {
                    CreateurDeRecette o = new CreateurDeRecette();
                    if (o.identification())
                    {
                        Console.WriteLine("Login Successfull");
                        Console.Clear();
                        Console.WriteLine("WELCOME CDR");
                        Console.WriteLine();
                        o.showMenu();
                    }
                }
                if (b == 2)
                {
                    Console.WriteLine("1: Vous possedez un compte client et vous souhaitez devenir createur de recette? \n2: Vous souhaitez vous inscrire en tant que nouveau client et createur de recette ?");
                    int c = Convert.ToInt32(Console.ReadLine());
                    CreateurDeRecette o = new CreateurDeRecette();
                    Console.Clear();
                    if(c==1)
                    {
                        o.AjouterCdr();
                    }
                    if(c==2)
                    {
                        //Renvoyer vers AjouterClient()? ou on considere qu'ils sont tous deja client ? 
                      
                    }
                   
                }
            }
            else
            {
                Console.WriteLine("\nPlease, choose the option 1 or 2 ");
            }
            Console.ReadKey();

        }
    }
}
