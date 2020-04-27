using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

namespace Bdd_Cooking
{
    class CreateurDeRecette:User
    {
        string pseudo;
        string cdr_Or;
        string cdr_Semaine;
        int solde_Cook;

        public CreateurDeRecette(string pseudo, string cdr_Or,string cdr_Semaine,int solde_Cook)
        {
            this.pseudo = pseudo;
            this.cdr_Or = cdr_Or;
            this.cdr_Semaine = cdr_Semaine;
            this.solde_Cook = solde_Cook;
        }
        public CreateurDeRecette(string pseudo)
        {
            this.pseudo = pseudo;
        }
        public CreateurDeRecette()
        {

        }

        public override bool identification()
        {
            throw new NotImplementedException();
        }
        public override void showMenu()
        { }

        public string Pseudo
        {
            get { return this.pseudo; }
            set { this.pseudo = value; }
        }
        public string Cdr_Or
        {
            get { return this.cdr_Or; }
            set { this.cdr_Or = value; }
        }
        public string Cdr_semaine
        {
            get { return this.cdr_Semaine; }
            set { this.cdr_Semaine = value; }
        }
        public int Solde_Cook
        {
            get { return this.solde_Cook; }
            set { this.solde_Cook = value; }
        }
        public string AffichageListeCdr()
        {
            string des = "";
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=root;PASSWORD=NacimaSql99;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT pseudo,num_C FROM cdr;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string pseudo;
            string num_C;
            Console.WriteLine("Liste des createurs de recettes : ");
            while (reader.Read())
            {
                pseudo = reader.GetString(0);
                num_C= reader.GetString(1);
       
                Console.WriteLine("\nPseudo " + pseudo + "\nNumeros de client :" + num_C);
            }
            connection.Close();
            return des;
        }
        public void CreationRecette()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=root;PASSWORD=NacimaSql99;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Veuillez saisir les informations suivantes :\n");
            Console.WriteLine("\nNom de la recette: \n");
            string nom_R = Console.ReadLine();
            Console.WriteLine("\nType de recette: \n");
            string type = Console.ReadLine();
            Console.WriteLine("\nDescriptif: \n");
            string descriptif = Console.ReadLine();
            Console.WriteLine("\nPrix de vente : \n");
            string prix = Console.ReadLine();
            string insertTable = "insert into recette (nom_recette,type,descriptif,prix_vente,Pseudo) Values ('" + nom_R + "','" + type + "','" + descriptif + "','" + prix + "','" + this.pseudo + "')";
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
        public string AffichageRecetteCree()
        {
            string des = "";
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=root;PASSWORD=NacimaSql99;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT * FROM recette where pseudo='"+this.pseudo+"';";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string nom_recette;
            string type;
            string descriptif;
            string prix_vente;
            Console.WriteLine("Liste des recettes creees par "+this.pseudo+" : ");
            while (reader.Read())
            {
                nom_recette = reader.GetString(0);
                type = reader.GetString(1);
                descriptif = reader.GetString(2);
                prix_vente = reader.GetString(3);
                Console.WriteLine("\n" + nom_recette.ToUpper() + "\nType :" + type + "\nDescriptif: " + descriptif + "\nPrix : " + prix_vente + " euros");
            }
            connection.Close();
            return des;
        }

        public void AjouterCdr()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=root;PASSWORD=NacimaSql99;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Veuillez saisir les informations suivantes :\n");
            Console.WriteLine("\nIdentifiant: \n");
            string id = Console.ReadLine();
            Console.WriteLine("\nPseudo: \n");//Verifier qu'il n'existe pas
            string ps= Console.ReadLine();
            string insertTable = "insert into cdr(Pseudo,num_C,Cdr_Or,Cdr_Semaine,solde_cook) VALUES ('"+ps+"','"+id+"','"+ null+"','"+ null+"',"+0+");";
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
            Console.WriteLine("Vous etes maintenant createur de recette");
            command.Dispose();

        }
    }
}
