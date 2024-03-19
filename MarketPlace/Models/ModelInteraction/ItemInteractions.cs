using MarketDataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Models.ModelInteraction
{
    public class ItemInteractions
    {
        private MarketPlaceContext _db;
        public ItemInteractions(MarketPlaceContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Item item)
        {
            try
            {
                _db.Items.Add(item);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

        }
        public async Task<Item> Read(int? id)
        {
            try
            {
                var item = await _db.Items.FirstOrDefaultAsync(m => m.Id == id);
                if (item == null) { throw new Exception("Item is null"); }
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public async Task<List<Item>> GetAll(string key = "")
        {
            try
            {
                var items = await _db.Items.Where(x => x.Name.Contains(key)).ToListAsync();
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public async Task<Item> Update(int? id, int amount)
        {
            try
            {
                Item item = await Read(id);
                item.Amount = amount;
                await _db.SaveChangesAsync();

                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public async Task<Item> Delete(int? id)
        {
            try
            {
                var item = await Read(id);
                _db.Items.Remove(item);
                await _db.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
