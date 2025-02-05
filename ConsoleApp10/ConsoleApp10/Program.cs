using System.ComponentModel;
using System.Xml.Linq;

namespace ConsoleApp10
{
    internal class Program
    {
        
        static Item_Equip[] itemsEquip = GetEquipItemList();
        static Item_Equip[] GetEquipItemList()
        {
            Item_Equip[] itemsEquip = new Item_Equip[14];
            itemsEquip[0] = new Item_Equip { name = "낡은 검", info = "중고의 낡은 검.싸다", equipType = 0, jobLimit = new int[] { 0 }, atk = 5, def = 0, hp = 0, price = 100 };
            itemsEquip[1] = new Item_Equip { name = "단검", info = "짧은 도신의 검.", equipType = 0, jobLimit = new int[] { 0 }, atk = 5, def = 0, hp = 0, price = 200 };
            itemsEquip[2] = new Item_Equip { name = "일반 검", info = "일반적인 검.", equipType = 0, jobLimit = new int[] { 0 }, atk = 8, def = 1, hp = 0, price = 400 };
            itemsEquip[3] = new Item_Equip { name = "방패", info = "왼손에 착용가능한 일반적인 방패.묵직하다.", equipType = 1, jobLimit = new int[] { 1 }, atk = 1, def = 10, hp = 0, price = 400 };
            itemsEquip[4] = new Item_Equip { name = "보조 단검", info = "왼손에 착용가능한 부무장.왼손까지 무기를 들려면 연습이필요하다.", equipType = 1, jobLimit = new int[] { 2 }, atk = 5, def = 0, hp = 0, price = 400 };
            itemsEquip[5] = new Item_Equip { name = "가죽 헬멧", info = "가죽으로 만든 투구.", equipType = 2, jobLimit = new int[] { 0 }, atk = 0, def = 3, hp = 0, price = 500 };
            itemsEquip[6] = new Item_Equip { name = "철제 투구", info = "철로 된 튼튼한 투구.자유롭게 움직이려면 근력이 필요하다", equipType = 2, jobLimit = new int[] { 1 }, atk = 0, def = 5, hp = 0, price = 600 };
            itemsEquip[7] = new Item_Equip { name = "무광 후드", info = "어두운색의 천모자.", equipType = 2, jobLimit = new int[] { 2 }, atk = 0, def = 1, hp = 0, price = 300 };
            itemsEquip[8] = new Item_Equip { name = "가죽 갑옷", info = "가죽으로 만든 갑옷.", equipType = 3, jobLimit = new int[] { 0 }, atk = 0, def = 5, hp = 50, price = 800 };
            itemsEquip[9] = new Item_Equip { name = "철제 갑옷", info = "철로된 갑옷.", equipType = 3, jobLimit = new int[] { 1 }, atk = 0, def = 10, hp = 100, price = 1000 };
            itemsEquip[10] = new Item_Equip { name = "암살자옷", info = "천으로된 갑옷.입기 복잡하다", equipType = 3, jobLimit = new int[] { 2 }, atk = 2, def = 3, hp = 20, price = 800 };
            itemsEquip[11] = new Item_Equip { name = "가죽 각반", info = "일반적인 검이다.", equipType = 4, jobLimit = new int[] { 0 }, atk = 0, def = 3, hp = 50, price = 400 };
            itemsEquip[12] = new Item_Equip { name = "철제 각반", info = "일반적인 검이다.", equipType = 4, jobLimit = new int[] { 1 }, atk = 0, def = 5, hp = 100, price = 400 };
            itemsEquip[13] = new Item_Equip { name = "암살자 각반", info = "일반적인 검이다.", equipType = 4, jobLimit = new int[] { 2 }, atk = 2, def = 2, hp = 20, price = 400 };
            return itemsEquip;
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("스파르타 던전에 오신것을 환영합니다.");
            Character character = CreatCharacter();
            
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신것을 환영합니다.");
            Console.WriteLine("이곳은 마을입니다. 여기서 상점을 가거나, 기본적인 정비를 할 수 있습니다. (다음 ,아무키입력)");
            Console.ReadLine();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("마을입니다\n\n1.상태보기\n2.인벤토리\n3.상점\n4.던전가기\n\n원하시는 행동을 입력해주세요.");
                string input;
                switch(input = Console.ReadLine())
                {
                    case "1":ShowState(character);break;
                    case "2":InventoryScene(character); break;
                    case "3":ShopScene(character);break;
                    case "4":ShowState(character);break;
                    default: { WrongMassage(); continue; }
                }
            }

        }
        static void ShopScene(Character character)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점에 왔습니다. 골드로 원하는 아이템을 사거나 판매할 수 있습니다.\n무엇을 하시겠습니까?\n\n1.구매\n2.판매\n\n0. 상점 나가기");
                string input;
                while (true)
                {
                    input = Console.ReadLine();
                    if (input == "0" || input == "1" || input == "2") break; WrongMassage();
                }
                if (input == "0") break;
                if (input == "1")
                {
                    Console.WriteLine("어떤 물품을 구매합니까?\n\n1.무기,보조\n2.방어구\n3.잡화\n\n0. 뒤로");
                    while (true)
                    {
                        input = Console.ReadLine();
                        if (input == "0" || input == "1" || input == "2" || input == "3") break;
                        WrongMassage();
                    }
                    switch (input)
                    {
                        case "1": ShowShop(1); continue;
                        case "2": ShowShop(2); continue;
                        case "3": ShowShop(3); continue;
                        default: break;
                    }
                }
                
            }
            void ShowShop(int ItemType)
            {
                List<int> shopItemList = new List<int>(); //물품 타입에 맞게 상점물품 목록 생성
                switch (ItemType)
                {
                    case 1:
                        {
                            for (int i = 0; i < itemsEquip.Length; i++)
                            {
                                if (itemsEquip[i].equipType == 0 || itemsEquip[i].equipType == 1) shopItemList.Add(i);
                            }
                        }
                        break;
                    case 2:
                        {
                            for (int i = 0; i < itemsEquip.Length; i++)
                            {
                                if (itemsEquip[i].equipType == 2 || itemsEquip[i].equipType == 3 || itemsEquip[i].equipType == 4) shopItemList.Add(i);
                            }
                        }
                        break;
                    case 3:
                        {
                            for (int i = 0; i < itemsEquip.Length; i++)
                            {
                                if (itemsEquip[i].equipType == 0 || itemsEquip[i].equipType == 1) shopItemList.Add(i);
                            }
                        }
                        break;
                }
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("구매를 원하시는 아이템을 선택하여 주세요.\n\n[아이템 목록]");
                    for (int i = 0; i < shopItemList.Count; i++)
                    {
                        Console.Write($"{i + 1}. ");
                        PrintItem(itemsEquip[shopItemList[i]],true);
                    }
                    Console.WriteLine("\n0. 나가기");
                    string input;
                    int inputInt;
                    while (true)
                    {
                        input = Console.ReadLine();
                        if (int.TryParse(input,out inputInt)&&inputInt>=0&&inputInt<=shopItemList.Count) break;
                        WrongMassage();
                    }
                    
                    if (input == "0") break; //나가기
                    
                    if (character.money >= itemsEquip[shopItemList[inputInt - 1]].price) //가격지불가능 여부 확인
                    {
                        if (itemsEquip[shopItemList[inputInt-1]].jobLimit.Contains(0)|| itemsEquip[shopItemList[inputInt - 1]].jobLimit.Contains(character.job)) //착용직업제한 확인
                        {
                            Console.WriteLine("이 아이템을 착용할 수 없는 직업입니다. 그래도 구매하시겠습니까?\n1.예        2.아니요");
                            string input2;
                            while (true)
                            {
                                input2 = Console.ReadLine();
                                if (input == "1" || input == "2") break;
                                WrongMassage();
                            }
                            if (input == "2") con;
                            
                        }
                    }
                    else { Console.WriteLine("구매에 필요한 골드가 부족합니다"); }
                }
            }

        }
        static void WrongMassage()
        {
            Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
        }
        class Character()
        {
            public int itemCode;
            public string name;
            public int job, level = 1, hp = 100, atk = 10, def = 5, money = 1000;
            public List<int> inventory = new List<int>{5};
            public int[] equipment = { 0, -1, -1, 8, -1 };
        }
        
        static Character CreatCharacter()
        {
            Character character = new Character();
            
            string name;
            int job;
            while (true)
            {
                Console.WriteLine("원하시는 이름을 설정해주세요.\n");
                name = Console.ReadLine();
                Console.WriteLine($"\n입력하신 이름은 {name} 입니다.\n\n1.저장\n2.취소\n\n이대로 설정하시겠습니까?");
                string input;
                while (true)
                {
                    input = Console.ReadLine();
                    if (input == "1" || input == "2") break; else WrongMassage();
                }
                if (input == "1") break;
            }
            while (true)
            {
                Console.WriteLine("원하시는 직업을 설정해주세요.\n\n1.전사\n2.도적\n\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": { Console.WriteLine("직업을 전사로 확정하시겠습니까?\n1.예\n2.아니오\n"); break; }
                    case "2": { Console.WriteLine("직업을 도적으로 확정하시겠습니까?\n1.예\n2.아니오\n"); break; }
                    default: { WrongMassage(); continue; }
                }
                string input2;
                while (true)
                {
                    input2 = Console.ReadLine();
                    if (input2 =="1" || input2 == "2") break;
                    WrongMassage();
                }
                if (input2 == "1") { job = int.Parse(input); break; }
            }
            character.name = name;
            character.job = job;

            Console.Clear();
            Console.WriteLine("캐릭터를 생성하였습니다.");
            ShowState(character);
            return character;
        }
        struct Item_Equip
        {
            public string name;
            public string info;
            public int equipType;//착용부위 0.오른손 1.왼손 2.머리 3.몸 4.발
            public int[] jobLimit;//0공용 1전사 2도적
            public int atk, def, hp, price;
        }
        
        static void ShowState(Character character)
        {
            Console.Clear();
            string[] jobs = { "전사", "도적" };
            int plusAtk=0, plusDef=0, PlusHp=0;
            for (int i = 0; i < 5; i++)
            {
                if (character.equipment[i] != -1)
                {
                    plusAtk += itemsEquip[character.equipment[i]].atk;
                    plusDef += itemsEquip[character.equipment[i]].def;
                    PlusHp += itemsEquip[character.equipment[i]].hp;
                }
            }
            Console.WriteLine($"Lv. {character.level:D2}\n직업 :[{jobs[character.job - 1]}]");
            Console.WriteLine($"공격력 :{character.atk+plusAtk,-4}({character.atk}{plusAtk:+0;-0;+0})\n방어력 :{character.def + plusDef,-4}({character.def}{plusDef:+0;-0;+0})\n체력   :{character.hp+PlusHp,-4}({character.hp}{PlusHp:+0;-0;+0})");
            Console.Write($"Gold   :{character.money} G");
            Console.WriteLine("아무키 입력. 상태보기 종료");
            Console.ReadLine();
        }
        
        static void InventoryScene(Character character)
        {
            while (true)
            {
                Console.Clear();
                ShowInventory(character,false);

                string input;
                while (true)
                {
                    Console.Clear();
                    
                    ShowInventory(character,false);
                    Console.WriteLine("\n1.장착 관리\n0. 나가기\n\n원하시는 행동을 입력해주세요.");
                    input = Console.ReadLine();
                    if (input == "1" || input == "0") break;
                    WrongMassage();
                }
                if (input == "0") break; //인벤토리 나가기
                if (input == "1")        //장착 관리하기
                {
                    while (true)
                    {
                        Console.Clear();
                        ShowInventory(character,false);
                        Console.WriteLine("\n장착(해제)할 아이템을 선택해 주세요.\n0. 나가기\n");

                        int equipNum = 0; //장착중인 장비 개수
                        for (int i = 0; i < 5; i++) { if (character.equipment[i] != -1) equipNum++; }

                        int chooseNum; //선택할 아이템 int값

                        while (true)
                        {
                            while (true)
                            {
                                input = Console.ReadLine();
                                if (int.TryParse(input, out chooseNum) && chooseNum <= equipNum + character.inventory.Count && chooseNum >= 0) break;
                                WrongMassage();
                            }
                            if (chooseNum != 0)
                            {
                                Console.WriteLine("해당 아이템을 장착(해제)합니까?\n1.예\n2.취소");
                                string input2;
                                while (true)
                                {
                                    input2 = Console.ReadLine();
                                    if (input2 == "1" || input2 == "2") break;
                                    WrongMassage();
                                }
                                if (input2 == "1")  //장착(해제)하기
                                {

                                    if (chooseNum <= equipNum) //장착된 장비 해제
                                    {
                                        int num = 0;
                                        for (int i = 0; i < 5; i++)
                                        {
                                            if (character.equipment[i] != -1) num++;
                                            if (num == chooseNum) { character.inventory.Add(character.equipment[i]); character.equipment[i] = -1;break; }
                                        }
                                    }
                                    else //장착하기
                                    {
                                        if (itemsEquip[character.inventory[chooseNum - equipNum - 1]].jobLimit.Contains(character.job) || itemsEquip[character.inventory[chooseNum - equipNum - 1]].jobLimit.Contains(0))
                                        {
                                            if (character.equipment[itemsEquip[character.inventory[chooseNum - equipNum - 1]].equipType] != -1) //장비칸이 비어있지않다면
                                            {
                                                character.inventory.Add(character.equipment[itemsEquip[character.inventory[chooseNum - equipNum - 1]].equipType]);
                                                character.equipment[itemsEquip[character.inventory[chooseNum - equipNum - 1]].equipType] = character.inventory[chooseNum - equipNum - 1];
                                                character.inventory.RemoveAt(chooseNum - equipNum - 1);
                                            }
                                            else
                                            {
                                                character.equipment[itemsEquip[character.inventory[chooseNum - equipNum - 1]].equipType] = character.inventory[chooseNum - equipNum - 1];
                                                character.inventory.RemoveAt(chooseNum - equipNum - 1);
                                            }
                                        }
                                        else { Console.WriteLine("당신의 직업은 이 장비를 장착할 수 없습니다.(확인.아무키입력)"); Console.ReadLine(); }
                                    }
                                }
                                else break;
                            }break;
                        }
                        if (input == "0") break;
                    }
                    
                }
            }
            
        }
        
        static void ShowInventory(Character character,bool isShop)
        {
            Console.WriteLine($"인벤토리\n");
            Console.WriteLine($"아이템 목록           소지금액 : {character.money} G\n");
            int equipNum=0;
            for(int i=0; i<5; i++)
            {
                if (character.equipment[i] != -1)
                {
                    equipNum++;
                    Console.Write($"{equipNum,-2}[E] ");
                    PrintItem(itemsEquip[character.equipment[i]],isShop);
                }
            }
            for(int i = 0; i < character.inventory.Count; i++)
            {
                Console.Write($"{i + equipNum + 1,-2}.");
                PrintItem(itemsEquip[character.inventory[i]],isShop);
            }

        }
        static void PrintItem(Item_Equip item,bool isShop)
        {
            string[] jobLimit = { "공용", "전사착용가능", "도적착용가능" };
            string[] equipTypes = { "[주무기]", "[보조장비]", "[머리]", "[몸]", "[발]" };
            Console.WriteLine($"-{item.name,-12}|{item.info}");
            if (isShop) Console.Write($"   가격 :{item.price,5}G"); else Console.Write("     ");      //상점일때 가격표시
            Console.Write($"{equipTypes[item.equipType],-6}|공격력 {item.atk,-5:+0;-0;0}|방어력 {item.def,-5:+0;-0;0}|체력 {item.hp,-5:+0;-0;0}");
            for (int i = 0;i<item.jobLimit.Length;i++) { Console.Write($"[{jobLimit[item.jobLimit[i]]}]"); Console.WriteLine(); }
        }
    }
}
