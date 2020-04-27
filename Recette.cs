using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

namespace Bdd_Cooking
{
    class Recette
    {
        string nom_recette;
        string type;
        string descriptif;
        int prix_vente;

        public Recette(string nom_recette,string type,string descriptif, int prix_vente)
        {
            this.nom_recette=nom_recette;
            this.type=type;
            this.descriptif=descriptif;
            this.prix_vente=prix_vente;

        }
        public Recette()
        {
        }
        public Recette(string nom_recette)
        {
            this.nom_recette = nom_recette;
        }

        public string Nom_recette
        {
            get { return this.nom_recette; }
            set { this.nom_recette = value; }
        }
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public string Descriptif
        {
            get { return this.descriptif; }
            set { this.descriptif=value; }
        }
        public int Prix_vente
        {
            get { return this.prix_vente; }
            set { this.prix_vente= value; }
        }
        public string AffichageListeRecette()
        {
            string des = "";
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=root;PASSWORD=NacimaSql99;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT * FROM recette ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string nom_recette;
            string type;
            string descriptif;
            string prix_vente;
            string Pseudo;
            Console.WriteLine("Liste des recettes : ");
            while (reader.Read())
            {
                nom_recette = reader.GetString(0);
                type= reader.GetString(1);
                descriptif = reader.GetString(2);
                prix_vente= reader.GetString(3);
                Pseudo = reader.GetString(4);
                Console.WriteLine("\n"+ nom_recette.ToUpper()+" réalisé par "+Pseudo+ "\nType :" + type + "\nDescriptif: " + descriptif + "\nPrix : " + prix_vente + " euros");
            }
            connection.Close();
            return des;
        }
        public string AffichageRecette()
        {
            string des = "";
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=root;PASSWORD=NacimaSql99;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT * FROM recette where nom_recette='" + this.nom_recette + "';";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string nom_recette;
            string type;
            string descriptif;
            string prix_vente;
            Console.WriteLine(""+this.nom_recette.ToUpper()+" : ");
            while (reader.Read())
            {
                nom_recette = reader.GetString(0);
                type = reader.GetString(1);
                descriptif = reader.GetString(2);
                prix_vente = reader.GetString(3);
                Console.WriteLine("\nType :" + type + "\nDescriptif: " + descriptif + "\nPrix : " + prix_vente + " euros");
            }
            connection.Close();
            return des;
        }
            

        


    }
}
