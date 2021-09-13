using LedgerClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LedgerClient.Services {
	public class DataStore : IDataStore<LedgerRecord> {
		readonly List<LedgerRecord> items;

		public DataStore() {
			items = new List<LedgerRecord>()
			{
				new LedgerRecord { Id = Guid.NewGuid().ToString(), ProductName = "First item", Description="This is an item description.", Сustomer = "Лёша" },
				new LedgerRecord { Id = Guid.NewGuid().ToString(), ProductName = "Second item", Description="This is an item description.", Сustomer = "Дима" },
				new LedgerRecord { Id = Guid.NewGuid().ToString(), ProductName = "Third item", Description="This is an item description.", Сustomer = "Дима" },
				new LedgerRecord { Id = Guid.NewGuid().ToString(), ProductName = "Fourth item", Description="This is an item description.", Сustomer = "Артур" },
				new LedgerRecord { Id = Guid.NewGuid().ToString(), ProductName = "Fifth item", Description="This is an item description.", Сustomer = "Лёша" },
				new LedgerRecord { Id = Guid.NewGuid().ToString(), ProductName = "Sixth item", Description="This is an item description.", Сustomer = "Лёша" }
			};
		}

		public async Task<bool> AddItemAsync(LedgerRecord item) {
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(LedgerRecord item) {
			var oldItem = items.Where((LedgerRecord arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(oldItem);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(string id) {
			var oldItem = items.Where((LedgerRecord arg) => arg.Id == id).FirstOrDefault();
			items.Remove(oldItem);

			return await Task.FromResult(true);
		}

		public async Task<LedgerRecord> GetItemAsync(string id) {
			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<LedgerRecord>> GetItemsAsync(bool forceRefresh = false) {
			return await Task.FromResult(items);
		}
	}
}