using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class UpdateItemsTests
    {
        [Test]
        public void when_the_sell_in_has_passed_quality_degrades_twice_as_fast()
        {
            var item = UpdateQuality(new Item { Name = "some item", SellIn = 1, Quality = 2 });
            Assert.That(item.Quality, Is.EqualTo(0));
            Assert.That(item.SellIn, Is.EqualTo(0));
        }

        [Test]
        public void when_the_quality_of_an_item_is_never_negative()
        {
            var item = UpdateQuality(new Item { Name = "some item", SellIn = 2, Quality = 0 });
            Assert.That(item.Quality, Is.EqualTo(0));
        }

        [Test]
        public void Aged_Brie_should_increase_in_quality_the_older_it_gets()
        {
            var item = UpdateQuality(new Item {Name = "Aged Brie", Quality = 1, SellIn = 1});
            Assert.That(item.Quality, Is.EqualTo(2));
        }

        [Test]
        public void quality_should_never_more_than_fifty()
        {
            var item = UpdateQuality(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 60, SellIn = 1 });
            Assert.That(item.Quality, Is.EqualTo(50));
        }  
 

        [Test]
        public void Sulfuras_legendary_item_it_should_not_decrease_in_quality()
        {
            var item = UpdateQuality(new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 1, SellIn = 1 });
            Assert.That(item.Quality, Is.EqualTo(1));
        }

        [Test]
        public void Sulfuras_legendary_item_it_should_not_decrease_sell_in()
        {
            var item = UpdateQuality(new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 1, SellIn = 1 });
            Assert.That(item.SellIn, Is.EqualTo(1));
        }

        [Test]
        public void Backstage_passes_it_should_increase_in_quality()
        {
            var item = UpdateQuality(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = 11 });
            Assert.That(item.Quality, Is.EqualTo(2));
        }

        [TestCase(10)]
        [TestCase(9)]
        [TestCase(8)]
        [TestCase(7)]
        [TestCase(6)]
        public void Backstage_passes_it_should_increase_quality_by_two_when_there_are_ten_or_less_days_left(int daysLeft)
        {
            var item = UpdateQuality(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = daysLeft });
            Assert.That(item.Quality, Is.EqualTo(3));
        }

        [TestCase(5)]
        [TestCase(4)]
        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        public void Backstage_passes_it_should_increase_quality_by_three_when_there_are_five_days_left(int daysLeft)
        {
            var item = UpdateQuality(new Item {Name = "Backstage passes to a TAFKAL80ETC concert",Quality = 1,SellIn = daysLeft});
            Assert.That(item.Quality, Is.EqualTo(4));
        }

        [Test]
        public void Backstage_passes_it_should_drop_quality_to_zero_when_sell_in_has_passed()
        {
            var item = UpdateQuality(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = 0 });
            Assert.That(item.Quality, Is.EqualTo(0));
        }

        [Test]
        public void Conjured_it_should_degrade_in_quality_twice_as_fast_as_normal_items()
        {
            var item = UpdateQuality(new Item { Name = "Conjured Mana Cake", Quality = 4, SellIn = 0 });
            Assert.That(item.Quality, Is.EqualTo(2));
        } 


        public static Item UpdateQuality(Item item)
        {
            var program = new Program {Items = new List<Item> {item}};
            program.UpdateQuality();

            return item;
        }
    }
}
 
