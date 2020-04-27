using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

namespace Bdd_Cooking
{
    class Client : User
    {
        string num_C;
        string nom_C;
        string prenom_C;
        string tel_C;
        double solde;

        public Client(string num_C,string nom_C,string prenom_C,string tel_C,double solde)
        {
            this.nom_C = nom_C;
            this.prenom_C = prenom_C;
            this.tel_C = tel_C;
            this.solde = solde;
            this.num_C = num_C;
        }
        public Client(string num_C)
        {
            this.num_C = num_C;
        }
        public Client()
        {
        }

        public string Nom_C
        {
            get { return this.nom_C; }
            set { this.nom_C = value; }
        }
        public string Prenom_C
        {
            get { return this.prenom_C; }
            set { this.prenom_C = value; }
        }

        public string Tel_C
        {
            get { return this.tel_C; }
            set { this.tel_C = value; }
        }
        public double Solde
        {
            get { return this.solde; }
            set { this.solde= value; }
        }

        public override bool identification()
        {
          
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=root;PASSWORD=NacimaSql99;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            Console.WriteLine("Veuillez saisir votre identifiant :");
            string id = Console.ReadLine();
            Console.WriteLine("Veuillez saisir votre Nom :");
            string nom = Console.ReadLine();
            string identification = "select count(*),nom_C,prenom_C  from client where num_C='" + id+"'and nom_C='"+nom+"'";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = identification;
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            reader.Read();
            bool connexion = Convert.ToBoolean(reader.GetInt32(0));

            if (connexion == true)
            {
                Console.WriteLine("Vous etes connecté.");
                this.nom_C = reader.GetString(1);
                this.prenom_C = reader.GetString(2);
                Console.WriteLine("Nom :" + nom_C);
            }
            else
            {
                Console.WriteLine("Votre identifiant n'existe pas ou est erroné.");
            }
            
            command.Dispose();
            Console.WriteLine(Convert.ToInt32(connexion));
            return connexion;
        }
        public void Affichageclient()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=root;PASSWORD=NacimaSql99;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText =" SELECT * FROM client ;";

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
                Console.WriteLine("\nNuméros de client : " + num +"\nNOM :" + nom.ToUpper() + "\nPrénom : " + prenom+ "\nn° Telephone : "+tel + "\nSolde disponible : " + solde+ "euros");
                Console.WriteLine("");
            }

            connection.Close();
        }
        public void AjouterClient()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=root;PASSWORD=NacimaSql99;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Veuillez saisir les informations suivantes :\n");
            Console.WriteLine("\nNom: \n");
            string nom = Console.ReadLine();
            Console.WriteLine("\nPrenom: \n");
            string prenom = Console.ReadLine();
            Console.WriteLine("\nNuméros de Telephone: \n");
            string tel = Console.ReadLine();
            Console.WriteLine("\nIdentifiant:(Initiale en majuscule suivit des 3 derniers chiffres du numeros de telephone. Exemple : NB789) \n");
            string id = Console.ReadLine();
            double solde = 0;
            string insertTable = "insert into client(num_C,nom_C,prenom_C,tel_C,solde) Values ('" + id + "','" + nom + "','" + prenom + "','" + tel + "','" + solde + "')";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = insertTable;
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
        public bool verifIdRecette()
        {
            return true;
        }
        public void AffichageListeRecettes()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=root;PASSWORD=NacimaSql99;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT * FROM recette ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string id_recette;
            string nom_recette;
            string type;
            string descriptif;
            string prix_vente;
            string Pseudo;
            Console.WriteLine("Liste des recettes : ");
            while (reader.Read())
            {
                id_recette = reader.GetString(0);
                nom_recette = reader.GetString(1);
                type = reader.GetString(2);
                descriptif = reader.GetString(3);
                prix_vente = reader.GetString(4);
                Pseudo = reader.GetString(5);
                Console.WriteLine("\n" + nom_recette.ToUpper() + " réalisé par " + Pseudo + "\nReference recette : "+ id_recette + "\nType :" + type + "\nDescriptif: " + descriptif + "\nPrix : " + prix_vente + " euros");
            }
            connection.Close();
        }

        public void AffichageSoldeCook()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=root;PASSWORD=NacimaSql99;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select solde from client where num_C='"+this.num_C+"';";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string solde;
            while (reader.Read())
            {
                solde= reader.GetString(4);
                Console.WriteLine("Votre solde est de : " + solde);
                Console.WriteLine("");
            }
    
            connection.Close();
        }
        public void Commander()
        {

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=root;PASSWORD=NacimaSql99;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            Console.WriteLine("Bonjour et bienvenue dans notre espace commande !");
            Console.WriteLine("\nVous pouvez observer la liste des recettes actuelles proposées par nos créateurs :");
            this.AffichageListeRecettes();
            Console.WriteLine("\n\nVeuillez saisir la référence de la recette choisie");
            string id = Convert.ToString(Console.ReadLine());


            string verif = "select count(*),id_recette from recette where id_recette='" + id + "'";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = verif;
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            reader.Read();
            bool estpresent = Convert.ToBoolean(reader.GetInt32(0));

            if (estpresent == true)
            {
                Console.WriteLine("\nSaisie réussie");

                //On doit incrémenter le compteur de recette (nb de fois qu'elle a été commandée)
                //On doit retirer au solde client le prix de vente de la recette
                //On doit ajouter au solde client CdR le prix de vente de la recette (verifier les pourcentages)
                //On doit Retirer la quantite de produit utilisée des stocks
                //On doit faire évoluer les qte à commander

            }
            else
            {
                Console.WriteLine("\nId inexistant");
            }

        }
        public override void showMenu()
        {
            Console.WriteLine("  \t BIENVENUE DANS LE MENU CLIENT \n\n\n 1 : Commander \n\n 2 : Historique des commandes \n\n 3 : Consulter Mon Solde ");//specify the different type of actions possible for an employee
            String entree = Console.ReadLine();
            Console.Clear();

            switch (entree)
            {
                case "1":
                    Console.WriteLine("Commander");
                    this.Commander();
                    Console.Clear();
                    break;

                case "2":
                    Console.WriteLine("Afficher l'historique des commandes");
                    //this.HistoriqueCommandes();
                    Console.Clear();
                    break;

                case "3":
                    Console.WriteLine("Affichage du Solde Cook");
                    AffichageSoldeCook();
                    //Console.Clear();
                    break;

                default:
                    Console.WriteLine("Incorrect Input");
                    break;
            }
        }
    }

}
