using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OverWatchBuddy
{
    class Program
    {
        static void Main(string[] args)
        {
            TitleScreen();
            MainMenu();
            DisplayClosingScreen();
        }

        static void MainMenu()
        {
            List<Hero> heros;
            heros = InitializeHeroList();
            Hero userHero = null;
            Hero enemyHero = null;
            string menuChoice;
            bool runApp = true;

            while (runApp)
            {
                DisplayHeader("\tMain Menu");

                // get user choice
                Console.WriteLine("A) Choose your Hero");
                Console.WriteLine("B) Hero Information");
                Console.WriteLine("C) Enemy Hero");
                Console.WriteLine("D) Enemy Hero Information");
                Console.WriteLine("Q) Quit");
                menuChoice = Console.ReadLine().ToUpper();

                switch (menuChoice)
                {
                    case "A":
                        HeroName userHeroName;
                        userHeroName = HeroSelectScreen();
                        foreach (Hero hero in heros)
                        {
                            if (hero.Name == userHeroName)
                            {
                                userHero = hero;
                            }
                        }
                        break;
                    case "B":
                        HeroInfoScreen(userHero);
                        break;
                    case "C":
                        HeroName enemyHeroName;
                        enemyHeroName = EnemyHeroSelectScreen();
                        foreach (Hero hero in heros)
                        {
                            if (hero.Name == enemyHeroName)
                            {
                                enemyHero = hero;
                            }
                        }
                        break;
                    case "D":
                        EnemyHeroInfoScreen(enemyHero);
                        break;
                    case "Q":
                        runApp = false;
                        break;
                    default:
                        break;

                }
            }
        }


        static Hero EnemyHeroInfoScreen(Hero enemyHero)
        {
            DisplayHeader("Enemy Hero Information");

            Console.WriteLine(enemyHero.Name);
            Console.WriteLine(enemyHero.Role);
            Console.WriteLine(enemyHero.Description);
            Console.WriteLine();
            Console.WriteLine("Countered by:");
            foreach (HeroName heroName in enemyHero.Counter)
            {
                Console.WriteLine(heroName);
            }

            DisplayContinuePrompt();
            return enemyHero;
        }

        static HeroName EnemyHeroSelectScreen()
        {
            HeroName enemyHero;
            string[] HeroList;
            string userResponse;
            bool validResponse = false;
            DisplayHeader("\tHero Selection Screen");
            string dataPath = @"Heroes\HeroList.txt";

            HeroList = File.ReadAllLines(dataPath);
            foreach (string line in HeroList)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
            Console.WriteLine();


                do
            {

                Console.WriteLine("Please select hero:");
                userResponse = Console.ReadLine().ToUpper();

                if (!Enum.TryParse(userResponse, out enemyHero))
                {
                    Console.WriteLine("Please choose a hero.");
                    DisplayContinuePrompt();
                }
                else
                {
                    validResponse = true;
                }

            } while (!validResponse);

            Console.WriteLine();
            Console.WriteLine($"You chose {enemyHero}.");

            DisplayContinuePrompt();

            return enemyHero;
        }

        private static List<Hero> InitializeHeroList()
        {
            List<Hero> heros = new List<Hero>();

            Hero ana = new Hero();
            ana.Name = HeroName.ANA;
            ana.Description = "Ana is one of the best healers in the game and she has some of the most powerful abilites in the game.";
            ana.Role = roleName.HEALER;
            ana.Counter.Add(HeroName.TRACER);
            ana.Counter.Add(HeroName.DOOMFIST);
            ana.Counter.Add(HeroName.WINSTON);
            heros.Add(ana);
            

            Hero tracer = new Hero();
            tracer.Name = HeroName.TRACER;
            tracer.Description = "Tracer is one of most mobile heroes in the game.";
            tracer.Role = roleName.DAMAGE;
            tracer.Counter.Add(HeroName.BRIGITTE);
            tracer.Counter.Add(HeroName.SOMBRA);
            tracer.Counter.Add(HeroName.MEI);
            heros.Add(tracer);

            Hero doomfist = new Hero();
            doomfist.Name = HeroName.DOOMFIST;
            doomfist.Description = "Doomfist has the highest one hit potential in the game and is also extremely mobile ";
            doomfist.Role = roleName.DAMAGE;
            doomfist.Counter.Add(HeroName.BRIGITTE);
            doomfist.Counter.Add(HeroName.SOMBRA);
            heros.Add(doomfist);

            Hero brigitte = new Hero();
            brigitte.Name = HeroName.BRIGITTE;
            brigitte.Description = "Brigitte is ";
            brigitte.Role = roleName.HEALER;
            Console.WriteLine();
            Console.WriteLine("Countered by:");
            brigitte.Counter.Add(HeroName.BRIGITTE);
            brigitte.Counter.Add(HeroName.SOMBRA);
            heros.Add(brigitte);

            Hero sombra = new Hero();
            sombra.Name = HeroName.SOMBRA;
            sombra.Description = "Sombra is a great anwser to heroes that are ability dependent. ";
            sombra.Role = roleName.DAMAGE;
            sombra.Counter.Add(HeroName.WIDOWMAKER);
            sombra.Counter.Add(HeroName.BRIGITTE);
            heros.Add(sombra);

            Hero widowmaker = new Hero();
            widowmaker.Name = HeroName.WIDOWMAKER;
            widowmaker.Description = "Widowmaker is one of the most leathal heroes in the game she can take out most heroes in one shot. ";
            widowmaker.Role = roleName.DAMAGE;
            widowmaker.Counter.Add(HeroName.WINSTON);
            widowmaker.Counter.Add(HeroName.GENJI);
            heros.Add(widowmaker);

            Hero genji = new Hero();
            genji.Name = HeroName.GENJI;
            genji.Description = "Genji is  incredibly mobile and lethal at any range. He is the only hero who can reflect damage.";
            genji.Role = roleName.DAMAGE;
            genji.Counter.Add(HeroName.WINSTON);
            genji.Counter.Add(HeroName.BRIGITTE);
            genji.Counter.Add(HeroName.SOMBRA);
            heros.Add(genji);

            Hero winston = new Hero();
            winston.Name = HeroName.WINSTON;
            winston.Role = roleName.TANK;
            winston.Description = "Winston is a mobile tank whos main attack goes through barriers";
            winston.Counter.Add(HeroName.REAPER);
            winston.Counter.Add(HeroName.ROADHOG);
            heros.Add(winston);

            Hero ashe = new Hero();
            ashe.Name = HeroName.ASHE;
            ashe.Role = roleName.DAMAGE;
            ashe.Description = "Ashe is a damage dealer some where between Mcree and Widowmaker, her biggest threat comes from here ultimate move B.O.B.";
            ashe.Counter.Add(HeroName.WINSTON);
            ashe.Counter.Add(HeroName.SOMBRA);
            heros.Add(ashe);

            Hero bastion = new Hero();
            bastion.Name = HeroName.BASTION;
            bastion.Role = roleName.DAMAGE;
            bastion.Description = "Bastion is good at one thing and that is dealing damage.";
            bastion.Counter.Add(HeroName.DVA);
            bastion.Counter.Add(HeroName.SOMBRA);
            bastion.Counter.Add(HeroName.GENJI);
            heros.Add(bastion);

            Hero dva = new Hero();
            dva.Name = HeroName.DVA;
            dva.Role = roleName.TANK;
            dva.Description = "DVA is one of the best tanks in the game and has one the strongest abilities in the game. Defense matrix makes all damage that passes through it disappear.";
            dva.Counter.Add(HeroName.SOMBRA);
            dva.Counter.Add(HeroName.ZARYA);
            dva.Counter.Add(HeroName.REAPER);
            heros.Add(dva);

            Hero hanzo = new Hero();
            hanzo.Name = HeroName.HANZO;
            hanzo.Role = roleName.DAMAGE;
            hanzo.Description = "Hanzo brings a bow to gun fights, his ultimate has the ability to wipe an entire team.";
            hanzo.Counter.Add(HeroName.WINSTON);
            hanzo.Counter.Add(HeroName.DVA);
            heros.Add(hanzo);

            Hero junkrat = new Hero();
            junkrat.Name = HeroName.JUNKRAT;
            junkrat.Role = roleName.DAMAGE;
            junkrat.Description = "Junkrat has the highest burst damage potential of any heroes in the game. ";
            junkrat.Counter.Add(HeroName.WINSTON);
            junkrat.Counter.Add(HeroName.SOMBRA);
            junkrat.Counter.Add(HeroName.SOLIDER76);
            heros.Add(junkrat);

            Hero lucio = new Hero();
            lucio.Name = HeroName.LUCIO;
            lucio.Role = roleName.HEALER;
            lucio.Description = "Lucio is one the strongest heroes because of his abilites to increase his team's movement speed and healing over time";
            lucio.Counter.Add(HeroName.WIDOWMAKER);
            lucio.Counter.Add(HeroName.JUNKRAT);
            heros.Add(lucio);

            Hero mccree   = new Hero();
            mccree.Name = HeroName.MCCREE;
            mccree.Role = roleName.DAMAGE;
            mccree.Description = "Mcree provides reliable crowd control and constant damage at all ranges";
            mccree.Counter.Add(HeroName.GENJI);
            mccree.Counter.Add(HeroName.WIDOWMAKER);
            heros.Add(mccree);

            Hero mei = new Hero();
            mei.Name = HeroName.MEI;
            mei.Role = roleName.DAMAGE;
            mei.Description = "Mei brings great self-sustain and crowd control for her team.";
            mei.Counter.Add(HeroName.PHARAH);
            mei.Counter.Add(HeroName.MCCREE);
            mei.Counter.Add(HeroName.ZARYA);
            heros.Add(mei);

            Hero mercy = new Hero();
            mercy.Name = HeroName.MERCY;
            mercy.Role = roleName.HEALER;
            mercy.Description = "Mercy has the best sustained healing in the game and has  the powerful ability to revive her fallen teammates";
            mercy.Counter.Add(HeroName.GENJI);
            mercy.Counter.Add(HeroName.TRACER);
            heros.Add(mercy);

            Hero moira = new Hero();
            moira.Name = HeroName.MOIRA;
            moira.Role = roleName.HEALER;
            moira.Description = "Moira brings healing to her allies and harm to her eneimes.";
            moira.Counter.Add(HeroName.ROADHOG);
            moira.Counter.Add(HeroName.SOLIDER76);
            heros.Add(moira);

            Hero orsia = new Hero();
            orsia.Name = HeroName.ORISA;
            orsia.Role = roleName.TANK;
            orsia.Description = "Orsia is one of two of the anchor tanks in the game. She protects her allies with barriers and her ultimate can increase the damage of all her allies in range.";
            orsia.Counter.Add(HeroName.GENJI);
            orsia.Counter.Add(HeroName.REAPER);
            heros.Add(orsia);

            Hero pharah = new Hero();
            pharah.Name = HeroName.PHARAH;
            pharah.Role = roleName.DAMAGE;
            pharah.Description = "Pharah is the only hero who can stay in the air constantly, from the air she reigns down rockets on her eneimes.";
            pharah.Counter.Add(HeroName.ASHE);
            pharah.Counter.Add(HeroName.WIDOWMAKER);
            heros.Add(pharah);

            Hero reaper = new Hero();
            reaper.Name = HeroName.REAPER;
            reaper.Role = roleName.DAMAGE;
            reaper.Description = "Reaper is the tank buster of Overwatch, he likes to kepp up close and personal. His ultimate has the ability to destroy an entire team";
            reaper.Counter.Add(HeroName.ASHE);
            reaper.Counter.Add(HeroName.WIDOWMAKER);
            heros.Add(reaper);

            Hero reinhardt = new Hero();
            reinhardt.Name = HeroName.REINHARDT;
            reinhardt.Role = roleName.TANK;
            reinhardt.Description = "Reinhardt is the other anchor tank in Overwatch. He carries the biggest barrier in the game, his ultimate can stun an entire team.";
            reinhardt.Counter.Add(HeroName.REAPER);
            reinhardt.Counter.Add(HeroName.SOMBRA);
            heros.Add(reinhardt);

            Hero roadhog = new Hero();
            roadhog.Name = HeroName.ROADHOG;
            roadhog.Role = roleName.TANK;
            roadhog.Description = "Roadhog can bring eneimes in close to kill with his powerful shotgun, he also has the best self healing in the game. ";
            roadhog.Counter.Add(HeroName.REAPER);
            roadhog.Counter.Add(HeroName.TORBJORN);
            heros.Add(roadhog);

            Hero solider76 = new Hero();
            solider76.Name = HeroName.SOLIDER76;
            solider76.Role = roleName.DAMAGE;
            solider76.Description = "Solider 76 provides decent damage for his team and spot healing. His ultimate move is basically an aimbot";
            solider76.Counter.Add(HeroName.WIDOWMAKER);
            solider76.Counter.Add(HeroName.WINSTON);
            heros.Add(solider76);

            Hero symmetra = new Hero();
            symmetra.Name = HeroName.SYMMETRA;
            symmetra.Role = roleName.DAMAGE;
            symmetra.Description = "Symmetra allows for some crazy postioning and tactics for her team because of her ability to teleport allies.";
            symmetra.Counter.Add(HeroName.WIDOWMAKER);
            symmetra.Counter.Add(HeroName.ASHE);
            heros.Add(symmetra);

            Hero torbjorn = new Hero();
            torbjorn.Name = HeroName.TORBJORN;
            torbjorn.Role = roleName.DAMAGE;
            torbjorn.Description = "Torbjorn brings a turret with auto aim and has a powerful zoning ultimate.";
            torbjorn.Counter.Add(HeroName.WIDOWMAKER);
            torbjorn.Counter.Add(HeroName.ZARYA);
            heros.Add(torbjorn);

            Hero hammond = new Hero();
            hammond.Name = HeroName.HAMMOND;
            hammond.Role = roleName.TANK;
            hammond.Description = "Hammond aka Wrecking Ball is the most mobile tank the game and can gain the most health. His ultimate move is droping a minefield around himself that only damages eneimes.";
            hammond.Counter.Add(HeroName.SOMBRA);
            hammond.Counter.Add(HeroName.REAPER);
            heros.Add(hammond);

            Hero zarya = new Hero();
            zarya.Name = HeroName.ZARYA;
            zarya.Role = roleName.TANK;
            zarya.Description = "Zarya has the highest sustain damage of any tank in the game. Her ultimate move Graviton Surge can leave the enemy team immobile setting them up for other ultimate moves.";
            Console.WriteLine();
            Console.WriteLine("Countered by:");
            zarya.Counter.Add(HeroName.SOMBRA);
            zarya.Counter.Add(HeroName.PHARAH);
            heros.Add(zarya);

            Hero zenyatta = new Hero();
            zenyatta.Name = HeroName.ZENYATTA;
            zenyatta.Role = roleName.HEALER;
            zenyatta.Description = "Zenyatta has the highest sustained damage of any healer and can cause his allies to deal more damage to their eneimes. His ultimate can bring life saving healing to his team.";
            zenyatta.Counter.Add(HeroName.TRACER);
            zenyatta.Counter.Add(HeroName.GENJI);
            heros.Add(zenyatta);

            return heros;
        }

        static Hero HeroInfoScreen(Hero userHero)
        {
            DisplayHeader("Hero Information");

            Console.WriteLine(userHero.Name);
            Console.WriteLine(userHero.Role);
            Console.WriteLine(userHero.Description);
            Console.WriteLine();
            Console.WriteLine("Countered by:");
            foreach (HeroName heroName in userHero.Counter)
            {
                Console.WriteLine(heroName);
            }

            DisplayContinuePrompt();
            return userHero;
        }

        static HeroName HeroSelectScreen()
        {
            
            
            HeroName userHero;
            string userResponse;
            string[] HeroList;
            bool validResponse = false;
            string dataPath = @"Heroes\HeroList.txt";

            DisplayHeader("\tHero Selection Screen");

            HeroList = File.ReadAllLines(dataPath);
            foreach (string line in HeroList)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
            do
            {

                
                Console.WriteLine("Please select hero:");
                userResponse = Console.ReadLine().ToUpper();

                if (!Enum.TryParse(userResponse, out userHero))
                {
                    Console.WriteLine("Please choose a hero.");
                    DisplayContinuePrompt();
                }
                else
                {
                    validResponse = true;
                }

            } while (!validResponse);
            Console.WriteLine();
            Console.WriteLine($"You chose {userHero}.");

            DisplayContinuePrompt();

            return userHero;
        }
        static void TitleScreen()
        {
            Console.WriteLine("\t OVERWATCH BUDDY");

            DisplayContinuePrompt();
        }

        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine("\t\tThank You For using My App");
            DisplayContinuePrompt();
        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void DisplayHeader(string headText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(headText);
            Console.WriteLine();
        }


    }
}
