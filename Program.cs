using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_JeuFourchette_MOREAUX_Roméo.cs
{
    class Program
    {

        static Random rndNumbers = new Random();
        static int de1, de2, de3, de4;
        static int jeton = 0;
        static int somme = 0;
        static int partieJouer = 0;
        static int partieGagne = 0;
        static int partiePerdu = 0;
        static int somme_jetons = 0;
        static int mise = 0;

        static void lancerdes()
        {
            de1 = rndNumbers.Next(1, 7);
            de2 = rndNumbers.Next(1, 7);
            de3 = rndNumbers.Next(1, 7);
            de4 = rndNumbers.Next(1, 7);
            somme = de1 + de2 + de3 + de4;
            bool relancer = true;
            do
            {
                Console.WriteLine("Dé1 : {0} Dé2 : {1} Dé3 : {2} Dé4 : {3}", de1, de2, de3, de4);

                if (de1 == de2 && de2 == de3 && de3 == de4)
                {
                    jeton = jeton + 50;

                    Console.WriteLine("Vous avez gagné 50 jetons! Total jeton : " + jeton);
                    partieGagne++;

                    mise = mise * jeton;
                    Console.WriteLine("Vous avez gagné" +mise+ " euros !");

                    Console.WriteLine("Vous avez gagné" +partieGagne+ " partie.");

                    partieJouer++;
                    Console.WriteLine("Vous avez joué" + partieJouer + " partie.");

                    relancer = rejouer();
                }
                else if (de1 == de2 && de2 == de3 || de1 == de2 && de2 == de4 || de2 == de3 && de2 == de4 || de1 == de2 && de2 == de4 || de1 == de3 && de3 == de4 || de2 == de3 && de3 == de1)
                {
                    jeton = jeton + 10;

                    Console.WriteLine("Vous avez gagné 10 jetons! Total jeton : " + jeton);
                    partieGagne++;

                    mise = mise * jeton;
                    Console.WriteLine("Vous avez gagné " + mise + " euros !");

                    Console.WriteLine("Vous avez gagné " + partieGagne + " partie.");
                    partieJouer++;

                    Console.WriteLine("Vous avez joué" + partieJouer + " partie.");

                    relancer = rejouer();
                }
                else if (de1 == de2 || de1 == de3 || de1 == de4 || de2 == de3 || de2 == de4 || de3 == de4)
                {
                    jeton = jeton + 5;

                    Console.WriteLine("Vous avez gagné 5 jetons! Total jeton : " + jeton);
                    partieGagne++;

                    mise = mise * jeton;
                    Console.WriteLine("Vous avez gagné " + mise + " euros !");

                    Console.WriteLine("Vous avez gagnées " + partieGagne + " partie.");
                    partieJouer++;

                    Console.WriteLine("Vous avez jouées " + partieJouer + " partie.");
                    relancer = rejouer();
                }
                else if (somme % 2 == 0 && somme < 14 || somme > 14)
                {
                    Console.WriteLine("La somme des dés est pair !");
                    jeton++;

                    mise = mise * jeton;
                    Console.WriteLine("Vous avez gagné " + mise + " euros !");

                    Console.WriteLine("Vous avez gagner 1 jeton ! Total jeton :  " + jeton);
                    partieGagne++;

                    Console.WriteLine("Vous avez gagnées " + partieGagne + " partie.");
                    partieJouer++;

                    Console.WriteLine("Vous avez jouées " + partieJouer + " partie.");
                    relancer = rejouer();
                }
                else
                {
                    Console.WriteLine("Dommage vous avez perdu !");
                    mise = somme_jetons - mise;
                    Console.WriteLine("Vous avez " + mise + " euros");

                    partieJouer++;
                    partiePerdu++;
                    Console.WriteLine("Vous avez perdues " +partiePerdu+ " partie.");
                    Console.WriteLine("Vous avez jouées " + partieJouer + " partie.");
                }
            } while (relancer == true);
        }

        static bool rejouer()
        {
            bool erreur = false;
            bool replay = false;
            string valeur = "";
            do
            {
                try
                {
                    Console.WriteLine("Voulez-vous rejouez ?");
                    Console.WriteLine("  'o' ou 'O' pour 'oui', 'n' ou 'N' pour non. ");
                    valeur = Console.ReadLine();
                    erreur = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur de saisie, veuillez entrez 'o' 'O' ou 'n' 'N'.");
                    erreur = true;
                }

                if (valeur == "o" || valeur == "O")
                {
                    de1 = rndNumbers.Next(1, 7);
                    de2 = rndNumbers.Next(1, 7);
                    de3 = rndNumbers.Next(1, 7);
                    de4 = rndNumbers.Next(1, 7);
                    replay = true;
                }
                else
                {
                    if (valeur == "n" || valeur == "N")
                    {
                        replay = false;
                    }
                    else
                    {
                        erreur = true;
                        Console.WriteLine("Erreur de saisie, veuillez entrez 'o' 'O' ou 'n' 'N'.");
                    }
                }
            } while (erreur == true);

            return replay;
        }

        static int recupereValeur(int valeur)
        {
            bool erreur = false;
            do
            {
                try
                {
                    valeur = int.Parse(Console.ReadLine());
                    erreur = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur de saisie, veuillez entrez un nombre entier.");
                    erreur = true;
                }

            } while (erreur == true);

            return valeur;
        }

        static void Main(string[] args)
        {
            string nom = " ";
            string prenom = " ";
            int age = 0;
            
            

            Console.WriteLine("Quel est votre age?");
            age = recupereValeur(age);

            if (age >= 18)
            {            
                Console.WriteLine("Quel est votre nom ?");
                nom = Console.ReadLine();
                Console.WriteLine("Quel est votre prenom?");
                prenom = Console.ReadLine();

                do
                {
                    Console.WriteLine("Quel est la somme de vos jetons?");
                    somme_jetons = recupereValeur(somme_jetons);

                    if(somme_jetons < 10 || somme_jetons > 1000)
                    {
                        Console.WriteLine("La somme du montant de vos jetons doivent être compris en 1 et 1000.");
                        Console.WriteLine();
                    }
                        
                } while (somme_jetons < 10 || somme_jetons > 1000);


                Console.WriteLine("Bienvenue à la table du jeu de la Fourchette");
                Console.WriteLine("********************************************");
                Console.WriteLine("A vous de jouer !");
           

                do
                {
                    Console.WriteLine("Combien souhaitez-vous misez?");
                    mise = int.Parse(Console.ReadLine());

                    if (mise > somme_jetons)
                    {
                        Console.WriteLine("Votre mise ne peut être supérieur à la somme en euros de vos jetons.");
                        Console.WriteLine();
                    }
                    else if(mise <= 0)
                    {
                        Console.WriteLine("Vous devez miser quelque chose pour pouvoir jouer.");
                    }
                    else if(mise > 100)
                    {
                        Console.WriteLine("Votre mise est ne peut être supérieur à 100");
                    }

                } while (mise > somme_jetons && mise > 100);

                Console.WriteLine("Appuyer sur une touche pour lancer les dés");
                Console.ReadKey();
                Console.WriteLine();
                lancerdes();
                        
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Tu es mineur !!");
                Console.ReadKey();
            }
        }
    }
}
