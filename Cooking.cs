using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdd_Cooking
{
    class Cooking : User
    {
        public override bool identification()
        {
            int rCounter = 0;
            bool loginFlag = true;
            string input;
            Console.WriteLine("Veuillez rentrer la clé d'entrée au Service Cooking Employee : ");
            input = Console.ReadLine();
            Console.Clear();


            while (!(input == "A1234"))
            {
                Console.WriteLine("Mot de passe Incorrect, Essayez à nouveau!");
                input = Console.ReadLine();
                rCounter++;
                if (rCounter == 3)    //We defined 3 as the number of retries possible
                {
                    loginFlag = false;
                    Console.WriteLine(" Nombre de tentatives écoulé ");
                    break;
                }
                Console.Clear();
            }
            return loginFlag;
        }
        public override void showMenu()
        { }
    }
}
