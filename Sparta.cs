using System.ComponentModel;
using System.Numerics;
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

        public string[] Inven = new string[20] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" , "0", "0", "0", "0"}; // 인벤토리 배열

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

        public void CharacterInfo()     //상태보기
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
        
        public void Inventory()     //인벤토리
        {
            while (true) {
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine();
                for (int i = 0; i < Inven.Length; i++)
                {
                    if (Inven[i] != "0")
                    {
                        Console.WriteLine($"{Inven[i]}");
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("2. 나가기");
                Console.WriteLine("");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                string inveninput = Console.ReadLine();
                if (inveninput == "1")
                {
                    Console.WriteLine("인벤토리 - 장착 관리");
                    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                    Console.WriteLine();
                    Console.WriteLine("[아이템 목록]");
                    Console.WriteLine();
                    for (int k = 0; k < Inven.Length; k++)
                    {
                        if (Inven[k] != "0")
                        {
                            Console.WriteLine($"{k + 1}. {Inven[k]}");
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine("");
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    string inveninput2 = Console.ReadLine();
                    if (inveninput2 != "0")
                }
                else if (inveninput == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
        public void GetItem(string Name)    //인벤토리가 가득차지 않았다면 아이템창에 아이템 추가
        {
            int j = 0;
            while (j < Inven.Length && Inven[j] != "0") ;
                j++;
            if (j >= Inven.Length)
                Console.WriteLine("인벤토리가 가득 차있어 아이템을 더 이상 획득할 수 없습니다.");
            else
                Inven[j] = Name;
        }
        public void LevelUp()       //던전 클리어시 100경험치, 레벨*100 경험치를 모으면 레벨업
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

        string Name { get; }
        public void EquipItem(Warrior warrior)
        public void SellItem()
        {
            Console.WriteLine("아이템을 판매하였습니다.");
        }
        public void ItemInfo(int itemCode)
        {
            if (itemCode > 100)
            {
                Console.Write("[E]");
                if (itemCode == 101)
                    Console.WriteLine("");
            }
        }
    }

    public class NoviceArmor : Item
    {
        public string Name => "수련자 갑옷";
        public void EquipItem(Warrior warrior)
        {
            Console.WriteLine("아이템을 장착하였습니다.");
            warrior.DefensePlus += 5;
        }

    }

    public class IronArmor : Item
    {
        public string Name => "무쇠갑옷";
        public void EquipItem(Warrior warrior)
        {
            Console.WriteLine("아이템을 장착하였습니다.");
            warrior.DefensePlus += 9;
        }

    }

    public class SpartanArmor : Item
    {
        public string Name => "스파르타의 갑옷";
        public void EquipItem(Warrior warrior)
        {
            Console.WriteLine("아이템을 장착하였습니다.");
            warrior.DefensePlus += 15;
        }

    }

    public class OldSword : Item
    {
        public string Name => "스파르타의 갑옷";
        public void EquipItem(Warrior warrior)
        {
            Console.WriteLine("아이템을 장착하였습니다.");
            warrior.AttackPowerPlus+= 2;
        }

    }

    public class BronzeAxe : Item
    {
        public string Name => "청동 도끼";
        public void EquipItem(Warrior warrior)
        {
            Console.WriteLine("아이템을 장착하였습니다.");
            warrior.AttackPowerPlus+= 5;
        }

    }

    public class SpartanSpear : Item
    {
        public string Name => "스파르타의 창";
        public void EquipItem(Warrior warrior)
        {
            Console.WriteLine("아이템을 장착하였습니다.");
            warrior.AttackPowerPlus += 7;
        }

    }


    // 각종 메뉴들 관리 클래스



    public class Stage      //다른 클래스간의 정보 상호작용
    {
        private Warrior player;
        private List<Item> item;

        public delegate void ItemDelegate(Item item);
        public Stage(Warrior player, List<Item> items)
        { 
            this.player = player;
            this.item = items;
        }

        public void DungeonStage()
        { 
        
        }

        int Shopinput;
        string[] Price = new string[6] { "1000 G", "2000 G", "3500 G", "600 G", "1500 G", "2500 G" };
        public void Shop()
        {
            
            while (true)
            {
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine("");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.Gold}G");
                Console.WriteLine("");
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine($"- 수련자 갑옷    | 방어력 +5  | 수련에 도움을 주는 갑옷입니다.             |  {Price[0]}");
                Console.WriteLine($"- 무쇠갑옷      | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다.           |  {Price[1]}");
                Console.WriteLine($"- 스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.|  {Price[2]}");
                Console.WriteLine($"- 낡은 검      | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다.            |  {Price[3]}");
                Console.WriteLine($"- 청동 도끼     | 공격력 +5  |  어디선가 사용됐던거 같은 도끼입니다.        |  {Price[4]}");
                Console.WriteLine($"- 스파르타의 창  | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다. |  {Price[5]}");
                Console.WriteLine("");
                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Shopinput = Convert.ToInt32(Console.ReadLine());
                if (Shopinput == 1)
                {
                    Console.WriteLine("상점 - 아이템 구매");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                    Console.WriteLine("");
                    Console.WriteLine("[보유 골드]");
                    Console.WriteLine($"{player.Gold}G");
                    Console.WriteLine("");
                    Console.WriteLine("[아이템 목록]");
                    Console.WriteLine($"- 1 수련자 갑옷    | 방어력 +5  | 수련에 도움을 주는 갑옷입니다.             |  {Price[0]}");
                    Console.WriteLine($"- 2 무쇠갑옷      | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다.           |  {Price[2]}");
                    Console.WriteLine($"- 3 스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.|  {Price[3]}");
                    Console.WriteLine($"- 4 낡은 검      | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다.            |  {Price[4]}");
                    Console.WriteLine($"- 5 청동 도끼     | 공격력 +5  |  어디선가 사용됐던거 같은 도끼입니다.        |  {Price[5]}");
                    Console.WriteLine($"- 6 스파르타의 창  | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다. |  {Price[6]}");
                    Console.WriteLine("");
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine("");
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    int Shopinput2 = Convert.ToInt32(Console.ReadLine());
                    if (Shopinput2 == 1 && Price[0] != "구매완료")
                    {
                        if (player.Gold >= 1000)
                        {
                            Price[0] = "구매완료";
                            player.Gold -= 1000;
                            player.GetItem("- 수련자 갑옷    | 방어력 +5  | 수련에 도움을 주는 갑옷입니다.");
                        }
                        else
                            Console.WriteLine("골드가 부족합니다");
                    }
                    else if (Shopinput2 == 2 && Price[1] != "구매완료")
                    {
                        if (player.Gold >= 2000)
                        {
                            Price[1] = "구매완료";
                            player.Gold -= 2000;
                            player.GetItem("- 무쇠갑옷      | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다.");
                        }
                        else
                            Console.WriteLine("골드가 부족합니다");
                    }
                    else if (Shopinput2 == 3 && Price[2] != "구매완료")
                    {
                        if (player.Gold >= 3500)
                        {
                            Price[2] = "구매완료";
                            player.Gold -= 3500;
                            player.GetItem("- 스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.");
                        }
                        else
                            Console.WriteLine("골드가 부족합니다");
                    }
                    else if (Shopinput2 == 4 && Price[3] != "구매완료")
                    {
                        if (player.Gold >= 600)
                        {
                            Price[3] = "구매완료";
                            player.Gold -= 600;
                            player.GetItem("- 낡은 검      | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다.");
                        }
                        else
                            Console.WriteLine("골드가 부족합니다");
                    }
                    else if (Shopinput2 == 5 && Price[4] != "구매완료")
                    {
                        if (player.Gold >= 1500)
                        {
                            Price[4] = "구매완료";
                            player.Gold -= 1500;
                            player.GetItem("- 청동 도끼     | 공격력 +5  |  어디선가 사용됐던거 같은 도끼입니다.");
                        }
                        else
                            Console.WriteLine("골드가 부족합니다");
                    }
                    else if (Shopinput2 == 6 && Price[5] != "구매완료")
                    {
                        if (player.Gold >= 2500)
                        {
                            Price[5] = "구매완료";
                            player.Gold -= 2500;
                            player.GetItem("- 스파르타의 창  | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다.");
                        }
                        else
                            Console.WriteLine("골드가 부족합니다");
                    }
                    else if (Price[Shopinput2 - 1] == "구매완료")
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.");
                    }
                    else
                        Console.WriteLine("잘못된 입력입니다");
                }
                else
                    Console.WriteLine("잘못된 입력입니다");
            }
        }
    }
     class Process
     {
        public static void Main(string[] args)
        {
            
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
            List < Item > = new List<Item> { new NoviceArmor(), new IronArmor(), new SpartanArmor(), new OldSword(), new BronzeAxe(), new SpartanSpear() };
            Stage stage = new Stage(player, item);

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
                    Stage.Shop();
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
