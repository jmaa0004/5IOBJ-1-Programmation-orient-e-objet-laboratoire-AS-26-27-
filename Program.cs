using System;

class Jeu /* Je me suis rendu compte à posteriori qu'un switch aurait été mieux. 
Mais j'ai vu qu'il était mieux que je crée une classe pour cela */
{
    static void Main()
    {
        string[] panier = new string[5] /* Nombre d'article */;
        int nombreElements = 0 /*Au debut */;
        bool continuer = true;

        Console.WriteLine("Bienvenue au marché !");

        while (continuer)
        {
            Console.WriteLine("1. Ajouter un fruit ou un légume");
            Console.WriteLine("2. Retirer un fruit ou un légume");
            Console.WriteLine("3. Afficher le contenu du panier");
            Console.WriteLine("4. Rechercher un fruit ou un légume");
            Console.WriteLine("5. Quitter");
            Console.Write("Quelle opération souhaitez-vous effectuer ?");

            string choix = Console.ReadLine();

            if (choix == "1")
            {
                //Ajout d'élement
                if (nombreElements < 5)
                {
                    Console.Write("Entrez le nom du fruit ou légume à ajouter : ");
                    string nouvelElement = Console.ReadLine()?.Trim();

                    if (string.IsNullOrEmpty(nouvelElement))
                    {
                        Console.WriteLine("Erreur : Le nom ne peut pas être vide.");
                    }
                    else
                    {
                        bool existeDeja = false;
                        int i = 0;
                        
                        // La boucle s'arrête si on atteint la fin OU si on trouve un doublon
                        while (i < nombreElements && !existeDeja)
                        {
                            if (panier[i].Equals(nouvelElement, StringComparison.OrdinalIgnoreCase))
                            {
                                existeDeja = true;
                            }
                            i++;
                        }

                        if (existeDeja)
                        {
                            Console.WriteLine($"Le panier contient déjà '{nouvelElement}'. Doublon refusé.");
                        }
                        else
                        {
                            panier[nombreElements] = nouvelElement;
                            nombreElements++;
                            Console.WriteLine($"'{nouvelElement}' a été ajouté au panier. ({nombreElements}/5)");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Le panier est plein (5 articles maximum).");
                }
            }
            else if (choix == "2")
            {
                //RETIRER
                if (nombreElements == 0)
                {
                    Console.WriteLine("Le panier est vide, il n'y a rien à retirer.");
                }
                else
                {
                    Console.Write("Entrez le nom du fruit ou légume à retirer : ");
                    string elementARetirer = Console.ReadLine()?.Trim();
                    
                    bool trouvePourRetrait = false;
                    int i = 0;

                    // La boucle s'arrête si on trouve l'élément à retirer
                    while (i < nombreElements && !trouvePourRetrait)
                    {
                        if (panier[i].Equals(elementARetirer, StringComparison.OrdinalIgnoreCase))
                        {
                            trouvePourRetrait = true;
                            
                            // Décaler les éléments suivants vers la gauche
                            for (int j = i; j < nombreElements - 1; j++)
                            {
                                panier[j] = panier[j + 1];
                            }
                            
                            panier[nombreElements - 1] = null; 
                            nombreElements--;
                            Console.WriteLine($"'{elementARetirer}' a été retiré du panier.");
                        }
                        i++;
                    }

                    if (!trouvePourRetrait)
                    {
                        Console.WriteLine($"'{elementARetirer}' ne se trouve pas dans le panier.");
                    }
                }
            }
            else if (choix == "3")
            {
                // Affichage
                if (nombreElements == 0)
                {
                    Console.WriteLine("Votre panier est actuellement vide.");
                }
                else
                {
                    Console.WriteLine($"Contenu du panier ({nombreElements}/5) :");
                    for (int i = 0; i < nombreElements; i++)
                    {
                        Console.WriteLine($"- {panier[i]}");
                    }
                }
            }
            else if (choix == "4")
            {
                //Rechercher
                if (nombreElements == 0)
                {
                    Console.WriteLine("Le panier est vide, la recherche est impossible.");
                }
                else
                {
                    Console.Write("Que voulez-vous rechercher ? ");
                    string recherche = Console.ReadLine()?.Trim();
                    
                    bool trouvePourRecherche = false;
                    int i = 0;

                    while (i < nombreElements && !trouvePourRecherche)
                    {
                        if (panier[i].Equals(recherche, StringComparison.OrdinalIgnoreCase))
                        {
                            trouvePourRecherche = true;
                            Console.WriteLine($"Oui, '{panier[i]}' se trouve bien dans votre panier (à la position {i + 1}).");
                        }
                        i++;
                    }

                    if (!trouvePourRecherche)
                    {
                        Console.WriteLine($"Non, '{recherche}' n'est pas dans votre panier.");
                    }
                }
            }
            else if (choix == "5")
            {
                //interactivité avec une possibilité de quitter
                continuer = false;
                Console.WriteLine("Merci d'avoir visité le marché. Au revoir !");
            }
            
        }
    }
}
