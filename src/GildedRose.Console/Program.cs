using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program
                {
                    Items = GetInitialItems()
                };

            app.UpdateQuality();
            System.Console.ReadKey();
        }

        public static List<Item> GetInitialItems()
        {
            return new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item {Name = "Backstage passes to a TAFKAL80ETC concert",SellIn = 15,Quality = 20},
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                };
        }

        public   void UpdateQuality()
        {
            foreach (var t in Items)
            {
                Update(t);
            }
        }

        private static void Update(Item t)
        {
            switch (t.Name)
            {
                case "Elixir of the Mongoose":
                case "+5 Dexterity Vest":
                    t.Quality = t.Quality > 0 ? t.Quality - 1 : t.Quality;
                    t.SellIn = t.SellIn - 1;
                    break;
                case "Aged Brie":
                    t.Quality = t.Quality < 50 ? t.Quality + 1 : t.Quality;
                    t.SellIn = t.SellIn - 1;
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    t.Quality = t.Quality;
                    t.SellIn = t.SellIn;
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    t.Quality = CalculateQualityOfBackstagePass(t.SellIn, t.Quality);
                    t.SellIn = t.SellIn - 1;
                    break;

                case "Conjured Mana Cake":
                    t.Quality = t.Quality > 0 ? t.Quality - 2 : t.Quality;
                    t.SellIn = t.SellIn - 1;
                    break;
            }
        }

        /*private static void OldCodeUpdate(Item t)
        {
            if (t.Name != "Aged Brie" && t.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (t.Quality > 0)
                {
                    if (t.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        t.Quality = t.Quality - 1;
                    }
                }
            }
            else
            {
                if (t.Quality < 50)
                {
                    t.Quality = t.Quality + 1;

                    if (t.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (t.SellIn < 11)
                        {
                            if (t.Quality < 50)
                            {
                                t.Quality = t.Quality + 1;
                            }
                        }

                        if (t.SellIn < 6)
                        {
                            if (t.Quality < 50)
                            {
                                t.Quality = t.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (t.Name != "Sulfuras, Hand of Ragnaros")
            {
                t.SellIn = t.SellIn - 1;
            }

            if (t.SellIn < 0)
            {
                if (t.Name != "Aged Brie")
                {
                    if (t.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (t.Quality > 0)
                        {
                            if (t.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                t.Quality = t.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        t.Quality = t.Quality - t.Quality;
                    }
                }
                else
                {
                    if (t.Quality < 50)
                    {
                        t.Quality = t.Quality + 1;
                    }
                }
            }            
        } */

        private static int CalculateQualityOfBackstagePass(int sellIn, int quality)
        {
            if (sellIn <= 0) return 0;
            if (sellIn > 0) quality++;
            if (sellIn > 0 && sellIn <= 10) quality++;
            if (sellIn > 0 && sellIn <= 5) quality++;
            return quality > 50 ? 50 : quality;
        } 
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
 
    }

}
