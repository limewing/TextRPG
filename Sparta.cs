using System.Security.Cryptography.X509Certificates;

namespace Sparta
{


    public class Warrior
    {

        public string Name { get; }
        public string Class { get; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int CurrentHealth { get; set; }
        public int MaximumHealth { get; set; }
        public float AttackPower { get; set; }
        public float AttackPowerPlus { get; set; }
        public int Defense { get; set; }
        public int DefensePlus { get; set; }
        public int Gold { get; set; }


        public bool IsDead => CurrentHealth <= 0;

        public int[] Inven = new int[20]; // 인벤토리 배열

        public Warrior(string name)
        {
            Name = name;
            Class = "전사";
            Level = 1; // 초기 레벨
            MaximumHealth = 100; // 초기 최대체력
            CurrentHealth = 100;
            AttackPower = 10.0f;// 초기 공격력
            AttackPowerPlus = 0.0f;
            Defense = 5; // 초기 방어력
            DefensePlus = 0;
            Gold = 1500; // 초기 골드
            Exp = 0; // 초기 경험치
        }

        public void CharacterInfo()
        {
            int Infoinput = 1;

            do
            {
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();
                Console.WriteLine($"LV. {Level}");
                Console.WriteLine($"{Name} ( {Class} )");
                Console.WriteLine($"HP: {CurrentHealth} / {MaximumHealth}");
                Console.WriteLine($"공격력: {AttackPower} (+{AttackPowerPlus})");
                Console.WriteLine($"방어력: {Defense} (+{DefensePlus})");
                Console.WriteLine($"Gold : {Gold} G");
                Console.WriteLine($"경험치: {Exp} / {Level * 100}");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Infoinput = Convert.ToInt32(Console.ReadLine());
                if (Infoinput != 0)
                    Console.WriteLine("잘못된 입력입니다.");

            } while (Infoinput != 0);
        }
        
        public void Inventory()
        {
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();
            for (int i = 0; i < Inven.Length; i++)
            {
                if (Inven[i] != 0)
                {
                    Console.WriteLine($"{i + 1}. 아이템 이름");
                }
            }
            
        }
        public void GetItem(int ItemCode)
        {
            int j = 0;
            while (j < Inven.Length && Inven[j] != 0) ;
                j++;
            if (j >= Inven.Length)
                Console.WriteLine("인벤토리가 가득 차있어 아이템을 더 이상 획득할 수 없습니다.");
            else
                Inven[j] = ItemCode;
        }
        public void LevelUp()
        { 
            if (Exp >= Level * 100)
            {
                Exp -= Level * 100;
                Level++;
                CurrentHealth = MaximumHealth;
                AttackPower += 0.5f;
                Defense += 1;
                Console.WriteLine("레벨업을 하였습니다.");
            }
        }

    }

    public class Item
    {

        public int ItemCode { get; set; }
        public int AddattackPower { get; set; }
        public int AddDefense { get; set; }
        public int ItemPrice { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string ItemText { get; set; }

        public Item(int itemCode, int addattackPower, int addDefense, int itemPrice, string itemName, string itemType, string itemText)
        {
            ItemCode = itemCode;
            AddattackPower = addattackPower;
            AddDefense = addDefense;
            ItemPrice = itemPrice;
            ItemName = itemName;
            ItemType = itemType;
            ItemText = itemText;
        }

        public void EquipItem()
        {
            Console.WriteLine("아이템을 장착하였습니다.");
        }
        public void SellItem()
        {
            Console.WriteLine("아이템을 판매하였습니다.");
        }
        public void ItemInfo(int itemCode)
        { 
            
        }
    }

    public class NoviceArmor : Item
    {
        public NoviceArmor() : base(1, 0, 5, 1000, "수련자 갑옷", "방어구", "수련에 도움을 주는 갑옷입니다.");
    }

    public class IronArmor : Item
    {
        public IronArmor() : base(2, 0, 9, 2000, "무쇠 갑옷", "방어구", "무쇠로 만들어져 튼튼한 갑옷입니다.");
    }

    public class SpartanArmor : Item
    {
        public SpartanArmor() : base(3, 0, 15, 3500, "스파르타의 갑옷", "방어구", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.");
    }

    public class OldSword : Item
    {
        public OldSword() : base(4, 2, 0, 600, "낡은 검", "무기", "쉽게 볼 수 있는 낡은 검입니다.");
    }

    public class IronSword : Item
    {
        public IronSword() : base(5, 5, 0, 1500, "무쇠 검", "무기", "무쇠로 만들어져 튼튼한 검입니다.");
    }

    public class SpartanSpear : Item
    {
        public SpartanSpear() : base(6, 7, 0, 2500, "스파르타의 창", "무기", "스파르타의 전사들이 사용했다는 전설의 창입니다.");
    }


    // 각종 메뉴들 관리 클래스
    public class Menu
    {
        
        public void Shop()
        {
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{/*캐릭터 보유 골드*/}G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            for (int i = 1; i < 7; i++)
                Item.ItemInfo(i);
            Console.WriteLine("");
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            int Shopinput = Convert.ToInt32(Console.ReadLine());
        }
    }


    public class Stage      //다른 클래스간의 정보 상호작용
    {
        private Warrior player;
        private List<Item> items;

        public delegate void ItemDelegate(Item item);
        public Stage(Warrior player, List<Item> items)
        { 
            this.player = player;
            this.items = items;
        }

        public void DungeonStage()
        { 
        
        }

        public 
    }
     class Process
     {
        public static void Main(string[] args)
        {
            Item item = new Item();
            Menu menu = new Menu();
            string nameinput;
            

            while (true)
            {
                Console.WriteLine("이름을 입력하세요.");
                nameinput = Console.ReadLine();
                Console.WriteLine("당신의 이름은 " + nameinput + "이 확실합니까?");
                Console.WriteLine("1. 네 ");
                Console.WriteLine("2. 아니오");
                string Nameconfig = Console.ReadLine();
                if (Nameconfig == "1")
                {
                    Console.WriteLine("당신의 이름은 " + nameinput + "입니다.");
                    break;
                }
                else if (Nameconfig == "2")
                {
                    Console.WriteLine("다시 입력해주세요.");
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
            //위의 while문을 통해 입력받고 확인받은 nameinput을 캐릭터 생성자에 넣어줘야 함
            Warrior player = new Warrior(nameinput);

            while (true)
            {
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("1. 던전으로 들어가기");
                Console.WriteLine("2. 상태 보기");
                Console.WriteLine("3. 인벤토리");
                Console.WriteLine("4. 상점");
                Console.WriteLine("5. 휴식하기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                int menuselect = Convert.ToInt32(Console.ReadLine());
                if (menuselect == 1)
                {
                    Console.WriteLine("던전으로 이동합니다.");
                    break;
                }
                else if (menuselect == 2)
                {
                    player.CharacterInfo();
                }
                else if (menuselect == 3)
                {
                    player.Inventory();
                }
                else if (menuselect == 4)
                {
                    menu.Shop();
                }
                else if (menuselect == 5)
                {
                    Console.WriteLine("휴식을 취합니다.");
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
     }
}