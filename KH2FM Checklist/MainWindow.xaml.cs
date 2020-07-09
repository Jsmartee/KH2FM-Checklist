using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KH2FM_Checklist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Item> items = new List<Item>();
        public List<World> worlds = new List<World>();

        public MainWindow()
        {
            InitializeComponent();
            SetGrids();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            About help = new About();
            help.Show();
        }

        public void SetGrids()
        {
            Style stillImg = this.FindResource("StaticImage") as Style;
            Style checkImg = this.FindResource("CheckImage") as Style;
            Style countImg = this.FindResource("CounterImage") as Style;
            Style intCount = this.FindResource("IntCounter") as Style;
            Style keyImg = this.FindResource("KeyImage") as Style;
            Style symImg = this.FindResource("SymbolImage") as Style;

            //Item Tracker
            List<Item> itemslist = new List<Item>
            {
                //Item Name, Item Type, Image, Image Style, Initial Count, Max
                new Item("Keyblades", "item", "kingdomkey_1.png", countImg, 1, 24),
                new Item("Proof of Peace", "item", "ProofPeace_0.png", checkImg),
                new Item("Proof of Nonexistence", "item", "ProofNonexistence_0.png", checkImg),
                new Item("Proof of Connection", "item", "ProofConnection_0.png", checkImg),
                new Item("Promise Charm", "item", "Charm_0.png", checkImg),
                new Item("Torn Pages", "item", "pages_0.png", countImg, 0, 5),

                new Item("Simulated Twilight Town", "world", "Roxas_0.png", checkImg),
                new Item("Twilight Town", "world", "Twilight Town.png", countImg, 0, 3),
                new Item("Hollow Bastion", "world", "Hollow Bastion.png", countImg, 0, 3),
                new Item("Disney Castle", "world", "Disney Castle.png", stillImg),
                new Item("Timeless River", "world", "Timeless River.png", stillImg),
                new Item("Atlantica", "world", "Atlantica.png", countImg, 0, 5),
                new Item("100 Acre Wood", "world", "100 Acre Wood.png", countImg, 0, 5),
                new Item("The World That Never Was", "world", "The World That Never Was.png", stillImg),

                new Item("Land of Dragons", "world", "The Land of Dragons.png", stillImg),
                new Item("Beast's Castle", "world", "Beast's Castle.png", stillImg),
                new Item("Olympus Coliseum", "world", "Olympus Coliseum.png", stillImg),
                new Item("Port Royal", "world", "Port Royal.png", stillImg),
                new Item("Agrabah", "world", "Agrabah.png", stillImg),
                new Item("Halloween Town", "world", "Halloween Town.png", stillImg),
                new Item("Pride Lands", "world", "Pride Lands.png", stillImg),
                new Item("Space Paranoids", "world", "Space Paranoids.png", stillImg),

                new Item("Valor Form", "form", "formvalor_0.png", countImg, 0, 7),
                new Item("Wisdom Form", "form", "formwisdom_0.png", countImg, 0, 7),
                new Item("Limit Form", "form", "formlimit_0.png", countImg, 0, 7),
                new Item("Master Form", "form", "formmaster_0.png", countImg, 0, 7),
                new Item("Final Form", "form", "formfinal_0.png", countImg, 0, 7),
                new Item("Cavern of Remembrance", "world", "cor_0.png", checkImg),
                new Item("Baseball Charm", "summon", "charmbaseball_0.png", checkImg),
                new Item("Lamp Charm", "summon", "charmlamp_0.png", checkImg),

                new Item("Fire", "magic", "magicfire_0.png", countImg, 0, 3),
                new Item("Blizzard", "magic", "magicblizzard_0.png", countImg, 0, 3),
                new Item("Thunder", "magic", "magicthunder_0.png", countImg, 0, 3),
                new Item("Cure", "magic", "magiccure_0.png", countImg, 0, 3),
                new Item("Reflect", "magic", "magicreflect_0.png", countImg, 0, 3),
                new Item("Magnet", "magic", "magicmagnet_0.png", countImg, 0, 3),
                new Item("Ukulele Charm", "summon", "charmukulele_0.png", checkImg),
                new Item("Feather Charm", "summon", "charmfeather_0.png", checkImg)

            };

            items = itemslist;

            //Item tracker first row
            for(int i = 0; i < 6; i++)
            {
                Image currentImage = items.ElementAt(i).ItemImage;
                Grid.SetRow(currentImage, 0);
                Grid.SetColumn(currentImage, i + 1);
                ItemTracker.Children.Add(currentImage);

                currentImage.ToolTip = items.ElementAt(i).ItemName;
                currentImage.Tag = items.ElementAt(i).ItemName;

                TextBlock text = new TextBlock
                {
                    Style = intCount,
                    Text = items.ElementAt(i).ItemCurrentString
                };
                items.ElementAt(i).ItemText = text;
                Grid.SetRow(items.ElementAt(i).ItemText, 0);
                Grid.SetColumn(items.ElementAt(i).ItemText, i + 1);
                ItemTracker.Children.Add(items.ElementAt(i).ItemText);
            }

            //Put rest of items on grid
            for (int a = 1; a < 5; a++)
            {
                for (int b = 0; b < 8; b++)
                {
                    Image currentImage = items.ElementAt(b + 8 * a - 2).ItemImage;
                    Grid.SetRow(currentImage, a);
                    Grid.SetColumn(currentImage, b);
                    ItemTracker.Children.Add(currentImage);

                    currentImage.ToolTip = items.ElementAt(b + 8 * a - 2).ItemName;
                    currentImage.Tag = items.ElementAt(b + 8 * a - 2).ItemName;

                    TextBlock text = new TextBlock
                    {
                        Style = intCount,
                        Text = items.ElementAt(b + 8 * a - 2).ItemCurrentString
                    };
                    items.ElementAt(b + 8 * a - 2).ItemText = text;
                    Grid.SetRow(items.ElementAt(b + 8 * a - 2).ItemText, a);
                    Grid.SetColumn(items.ElementAt(b + 8 * a - 2).ItemText, b);
                    ItemTracker.Children.Add(items.ElementAt(b + 8 * a - 2).ItemText);
                }
            }

            //Add keyholes to worlds on 2nd row
            for(int i = 0; i < 3; i++)
            {
                Item keyhole = new Item("Keyhole", "symbol", "keyhole_0.png", keyImg);
                Grid.SetRow(keyhole.ItemImage, 1);
                switch(i)
                {
                    case 0:
                        Grid.SetColumn(keyhole.ItemImage, 3);
                        break;

                    case 1:
                        Grid.SetColumn(keyhole.ItemImage, 4);
                        break;

                    case 2:
                        Grid.SetColumn(keyhole.ItemImage, 7);
                        break;
                }
                ItemTracker.Children.Add(keyhole.ItemImage);
            }

            //Keyholes for 2 Visit Worlds
            for(int i = 0; i < 8; i++)
            {
                Item keyhole1 = new Item("Keyhole", "symbol", "keyhole_0.png", keyImg);
                Grid.SetRow(keyhole1.ItemImage, 2);
                Grid.SetColumn(keyhole1.ItemImage, i);
                keyhole1.ItemImage.Margin = new Thickness(0, 0, 17, 0);
                ItemTracker.Children.Add(keyhole1.ItemImage);

                Item keyhole2 = new Item("Keyhole", "symbol", "keyhole_0.png", keyImg);
                Grid.SetRow(keyhole2.ItemImage, 2);
                Grid.SetColumn(keyhole2.ItemImage, i);
                keyhole2.ItemImage.Margin = new Thickness(17, 0, 0, 0);
                ItemTracker.Children.Add(keyhole2.ItemImage);
            }

            //Checklist

            List<string> STT = new List<string>
            {
                "Map popup",
                "Munny Pouch popup",
                "Awakening dusks bonus",
                "Awakening tutorial chest",
                "Awakening 2nd chest",
                "Twilight Thorn bonus",
                "Axel 1 bonus",
                "Struggle Trophy popup",
                "Station corner near entrance",
                "Station far corner",
                "Station between tracks",
                "Sunset lower level",
                "Sunset rooftop",
                "Sunset near bridge",
                "Sunset before hill",
                "Mansion center",
                "Mansion left stairs",
                "Mansion upper walkway",
                "Mansion dining near door",
                "Mansion dining corner",
                "Namine's Room popups",
                "Mansion Library chest",
                "Axel 2 bonus",
                "Mansion Basement last chest",
                "Data Roxas"
            };

            List<string> TT = new List<string>
            {
                "Mansion gate corner",
                "Mansion gate near door",
                "Tram Common near tunnel",
                "Tram Common broom",
                "Tram Common near woods",
                "Tram Common near bees",
                "Tram Common rooftop",
                "Tram Common back rooftop",
                "Tram Common rooftop near woods",
                "Woods near Vivi",
                "Woods near mansion",
                "Woods other chest",
                "Station Fight popups",
                "Station left front",
                "Station left back",
                "Station right corner",
                "Tower Outside right",
                "Tower Outside left chest",
                "Tower Outside left corner",
                "Tower Entry ether chest",
                "Tower Entry under stairs",
                "Yen Sid big chest",
                "Tower popups",
                "Tower small chest",
                "Sandlot Fight popup",
                "2nd Visit popups",
                "Underground near 4",
                "Underground middle gamblers",
                "Underground between 2 and 3",
                "Underground lower middle",
                "Tunnelway open area",
                "Tunnelway near exit",
                "Sunset near tram track",
                "Sunset below rooftop chest",
                "Sunset rooftop",
                "Sunset end of alley",
                "Mansion middle",
                "Mansion right stairs",
                "Mansion upper walkway",
                "Mansion Dining right corner",
                "Mansion Dining back",
                "Mansion Library chest",
                "Mansion Corridor chest",
                "Beam popup",
                "Axel Fight bonus",
                "Axel Fight popup",
                "Data Axel"
            };

            List<string> HB = new List<string>
            {
                "Marketplace Map popup",
                "Borough top ledge",
                "Borough drive recovery chest",
                "Borough near bailey",
                "Borough ground",
                "Borough merlin's house",
                "Merlin's House popups",
                "Bailey bonus",
                "Bailey popup",
                "Chicken Little popup",
                "Postern on yellow pipe",
                "Postern big chest",
                "Postern lower level",
                "Corridors 1st left path",
                "Corridors 2nd left path",
                "Corridors near middle",
                "Corridors right path",
                "Ansem's Study chest",
                "DTD popups",
                "Stitch big chest",
                "Demyx bonus",
                "FF Fights popup",
                "Before 1K front big chest",
                "Before 1K back big chest",
                "Before 1K near save",
                "Before 1K small chest",
                "1K bonus",
                "1K popups",
                "Gull Wing",
                "Heartless Manufactory",
                "Near GoA entrance 1",
                "Near GoA entrance 2",
                "Mushroom XIII",
                "Sephiroth",
                "Data Demyx"
            };

            List<string> DC = new List<string>
            {
                "Courtyard flute cow",
                "Courtyard corner",
                "Courtyard middle ground",
                "Courtyard middle top",
                "Courtyard trombone dog",
                "Courtyard trumpet pig",
                "Courtyard near door",
                "Library big chest",
                "Library popup",
                "Minnie Escort bonus",
                "Hill big chest",
                "Hill small chest",
                "Pier under tree",
                "Pier near waterway",
                "Waterway right chest",
                "Waterway middle chest",
                "Waterway end chest",
                "Windows popup",
                "Steamboat bonus",
                "Pete bonus",
                "Final TR popups",
                "Marluxia",
                "Terra",
            };

            List<string> LoD = new List<string>
            {
                "Bamboo ether chest",
                "Bamboo back chest",
                "Bamboo near rock",
                "Map popup",
                "3rd Mission popup",
                "Checkpoint near gate",
                "Checkpoint near mountain",
                "Mountain lowest chest",
                "Mountain highest chest",
                "Mountain ledge left",
                "Mountain ledge right",
                "Village Map popup",
                "Cave 1st chest",
                "Cave 2nd chest",
                "Cave Fight bonus",
                "Ridge right chest",
                "Ridge back chest",
                "Shan Yu bonus",
                "Hidden Dragon popup",
                "Throne Room left big chest",
                "Throne Room right big chest",
                "Throne Room left small chest",
                "Throne Room right small chest",
                "Throne Room ledge left",
                "Throne Room ledge middle left",
                "Throne Room ledge middle right",
                "Throne Room ledge right",
                "Storm Rider bonus",
                "Data Xigbar"
            };

            List<string> BC = new List<string>
            {
                "Courtyard left",
                "Courtyard near bridge",
                "Courtyard right",
                "Belle big chest",
                "Belle small chest",
                "East Wing hallway",
                "East Wing near stairs",
                "West Hall armor",
                "West Hall right stairs",
                "West Hall left stairs",
                "West Hall near wardrobe",
                "Thresholder bonus",
                "Dungeon big chest",
                "Dungeon small chest",
                "Cogsworth upper left",
                "Cogsworth upper right",
                "Cogsworth before exit",
                "West Hall top of stairs",
                "West Wing 1st chest",
                "West Wing upstairs",
                "Beast bonus",
                "Beast popup",
                "Beast chest",
                "Dark Thorn bonus",
                "Cure popup",
                "Rumbling Rose popup",
                "Xaldin bonus",
                "Report 4 popup",
                "Data Xaldin"
            };

            List<string> OC = new List<string>
            {
                "Passage under torch",
                "Passage outside path",
                "Passage outside path stairs",
                "Passage main path",
                "Passage near inner chamber",
                "Inner Chamber big chest",
                "Inner Chamber small chest",
                "Cerberus bonus",
                "Coliseum Map popup",
                "Urns bonus",
                "Underworld power boost chest",
                "Caverns Entrance first chest",
                "Caverns Entrance upper left",
                "Caverns Entrance upper right",
                "Lost Road ether chest",
                "Lost Road near caverns entrance",
                "Lost Road next to platform",
                "Lost Road path to Atrium",
                "Atrium lower level",
                "Atrium lone ledge",
                "Demyx popups",
                "The Lock big chest",
                "The Lock small right",
                "The Lock small left",
                "Pete bonus",
                "Hydra bonus",
                "Hero's Crest popup",
                "Auron's Statue popup",
                "Hades bonus",
                "Guardian Soul popup",
                "Pain & Panic Cup",
                "Cerberus Cup",
                "Titan Cup",
                "Goddess of Fate Cup",
                "Zexion"
            };

            List<string> PR = new List<string>
            {
                "Rampart big chest",
                "Rampart cannon chest",
                "Rampart near puzzle",
                "Town in boxes 1",
                "Town next to boxes 1",
                "Town in boxes 2",
                "Town next to boxes 2",
                "Cave Mouth chest in shadows",
                "Cave Mouth chest in light",
                "Timed Pirates popup",
                "Boat Fight bonus",
                "Powder Store left boxes",
                "Powder Store right boxes",
                "Moonlight Nook left",
                "Moonlight Nook front right,",
                "Moonlight Nook back right,",
                "Barbossa bonus",
                "Follow the Wind popup",
                "Grim Reaper 1 bonus",
                "Peter Pan chest",
                "Seadrift Row 1st chest",
                "Seadrift Row broken ship",
                "Seadrift Row near keep entrance",
                "Seadrift Keep under ship",
                "Seadrift Keep on ship",
                "Seadrift Keep corner",
                "Medallion popups",
                "Grim Reaper 2 bonus",
                "Report 6 popup",
                "Data Luxord"
            };

            List<string> AG = new List<string>
            {
                "Map popup",
                "Near stairs",
                "2nd chest upper level",
                "Above Market triangle bottom right",
                "Above Market triangle bottom left",
                "Above Market triangle center",
                "Back corner",
                "Ledge across from corner",
                "Bazaar on ledge",
                "Bazaar near middle",
                "Bazaar near wall stalls",
                "Bazaar hidden in stalls",
                "Bazaar near exit",
                "Palace Walls big chest",
                "Palace Walls small",
                "Cave Entrance left",
                "Cave Entrance right",
                "Cave first middle",
                "Cave left",
                "Cave right",
                "Cave last left",
                "Abu Escort bonus",
                "Chasm big chest",
                "Chasm small chest",
                "Treasure Room bonus",
                "Twin Lords bonus",
                "Lamp Charm popup",
                "Treasure Room right",
                "Treasure Room left",
                "Ruined Chamber left",
                "Ruined Chamber right",
                "Genie Jafar bonus",
                "Wishing Lamp popup",
                "Lexaeus"
            };

            List<string> HT = new List<string>
            {
                "Graveyard near gate",
                "Graveyard near graves",
                "Lab big chest",
                "Town Square near guillotine",
                "Town Square near gate",
                "Hinterlands front right",
                "Hinterlands back right",
                "Hinterlands left",
                "Cane Lane left ledge",
                "Cane Lane right ledge",
                "Cane Lane near gate",
                "Cane Lane front of house",
                "Santa big chest",
                "Santa small chest",
                "Prison Keeper bonus",
                "Oogie bonus",
                "Magnet popup",
                "Present popup",
                "Decoy Presents popup",
                "Experiment bonus",
                "Decisive Pumpkin popup",
                "Vexen"
            };

            List<string> PL = new List<string>
            {
                "Gorge big chest",
                "Gorge small right",
                "Gorge small left",
                "Graveyard under mammoth tusks",
                "Graveyard leftmost chest",
                "Graveyard middle lower",
                "Graveyard middle upper",
                "Graveyard near savannah",
                "Pride Rock big chest",
                "Pride Rock near wall",
                "Pride Rock under rock",
                "Valley center big rock",
                "Valley center smaller rock",
                "Valley right wall",
                "Valley right wall near tree",
                "Valley under tree",
                "Wastelands 1st chest",
                "Wastelands 2nd chest",
                "Wastelands 3rd chest",
                "Jungle under tree",
                "Jungle ant hills",
                "Jungle enemy spawn",
                "Simba popup",
                "Oasis near cliff",
                "Oasis torn page chest",
                "Oasis waterfall chest",
                "Scar bonus",
                "Fire popup",
                "Groundshaker bonus",
                "Data Saix"
            };

            List<string> SP = new List<string>
            {
                "Pit Cell big chest",
                "Pit Cell small chest",
                "Canyon 1st chest",
                "Canyon corner chest",
                "Canyon before screens",
                "Canyon above cube game",
                "Hallway left chest",
                "Hallway right chest",
                "Before Hostile left big chest",
                "Before Hostile right big chest",
                "Hostile Program bonus",
                "Photon Debugger popup",
                "Solar Sailer Heartless bonus",
                "Computer Core left big chest",
                "Computer Core right big chest",
                "Computer Core left small chest",
                "Computer Core right small chest",
                "MCP"
            };

            List<string> CoR = new List<string>
            {
                "Depths 1st chest",
                "Depths ground close",
                "Depths ground far",
                "Depths ledge near door",
                "Depths highest",
                "Mineshaft Lower big chest",
                "Mineshaft Lower small chest",
                "Depths Upper Level",
                "Near Valves chest",
                "Mining Area lowest chest",
                "Mining Area mid height chest",
                "Mining Area near door",
                "Mining Area ledge big chest",
                "Mining Area ledge small chest",
                "Mineshaft big chest",
                "Engine Chamber 1st chest",
                "Engine Chamber 2nd chest",
                "Engine Chamber high ledge",
                "Engine Chamber middle high ledge",
                "Before Glide big chest",
                "Last chest"
            };

            List<string> TWTNW = new List<string>
            {
                "Before Roxas 1",
                "Before Roxas 2",
                "Before Roxas 3",
                "Before Roxas 4",
                "Roxas bonus",
                "Roxas popups",
                "Skyscraper truck",
                "Skyscraper left",
                "Skyscraper near castle",
                "Before Castle big chest",
                "Before Castle small chest",
                "Nothing's Call 1",
                "Nothing's Call 2",
                "Twilight's View big chest",
                "Xigbar popup",
                "Skyway first chest",
                "Skyway on ledge",
                "Skyway corner of path",
                "Oblivion popups",
                "Luxord bonus",
                "Luxord popup",
                "Saix popup",
                "Riku popup",
                "Before Xemnas 1st platform",
                "Before Xemnas 2nd platform",
                "Before Xemnas 3rd platform",
                "Before Xemnas 4th platform",
                "Xemnas popup",
                "Data Xemnas"
            };

            List<string> AW = new List<string>
            {
                "Pooh big chest",
                "Pooh right chest",
                "Pooh left chest",
                "Piglet big chest",
                "Piglet under tree",
                "Piglet near stump",
                "Rabbit big chest",
                "Rabbit clothesline",
                "Rabbit garden",
                "Kanga big chest",
                "Kanga right",
                "Kanga left",
                "Cave 1st chest",
                "Cave right path chest",
                "Cave middle path front chest",
                "Cave middle path back chest",
                "Cave left path chest",
                "Cave near pooh chest",
                "Spooky Cave reward",
                "Starry Hill big chest",
                "Starry Hill small chest",
                "Final popups"
            };

            List<string> AT = new List<string>
            {
                "Tutorial popup",
                "Ursula popup",
                "Final popups",
                "Larxene"
            };

            List<World> worldList = new List<World>
            {
                //World Name, List
                new World("Simulated Twilight Town", STT),
                new World("Twilight Town", TT),
                new World("Hollow Bastion", HB),
                new World("Disney Castle/Timeless River", DC),
                new World("Land of Dragons", LoD),
                new World("Beast's Castle", BC),
                new World("Olympus Coliseum", OC),
                new World("Port Royal", PR),
                new World("Agrabah", AG),
                new World("Halloween Town", HT),
                new World("Pride Lands", PL),
                new World("Space Paranoids", SP),
                new World("Cavern of Remembrance", CoR),
                new World("The World That Never Was", TWTNW),
                new World("100 Acre Wood", AW),
                new World("Atlantica", AT)
            };

            worlds = worldList;

            //Add lists to window
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    //Create grid for world
                    Grid grid = new Grid
                    {
                        Margin = new Thickness(10)
                    };
                    RowDefinition firstRow = new RowDefinition
                    {
                        Height = new GridLength(30)
                    };
                    grid.RowDefinitions.Add(firstRow);
                    grid.RowDefinitions.Add(new RowDefinition());
                    ColumnDefinition firstCol = new ColumnDefinition
                    {
                        Width = new GridLength(20)
                    };
                    grid.ColumnDefinitions.Add(firstCol);
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    Grid.SetRow(grid, i);
                    Grid.SetColumn(grid, j);
                    Checklist.Children.Add(grid);

                    //Mickey symbols
                    StackPanel mickeys = new StackPanel();
                    Grid.SetRow(mickeys, 1);
                    Grid.SetColumn(mickeys, 0);
                    grid.Children.Add(mickeys);

                    for(int a = 0; a < worlds.ElementAt(j + 4 * i).TotalChecks; a++)
                    {
                        mickeys.Children.Add(new Item("Mickey", "symbol", "symbol_0.png", symImg).ItemImage);
                    }

                    //World Name
                    TextBlock name = new TextBlock
                    {
                        Text = worlds.ElementAt(j + 4 * i).WorldName,
                        FontSize = 15,
                        FontWeight = FontWeights.Bold,
                        TextAlignment = TextAlignment.Center,
                        TextWrapping = TextWrapping.Wrap
                    };
                    Grid.SetRow(name, 0);
                    Grid.SetColumn(name, 0);
                    Grid.SetColumnSpan(name, 3);
                    grid.Children.Add(name);

                    //Checklist
                    StackPanel checks = new StackPanel();
                    Grid.SetRow(checks, 1);
                    Grid.SetColumn(checks, 1);
                    Grid.SetColumnSpan(checks, 2);
                    grid.Children.Add(checks);

                    for(int x = 0; x < worlds.ElementAt(j + 4 * i).TotalChecks; x++)
                    {
                        CheckBox check = new CheckBox
                        {
                            HorizontalAlignment = HorizontalAlignment.Left,
                            Content = worlds.ElementAt(j + 4 * i).Checklist.ElementAt(x)
                        };
                        checks.Children.Add(check);
                    }

                }
            }

        }

    }
}
